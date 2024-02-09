using Microsoft.AspNetCore.Mvc.Rendering;
using ShopOnline.Models;

namespace ShopOnline.ViewModels
{
    public class AddBikeViewModel
    {
        public IEnumerable<SelectListItem>? Customers { get; set; }
        public Bike Bike { get; set; }
    }
}
