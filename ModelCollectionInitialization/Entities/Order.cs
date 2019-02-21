using System.Collections.Generic;

namespace ModelCollectionInitialization.Entities
{
    public class Order
    {
        public Order()
        {
            Items = new HashSet<Item>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}