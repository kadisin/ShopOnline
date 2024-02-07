using ShopOnline.Models;

namespace ShopOnline.Database
{
    public static class DbInitializer
    {
        public static void Seed(ShopOnlineDbContext context)
        {
            var customers = new Customer[]
            {
                new Customer { Name = "Tomasz", City = "Wroclaw", Country = "Polska", PostalCode = "12345", ShippingAddress = "Adres" },
                new Customer { Name = "Marcin", City = "Poznan", Country = "Polska", PostalCode = "12345", ShippingAddress = "Polska" },
                new Customer { Name = "Krzysztof", City = "Szczecin", Country = "Polska", PostalCode = "22345", ShippingAddress = "Polska" },
                new Customer { Name = "Arek", City = "Wroclaw", Country = "Polska", PostalCode = "65221", ShippingAddress = "Adres" },
                new Customer { Name = "Mateusz", City = "Radom", Country = "Polska", PostalCode = "34678", ShippingAddress = "Adres" }

            };
            if (!context.Set<Customer>().Any())
            {
                context.AddRange(customers);
            }

            var products = new Product[]
            {
                new Product { Name = "Buty", Price = 10 },
                new Product { Name = "Parasol", Price = 250 },
                new Product { Name = "Kubek", Price = 30 },
                new Product { Name = "Dlugopis", Price = 110 },
                new Product { Name = "Klawiatura", Price = 19 },
            };
           // if (!context.Set<Product>().Any()) 
            ////{ 
                context.AddRange(products);
            //}
        }

    }
}
