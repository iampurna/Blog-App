using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace blog_backend.Data;

public class SqlRepository<T>:IRepository<T> where T: class
{
    private readonly AppDbContext dbContext;
    private IRepository<T> _repositoryImplementation;

    public SqlRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<List<T>> GetAll()
    {
      return  await dbContext.Set<T>().ToListAsync();

    }

    public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter)
    {
        return  await dbContext.Set<T>().Where(filter).ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
    }

    public void Update(T entity)
    {
       
       dbContext.Set<T>().Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity= await dbContext.Set<T>().FindAsync(id);
        dbContext.Set<T>().Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}