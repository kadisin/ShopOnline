using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopOnline.Models;
using ShopOnline.Repository.Generics;
using ShopOnline.Services;
using ShopOnline.ViewModels;

namespace ShopOnline.Controllers
{
    public class BikeController : Controller
    {
        private IBikeService _bikeService;

        public BikeController(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        public async Task<IActionResult> Index()
        {
            var bikes = await _bikeService.GetAllAsync();
            return View(bikes);
        }

        public async Task<IActionResult> Add()
        {
            try
            {
                IEnumerable<Customer> allCustomers = await _bikeService.GetCustomersAsync();
                IEnumerable<SelectListItem> selectListItems = new SelectList(allCustomers, "CustomerId", "Name", null);

                AddBikeViewModel addBikeViewModel = new() { Customers = selectListItems };
                return View(addBikeViewModel);
            }
            catch(Exception ex)
            {
                ViewData["ErrorMessage"] = $"There was an error: {ex.Message}";
            }
            return View(new AddBikeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBikeViewModel addBikeViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Bike bike = new()
                    {
                        Name = addBikeViewModel.Bike.Name,
                        Description = addBikeViewModel.Bike.Description,
                        CustomerId = addBikeViewModel.Bike.CustomerId
                    };
                    var result = await _bikeService.AddBikeAsync(bike);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", $"Adding bike failed, error: {ex.Message}");
            }

            IEnumerable<Customer> allCustomers = await _bikeService.GetCustomersAsync();
            IEnumerable<SelectListItem> selectListItems = new SelectList(allCustomers, "CustomerId", "Name", null);

            AddBikeViewModel model = new() { Customers = selectListItems };
            return View(model);
        }
    }
}
