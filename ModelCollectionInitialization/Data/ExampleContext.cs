using Microsoft.EntityFrameworkCore;
using ModelCollectionInitialization.Entities;

namespace ModelCollectionInitialization.Data
{
    public class ExampleContext : DbContext
    {
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public ExampleContext(DbContextOptions<ExampleContext> options) : base(options)
        {

        }
    }
}