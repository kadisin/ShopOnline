using Microsoft.EntityFrameworkCore;
using ShopOnline.Database;
using ShopOnline.Models;
using ShopOnline.Repository.Generics;

namespace ShopOnline.Repository
{
    public class BikeRepository : Repository<Bike>
    {
        public BikeRepository(ShopOnlineDbContext context) : base(context)
        { }

        public override async Task<Bike> Update(Bike entity)
        {
            var bike = await _context.Set<Bike>().FirstOrDefaultAsync(x => x.BikeId == entity.BikeId);
            if(bike != null)
            {
                bike.Name = entity.Name;
                bike.Description= entity.Description;
                
                return await base.Update(bike);
            }
            else
            {
                throw new ArgumentException("Can't find bike");
            }    
        }

    }
}
