using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasOne(o => o.Customer)
       .WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId).HasConstraintName("FK_Order_Customer");
        builder.Property(o => o.Description)
        .IsRequired().HasMaxLength(500);
    }
}