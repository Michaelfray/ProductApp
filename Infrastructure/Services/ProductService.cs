using Infrastructure.Models;
using System.Text.Json;
using System.IO;


namespace Infrastructure.Services
{
    // Hanterar all logik kring produkter
    public class ProductService
    {
        // Lista där alla produkter lagras
        private List<Product> _products = new List<Product>();

        // Lägger till en ny produkt i listan
        public Product AddProduct(string name, decimal price)
        {
            // Skapa en ny produkt med unikt ID
            var p = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Price = price
            };

            // Lägg till produkten i listan
            _products.Add(p);


            return p;
        }

        // Ny metod för och hämta alla produkter 

        public List<Product> GetProducts()
        {

            return _products;

        }



       }
}
