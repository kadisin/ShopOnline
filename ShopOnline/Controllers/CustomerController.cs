using Microsoft.AspNetCore.Mvc;
using ShopOnline.Repository.Generics;
using ShopOnline.Models;

namespace ShopOnline.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> Index(Guid? id)
        {
            if(id == null)
            {
                var customers = _customerRepository.GetAll();
                return View(customers);
            }
            else
            {
                var customer = _customerRepository.GetById(id.Value);
                return View(new[] { customer });
            }
        }
    }
}
