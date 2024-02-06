using Microsoft.AspNetCore.Mvc;
using ShopOnline.Database;
using ShopOnline.Repository.Generics;
using ShopOnline.ViewModels;
using ShopOnline.Models;

namespace ShopOnline.Controllers
{
    public class OrderController : Controller
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;

        public OrderController(IRepository<Order> orderRepository, IRepository<Product> productRepository) 
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetElementsWithFilter(order => order.OrderDate > DateTime.UtcNow.AddDays(-5));
            return View(orders);
        }

        public async Task<IActionResult> Create()
        {
            var products = await _productRepository.GetAll();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateViewModel model)
        {
            if(!model.LineItems.Any())
            {
                return BadRequest("Please submit line items");
            }
            if(string.IsNullOrWhiteSpace(model.Customer.Name))
            {
                return BadRequest("Customer needs a name");
            }


            var customer = new Customer
            {
                Name = model.Customer.Name,
                ShippingAddress = model.Customer.ShippingAddress,
                City = model.Customer.City,
                PostalCode = model.Customer.PostalCode,
                Country = model.Customer.Country
            };

            var order = new Order
            {
                LineItems = model.LineItems
                .Select(line => new LineItem
                {
                    ProductId = line.ProductId,
                    Quantity = line.Quantity
                }).ToList(),
                Customer = customer
            };

            await _orderRepository.AddElement(order);
            return Ok("Order created");
        }


    }
}
