public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Description { get; set; }

    public Customer Customer { get; set; }
}