using System;
using System.Collections.Generic;

namespace ExistingDbScaffolding.Data
{
    public class Order
    {
        public Order()
        {
            Item = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Total { get; set; }
        // public string SpecialInstructions { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }
}
