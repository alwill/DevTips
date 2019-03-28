using Microsoft.EntityFrameworkCore;

namespace FirstMigration.Data 
{
    public class TestDbContext : DbContext 
    {
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public TestDbContext()
        {
        }

        public TestDbContext(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,32768;Database=TestDb;User=sa;Password=Testpassword!;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Item>().HasOne(e => e.Order).WithMany(e => e.Items).HasForeignKey(e => e.OrderId).HasConstraintName("FK_Item_Order");
        }
    }
} 