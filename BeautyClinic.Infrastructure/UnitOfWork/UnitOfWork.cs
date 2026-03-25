using System.Collections;
using BeautyClinic.Core.Base;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Infrastructure.Context;
using BeautyClinic.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace BeautyClinic.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly Hashtable _repositories;
    private readonly ILogger<UnitOfWork> _logger;
    private readonly ITenantProvider _tenantProvider;
    private IDbContextTransaction? _currentTransaction;

    public UnitOfWork(AppDbContext context, ILogger<UnitOfWork> logger, ITenantProvider tenantProvider)
    {
        _context = context;
        _logger = logger;
        _tenantProvider = tenantProvider;
        _repositories = new Hashtable();
    }

    public async Task<int> CommitAsync()
    {
        try
        {
            _logger.LogDebug("Saving changes for {Context}", nameof(AppDbContext));
            var changes = await _context.SaveChangesAsync();
            _logger.LogInformation("Changes saved: {Count}", changes);
            return changes;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error committing changes");
            throw;
        }
    }

    public async Task BeginTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            _logger.LogDebug("Transaction already started; reusing current transaction");
            return;
        }

        _currentTransaction = await _context.Database.BeginTransactionAsync();
        _logger.LogInformation("Transaction started");
    }

    public async Task CommitTransactionAsync()
    {
        if (_currentTransaction == null)
        {
            _logger.LogDebug("No active transaction to commit");
            return;
        }

        try
        {
            await _context.SaveChangesAsync();
            await _currentTransaction.CommitAsync();
            _logger.LogInformation("Transaction committed");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error committing transaction; rolling back");
            await RollbackTransactionAsync();
            throw;
        }
        finally
        {
            await DisposeTransactionAsync();
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_currentTransaction == null)
        {
            _logger.LogDebug("No active transaction to rollback");
            return;
        }

        try
        {
            await _currentTransaction.RollbackAsync();
            _logger.LogError("Transaction rolled back");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during transaction rollback");
            throw;
        }
        finally
        {
            await DisposeTransactionAsync();
        }
    }

    private Task DisposeTransactionAsync()
    {
        _currentTransaction?.Dispose();
        _currentTransaction = null;
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _currentTransaction?.Dispose();
        _context.Dispose();
    }

    public IRepository<T> Repository<T>() where T : BaseEntity
    {
        var type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(Repository<>);
            var repositoryInstance = Activator
                .CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context, _tenantProvider);
            _repositories.Add(type, repositoryInstance);
        }

        return (IRepository<T>)_repositories[type]!;
    }
}
