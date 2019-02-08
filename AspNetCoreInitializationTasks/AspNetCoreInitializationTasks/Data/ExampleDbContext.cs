using AspNetCoreInitializationTasks.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreInitializationTasks.Data
{
    public class ExampleDbContext : DbContext
    {
        public virtual DbSet<Person> Person { get; set; }

        public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options)
        {
            
        }
    }
}