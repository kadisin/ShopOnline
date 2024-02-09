using ShopOnline.Models;
using ShopOnline.Repository.Generics;
using ShopOnline.UnitOfWork;

namespace ShopOnline.Services
{
    public class BikeService : IBikeService
    {
        private readonly IRepository<Bike> _bikeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Customer> _customerRepository;

        public BikeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _bikeRepository = _unitOfWork.GetRepository<Bike>();
            _customerRepository = _unitOfWork.GetRepository<Customer>();
        }

        public async Task<Bike> AddBikeAsync(Bike bike)
        {
            return await _bikeRepository.Add(bike);
        }

        public async Task<IEnumerable<Bike>> GetAllAsync()
        {
            var bikes = await _bikeRepository.GetAll();
            var customers = await _customerRepository.GetAll();

            foreach(var bike in bikes )
            {
                var customer = customers.FirstOrDefault(x => x.CustomerId == bike.CustomerId);
                if(customer != null)
                {
                    bike.Customer = customer;
                    bike.CustomerId = customer.CustomerId;
                }
            }
            return bikes;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            var customers = await _customerRepository.GetAll();
            return customers;
        }
    }
}
