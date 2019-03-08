using System;
using System.Collections.Generic;

namespace ExistingDbScaffolding.Data
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
