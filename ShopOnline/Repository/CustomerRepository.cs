using ShopOnline.Database;
using ShopOnline.Repository.Generics;
using ShopOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopOnline.Repository
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(ShopOnlineDbContext context) : base(context) 
        { 
        }

        public override async Task<Customer> Update(Customer entity)
        {
            var customer = await _context.Set<Customer>().FirstOrDefaultAsync(x => x.CustomerId == entity.CustomerId);
            if (customer != null)
            {
                customer.Name = entity.Name;
                customer.City = entity.City;
                customer.PostalCode = entity.PostalCode;
                customer.ShippingAddress = entity.ShippingAddress;
                customer.Country = entity.Country;

                return await base.Update(customer);
            }
            else
            {
                throw new ArgumentException("Can't find customer");
            }
        }

    }
}
