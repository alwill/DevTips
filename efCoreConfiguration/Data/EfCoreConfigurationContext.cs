using Microsoft.EntityFrameworkCore;

public class EfCoreConfigurationContext : DbContext
{
    public EfCoreConfigurationContext(DbContextOptions<EfCoreConfigurationContext> options) : base(options)
    {
    }

    public virtual DbSet<Customer> Customer { get; set; }
    public virtual DbSet<Order> Order { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfCoreConfigurationContext).Assembly);
    }
}