using Microsoft.EntityFrameworkCore;

public class EfCoreConfigurationContext : DbContext
{
    public EfCoreConfigurationContext(DbContextOptions<EfCoreConfigurationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId).HasConstraintName("FK_Order_Customer");
        modelBuilder.Entity<Order>().Property(o => o.Description).IsRequired().HasMaxLength(500);

        modelBuilder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(150);
    }
}