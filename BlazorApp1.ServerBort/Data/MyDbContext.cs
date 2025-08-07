using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.ServerBort.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
: base(options)
        {
        }

        public DbSet<Entities.Water> Intakes { get; set;}
    }
}
