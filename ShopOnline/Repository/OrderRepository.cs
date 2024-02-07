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

        public override async Task<IEnumerable<Order>> GetWithFilter(Expression<Func<Order, bool>> predicate)
        {
            return await _context.Set<Order>().Include(o => o.LineItems).ThenInclude(p => p.Product).Where(predicate).ToListAsync();
        }

        public override Task<Order> Update(Order entity)
        {
            var order = _context.Set<Order>().Include(o => o.LineItems).ThenInclude(l => l.Product).FirstOrDefault(o => o.OrderId == entity.OrderId);
            if(order != null)
            {
                order.OrderDate = entity.OrderDate;
                order.LineItems = entity.LineItems;

                return base.Update(order);
            }
            else
            {
                throw new ArgumentException("Can't found order");
            }
    }
    }
}
