using System.Collections.Generic;
using System.Linq;
using ModelCollectionInitialization.Entities;

namespace ModelCollectionInitialization.Data
{
    public class ExampleInitializer
    {
        public static void Initialize(ExampleContext context)
        {
            if (context.Order.Any())
            {
                return;
            }

            var order = new Order
            {
                Name = "My first order",
                Items = new List<Item> { new Item { Name = "Alpha" } }
            };

            var order2 = new Order { Name = "My second order" };

            context.Order.AddRange(order, order2);
            context.SaveChanges();
        }
    }
}