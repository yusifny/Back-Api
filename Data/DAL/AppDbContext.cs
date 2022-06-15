using Microsoft.EntityFrameworkCore;

namespace WebApi_1.Data.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}