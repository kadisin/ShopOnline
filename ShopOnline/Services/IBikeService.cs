using ShopOnline.Models;

namespace ShopOnline.Services
{
    public interface IBikeService : IService<Bike>
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Bike> AddBikeAsync(Bike bike);
    }
}
