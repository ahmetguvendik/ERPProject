using System.Linq.Expressions;

namespace Application.Repostitories;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(string id);
    Task<List<T>> GetAllAsync();    
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter); 

    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task SaveAsync();
}