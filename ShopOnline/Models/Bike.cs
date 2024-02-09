namespace ShopOnline.Models
{
    public class Bike
    {
        public Guid BikeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Customer? Customer { get; set; }
        public Guid CustomerId { get; set; }

        public Bike()
        {
            BikeId = Guid.NewGuid();    
        }
    }
}
