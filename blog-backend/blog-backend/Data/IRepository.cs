using System.Linq.Expressions;

namespace blog_backend.Data;

public interface IRepository<T> where T: class
{
    Task<List<T>> GetAll();
    Task<List<T>> GetAll(Expression<Func<T,bool>> filter);
    Task<T?> GetById(int id);
    Task AddAsync(T entity);
    void Update(T entity);
    Task DeleteAsync(int id);
    Task SaveChangesAsync();

}