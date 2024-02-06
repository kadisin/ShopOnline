using ShopOnline.Database;
using ShopOnline.Repository.Generics;
using ShopOnline.Models;

namespace ShopOnline.Repository
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ShopOnlineDbContext context) : base(context) { }

        public override Task<int> UpdateElement(Product element)
        {
            var product = _context.Set<Product>().FirstOrDefault(x => x.ProductId == element.ProductId);

            if (product != null) 
            { 
                product.Name = element.Name;
                product.Price = element.Price;

                return base.UpdateElement(product);
            }
            else
            {
                throw new ArgumentException("Can't find product");
            }

        }

    }
}
