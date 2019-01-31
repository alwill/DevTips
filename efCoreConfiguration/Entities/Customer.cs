using System.Collections.Generic;

public class Customer
{
    public Customer()
    {
        Orders = new HashSet<Order>();
    }
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Order> Orders { get; set; }
}