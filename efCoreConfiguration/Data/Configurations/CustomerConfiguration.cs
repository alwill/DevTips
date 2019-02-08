using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public virtual void Configure(EntityTypeBuilder<Customer> entity)
    {
        entity.Property(c => c.Name).IsRequired().HasMaxLength(150);
    }
}