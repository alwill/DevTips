namespace EfCoreInMemoryTests.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderTotal { get; set; }
        public CustomerStatus Status { get; set; }
    }

    public enum CustomerStatus
    {
        Standard,
        Premium
    }
}