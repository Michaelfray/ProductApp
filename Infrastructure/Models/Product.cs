namespace Infrastructure.Models;


public class Product
{

    public string Id { get; set; } = null!;      // Unikt ID
    public string Name { get; set; } = null!;    // Namn på produkten, t.ex. "Nike Mercurial"
    public string Brand { get; set; } = null!;   // Märke, t.ex. "Nike"
    public string Sport { get; set; } = null!;   // Vilken sport, t.ex. "Fotboll"
    public string Size { get; set; } = null!;    // Storlek, t.ex. "42"
    public decimal Price { get; set; }           // Pris
    public int StockQuantity { get; set; }       // Antal i lager

}


