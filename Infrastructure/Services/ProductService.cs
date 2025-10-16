using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Infrastructure.Interfaces;




namespace Infrastructure.Services
{
    // Hanterar all logik kring produkterr
    public class ProductService
    {
        // Lista där alla produkter lagras
        private List<Product> _products = new List<Product>();
        private readonly IJsonFileRepository _repo = new JsonFileRepository();


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

        public void SaveToJson(string path = "products.json")
        {

            _products = _repo.LoadFromFile(path);

        }
        public void LoadFromJson(string path = "products.json")
        {
            _products = _repo.LoadFromFile(path);
        }
            
    }

}

