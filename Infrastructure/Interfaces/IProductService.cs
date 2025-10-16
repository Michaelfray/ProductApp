

using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    // Lägger till en produkt
    Product AddProduct(string name, decimal price);

    // Hämtar alla produkter
    List<Product> GetProducts();

    // Sparar alla produkter till JSON-fil
    void SaveToJson(string path = "products.json");

    // Läser in produkter från JSON-fil
    void LoadFromJson(string path = "products.json");

}
