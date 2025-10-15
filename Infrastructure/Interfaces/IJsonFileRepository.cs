using System.Collections.Generic;
using Infrastructure.Models;

namespace Infrastructure.Interfaces
{
    // Ett interface säger vilka metoder som måste finnas i en klass
    public interface IJsonFileRepository
    {
        // Sparar produkter filen
        void SaveToFile(List<Product> products, string filePath);

        // Läser in produkter från en JSON-fil och skickar tillbaka listan
        List<Product> LoadFromFile(string filePath);
    }
}
