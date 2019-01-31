using Microsoft.EntityFrameworkCore;

public class EfCoreConfigurationContext : DbContext
{
    public EfCoreConfigurationContext(DbContextOptions<EfCoreConfigurationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfCoreConfigurationContext).Assembly);
    }
}