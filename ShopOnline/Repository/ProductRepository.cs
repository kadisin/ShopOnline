using ShopOnline.Database;
using ShopOnline.Repository.Generics;
using ShopOnline.Models;

namespace ShopOnline.Repository
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ShopOnlineDbContext context) : base(context) { }

        public override Task<Product> Update(Product entity)
        {
            var product = _context.Set<Product>().FirstOrDefault(x => x.ProductId == entity.ProductId);

            if (product != null) 
            { 
                product.Name = entity.Name;
                product.Price = entity.Price;

                return base.Update(product);
            }
            else
            {
                throw new ArgumentException("Can't find product");
            }

        }

    }
}
