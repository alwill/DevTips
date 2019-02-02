using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public virtual void Configure(EntityTypeBuilder<Order> entity)
    {
        entity.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId).HasConstraintName("FK_Order_Customer");
        entity.Property(o => o.Description).IsRequired().HasMaxLength(500);
    }
}