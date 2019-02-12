using System;
using EfCoreInMemoryTests.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreInMemoryTests.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(e => e.Status).HasConversion(v => v.ToString(), v => Enum.Parse<CustomerStatus>(v));
        }
    }
}