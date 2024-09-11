using blog_backend.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace blog_backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
    {
        
    }
    public DbSet<Blog>Blogs { get; set; }
    public DbSet<Category>Categories { get; set; }

}