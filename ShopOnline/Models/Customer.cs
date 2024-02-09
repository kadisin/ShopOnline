namespace ShopOnline.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public ICollection<Bike> Bikes { get; set; }


        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }

    }
}
