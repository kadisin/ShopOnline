using ShopOnline.Database;
using ShopOnline.Repository.Generics;
using ShopOnline.Models;

namespace ShopOnline.Repository
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(ShopOnlineDbContext context) : base(context) 
        { 
        }

        public override Task<Customer> Update(Customer entity)
        {
            var customer = _context.Set<Customer>().FirstOrDefault(x => x.CustomerId == entity.CustomerId);
            if (customer != null)
            {
                customer.Name = entity.Name;
                customer.City = entity.City;
                customer.PostalCode = entity.PostalCode;
                customer.ShippingAddress = entity.ShippingAddress;
                customer.Country = entity.Country;

                return base.Update(customer);
            }
            else
            {
                throw new ArgumentException("Can't find customer");
            }
        }

    }
}
