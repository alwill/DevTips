using System.Collections.Generic;

namespace FirstMigration.Data 
{
    public class Order 
    {
        public Order()
        {
            Items = new List<Item>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SpecialInstructions {get; set;}

        public virtual ICollection<Item> Items {get;set;}
    }
}