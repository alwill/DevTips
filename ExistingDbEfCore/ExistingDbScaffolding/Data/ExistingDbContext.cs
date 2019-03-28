using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExistingDbScaffolding.Data
{
    public partial class ExistingDbContext : DbContext
    {
        public ExistingDbContext()
        {
        }

        public ExistingDbContext(DbContextOptions<ExistingDbContext> options)
            : base(options)
        {
        }
        
        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ExistingScaffold;User=sa;Password=ArchitectNow!;");
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Item__OrderId__38996AB5");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}
