using Infrastructure.Interfaces;
using Infrastructure.Models;
using System.Text.Json;

namespace Infrastructure.Repositories;

public class JsonFileRepository : IJsonFileRepository
{

    public void SaveToFile(List<Product> products, string filePath)
    {
        // -json serializere = Gör .NET objekt till json format/innehåll
        // json deserialiazer = Gör json innehållet till NET. objekt
        // Du gör om en produktlista till json innehåll och
        // detta sparas till json variabeln.
        var json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });

        // Skriver JSON-text till filen som ligger i filepath alltså filvägen
        File.WriteAllText(filePath, json);

        // När JsonTexten skrivits till filen så skrivs detta ut 
        Console.WriteLine("Produkter sparade till filen.");
    }
    // returnerar en produktLista utifrån filvägen
    public List<Product> LoadFromFile(string filePath)
    {
        // Om inte filen finns på filvägen 
        if (!File.Exists(filePath))
        {
            // så skrivs detta ut och en tom lista returneras
            return new List<Product>();
        }

        // Läser texten ifrån json och innehålet sparas i variabeln som kallas Json

        var json = File.ReadAllText(filePath);

        // detta returnerar en produktlista från json och listan heter products
        var products = JsonSerializer.Deserialize<List<Product>>(json);
        

        // returnerar produktlistan, om listan är null så skapas en tom lista
        return products ?? new List<Product>();

    }
}


     