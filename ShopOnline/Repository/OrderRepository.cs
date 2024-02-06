using Microsoft.EntityFrameworkCore;
using ShopOnline.Database;
using ShopOnline.Repository.Generics;
using System.Linq.Expressions;
using ShopOnline.Models;

namespace ShopOnline.Repository
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(ShopOnlineDbContext context) : base(context) 
        { }

        public override async Task<IEnumerable<Order>> GetElementsWithFilter(Expression<Func<Order, bool>> predicate)
        {
            return await _context.Set<Order>().Include(o => o.LineItems).ThenInclude(p => p.Product).Where(predicate).ToListAsync();
        }

        public override Task<int> UpdateElement(Order element)
        {
            var order = _context.Set<Order>().Include(o => o.LineItems).ThenInclude(l => l.Product).FirstOrDefault(o => o.OrderId == element.OrderId);
            if(order != null)
            {
                order.OrderDate = element.OrderDate;
                order.LineItems = element.LineItems;

                return base.UpdateElement(order);
            }
            else
            {
                throw new ArgumentException("Can't found order");
            }
    }
    }
}
