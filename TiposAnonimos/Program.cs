class Program
{
    static void Main(string[] args)
    {
        var h = new
        {
            Name = "Ana",
            Country = "Italia"
        };

        Console.WriteLine($"{h.Name} {h.Country}");

        var beeres = new[]
        {
            new { Name = "Red", Brand ="Delirium" },
            new { Name = "London Porter", Brand = "Fullers"}
        };

        foreach(var b in beeres)
        {
            Console.WriteLine($"Mi cerveza {b.Name} y la marca es {b.Brand}");
        }
    }
}