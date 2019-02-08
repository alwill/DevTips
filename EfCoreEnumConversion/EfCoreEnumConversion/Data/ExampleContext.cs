using EfCoreEnumConversion.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreEnumConversion.Data
{
    public class ExampleContext : DbContext
    {
        public virtual DbSet<Candidate> Candidate { get; set; }
        
        public ExampleContext(DbContextOptions<ExampleContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExampleContext).Assembly);
        }
    }
}