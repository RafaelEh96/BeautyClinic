using System.Linq.Expressions;
using BeautyClinic.Core.Base;

namespace BeautyClinic.Core.Interfaces;

public interface IService<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<T> InsertOrUpdateAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(Guid id);
}
