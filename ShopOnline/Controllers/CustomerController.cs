using Microsoft.AspNetCore.Mvc;
using ShopOnline.Repository.Generics;
using ShopOnline.Models;
using ShopOnline.UnitOfWork;
using ShopOnline.Services;

namespace ShopOnline.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllAsync();
            return View(customers);
        }
    }
}
