using System;
using Infrastructure.Services;

class Program
{
    static void Main(string[] args)
    {
        // Skapar en instans av productService
        var service = new ProductService();
        // Namnger filvägen
        string filePath = "products.json";

        // Hämtar produkterna från json filen på filvägen
        service.LoadFromJson(filePath);
       
        bool running = true;
        // sÅ länge running är true, så körs loopen 
        while (running)
        {
            Console.WriteLine("\n Meny ");
            Console.WriteLine("1. Lägg till produkt");
            Console.WriteLine("2. Visa alla produkter");
            Console.WriteLine("3. Spara till fil");
            Console.WriteLine("4. Avsluta");
            Console.Write("Välj ett alternativ: ");

            // sparar användarens inmatnnig till textsträngen
            string choice = Console.ReadLine();
            // 
            switch (choice)

            {
                case "1":
                    Console.Write("Ange produktens namn: ");
                    string name = Console.ReadLine();

                    
                    Console.Write("Ange produktens pris: ");
                    // // Kontrollerar att användaren skrev in ett giltigt pris (decimalvärde)
                    if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        // Avbryter om priset inte är giltigt
                        Console.WriteLine("Ogiltigt pris!");
                        break; 
                    }
                    //  Skickar in båda argumenten
                    service.AddProduct(name!, price); 
                    Console.WriteLine(" Produkt tillagd!");
                    break;

                case "2":
                    service.GetProducts();
                    break;
                case "3":
                    service.SaveToJson(filePath);
                    break;
                case "4":
                    service.SaveToJson(filePath);
                    running = false;
                    Console.WriteLine("Avslutar programmet...");
                    break;
                default:
                    Console.WriteLine(" 1,2,3,4");
                    break;

            }
        }
    }
}

