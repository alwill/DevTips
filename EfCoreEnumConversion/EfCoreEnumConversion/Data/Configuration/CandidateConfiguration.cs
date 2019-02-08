using System;
using EfCoreEnumConversion.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreEnumConversion.Data.Configuration
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(b => b.Party).HasConversion(c => c.ToString(), c => Enum.Parse<Party>(c));
        }
    }
}