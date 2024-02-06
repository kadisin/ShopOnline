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

        public override Task<int> UpdateElement(Customer element)
        {
            var customer = _context.Set<Customer>().FirstOrDefault(x => x.CustomerId == element.CustomerId);
            if (customer != null)
            {
                customer.Name = element.Name;
                customer.City = element.City;
                customer.PostalCode = element.PostalCode;
                customer.ShippingAddress = element.ShippingAddress;
                customer.Country = element.Country;

                return base.UpdateElement(customer);
            }
            else
            {
                throw new ArgumentException("Can't find customer");
            }
        }

    }
}
