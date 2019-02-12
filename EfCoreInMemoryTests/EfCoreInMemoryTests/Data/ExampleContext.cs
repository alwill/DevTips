using EfCoreInMemoryTests.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreInMemoryTests.Data
{
    public class ExampleContext : DbContext
    {
        public virtual DbSet<Customer> Customer { get; set; }

        public ExampleContext(DbContextOptions<ExampleContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExampleContext).Assembly);
        }
    }
}