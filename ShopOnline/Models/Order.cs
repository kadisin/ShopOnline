namespace ShopOnline.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
        public virtual Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal => LineItems.Sum(item => item.Product.Price * item.Quantity);
    }
}
