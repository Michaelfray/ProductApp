using System;
using Infrastructure.Services;

class Program
{
    static void Main(string[] args)
    {
        var service = new ProductService();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1) Lägg till produkt  2) Visa alla  0) Avsluta");
            Console.Write("> ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Namn: ");
                var name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Ogiltigt namn.");
                    continue;
                }

                Console.Write("Pris: ");
                if (!decimal.TryParse(Console.ReadLine(), out var price))
                {
                    Console.WriteLine("Ogiltigt pris.");
                    continue;
                }

                var p = service.AddProduct(name, price);
                Console.WriteLine($"Tillagd: {p.Id} | {p.Name} | {p.Price} kr");
            }
            else if (choice == "2")
            {
                var products = service.GetProducts();
                if (products.Count == 0)
                {
                   Console.WriteLine("Inga produkter ännu.");
                
                
                    continue;
                }

                Console.WriteLine("\n--- Alla produkter ---");
                foreach (var p in products)
                    Console.WriteLine($"{p.Id} | {p.Name} | {p.Price} kr");
            }
            else if (choice == "0")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Välj 1, 2 eller 0.");
            }
        }
    }
}
