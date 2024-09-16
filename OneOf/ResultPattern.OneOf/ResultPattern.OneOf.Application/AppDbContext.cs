using Microsoft.EntityFrameworkCore;

namespace ResultPattern.OneOf.Application
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Car> Cars { get; set; }
    }
}