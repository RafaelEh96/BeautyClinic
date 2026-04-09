using System.Linq.Expressions;
using BeautyClinic.Core.Base;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Auth;

namespace BeautyClinic.Core.Services;

public class BaseService<T>(IRepository<T> repository, IUnitOfWork unitOfWork, ICurrentUserProvider currentUserProvider) : IService<T>
    where T : BaseEntity
{
    protected readonly IRepository<T> _repository = repository;
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;

    /// <summary>
    /// Stageia um insert ou update no change tracker do EF Core, sem commitar.
    /// Deve ser chamado dentro de <see cref="ExecuteInTransactionAsync"/>, que realiza o commit ao final.
    /// Para operações standalone (entidade única), use <see cref="AddAsync"/>, <see cref="UpdateAsync"/> ou <see cref="RemoveAsync"/>.
    /// </summary>
    public async Task<T> InsertOrUpdateAsync(T entity)
    {
        if (entity.IsSaved)
            await Update(entity);
        else
            await Insert(entity);
        return entity;
    }

    private async Task<T> Insert(T entity)
    {
        PreInsertOrUpdate(entity);
        await Inserting(entity);
        PostInsertOrUpdate(entity);
        return entity;
    }
    
    private async Task<T> Update(T entity)
    {
        PreInsertOrUpdate(entity);
        await Updating(entity);
        PostInsertOrUpdate(entity);
        return entity;
    }
    
    private async Task<T> Inserting(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UserId = currentUserProvider.GetUserId();
        await _repository.AddAsync(entity);
        return entity;
    }

    private Task<T> Updating(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UserId = currentUserProvider.GetUserId();
        _repository.Update(entity);
        return Task.FromResult(entity);
    }
    
    protected virtual void PreInsertOrUpdate(T entity){}
    
    protected virtual void PostInsertOrUpdate(T entity){}

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _repository.FindAsync(predicate);
    }

    public virtual async Task AddAsync(T entity)
    {
        await ExecuteWithCommitAsync(() => _repository.AddAsync(entity));
    }

    public virtual async Task UpdateAsync(T entity)
    {
        await ExecuteWithCommitAsync(() =>
        {
            _repository.Update(entity);
            return Task.CompletedTask;
        });
    }

    public virtual async Task RemoveAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity != null)
        {
            await ExecuteWithCommitAsync(() =>
            {
                _repository.Remove(entity);
                return Task.CompletedTask;
            });
        }
    }

    /// <summary>
    /// Execute a write operation followed by a commit (no transaction).
    /// </summary>
    private async Task ExecuteWithCommitAsync(Func<Task> action)
    {
        await action();
        await _unitOfWork.CommitAsync();
    }

    /// <summary>
    /// Execute a multi-step operation inside a transaction; use when touching multiple repositories.
    /// </summary>
    protected async Task ExecuteInTransactionAsync(Func<Task> action)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            await action();
            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}
