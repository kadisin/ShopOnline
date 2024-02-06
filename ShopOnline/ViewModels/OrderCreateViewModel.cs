using ShopOnline.Models;

namespace ShopOnline.ViewModels
{
    public class OrderCreateViewModel
    {
        public IEnumerable<LineItem> LineItems { get; set; }
        public Customer Customer { get; set; }
    }
}
