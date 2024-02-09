using Microsoft.EntityFrameworkCore;
using ShopOnline.Models;

namespace ShopOnline.Database
{
    public class ShopOnlineDbContext : DbContext
    {
        public ShopOnlineDbContext(DbContextOptions<ShopOnlineDbContext> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bike> Bikes { get; set; }
    }
}
