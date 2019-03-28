using System.Collections.Generic;

namespace FirstMigration.Data 
{
    public static class TestDbInitializer
    {
        public static void Initialize(TestDbContext context)
        {
            context.Order.Add(new Order{
                Name = "Order 1",
                Items = new List<Item> {new Item{Name = "Item 1"}}
            });
            context.SaveChanges();
        }
    }
}