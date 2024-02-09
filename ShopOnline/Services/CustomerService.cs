using ShopOnline.Models;
using ShopOnline.Repository.Generics;
using ShopOnline.UnitOfWork;

namespace ShopOnline.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Customer>();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customers = await _repository.GetAll();
            return customers;
        }
    }
}
