namespace ShopOnline.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public Product()
        {
            ProductId = Guid.NewGuid();
        }

    }
}
