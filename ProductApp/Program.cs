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

        //  Kolla om filen finns innan du försöker ladda
        if (File.Exists(filePath))
            service.LoadFromJson(filePath);
        else
            Console.WriteLine("Ingen sparad fil hittades. En fil skapas när du sparar.");

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
            // använder menyvalet och fallet utspelas.
            switch (choice)

            {
                case "1":
                    Console.Clear();
                    Console.Write("Ange produktens namn: ");
                    string name = Console.ReadLine();

                    if (string.IsNullOrEmpty(name) || name.Any(char.IsDigit))
                    {
                        Console.WriteLine("Ogiltigt namn");
                        break;
                    }
                    Console.Write("Ange produktens pris: ");
                    // Kontrollerar att användaren skrev in ett giltigt pris (decimalvärde)
                    if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        // Avbryter om priset inte är giltigt
                        Console.WriteLine("Ogiltigt pris!");
                        break; 
                    }
                    //  Skickar in båda argumenten
                    service.AddProduct(name, price); 
                    Console.WriteLine(" Produkt tillagd!");
                    break;

                case "2":
                    Console.Clear();
                    var list = service.GetProducts();

                    if (list.Count == 0)
                    {
                        Console.WriteLine("Inga produkter.");
                    }
                    else
                    {
                        Console.WriteLine("\n--- Alla produkter ---");
                        foreach (var it in list)
                            Console.WriteLine($"{it.Id} | {it.Name} | {it.Price} kr");
                    }
                    break;
                case "3":
                    Console.Clear();
                    service.SaveToJson(filePath);
                    break;
                case "4":
                    Console.Clear();
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

