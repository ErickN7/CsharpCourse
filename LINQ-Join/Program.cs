class Program
{
    static void Main(string[] args)
    {
        var beers = new List<Beer>()
        {
            new Beer()
            {
                Name = "Corona",
                Country = "Mexico"
            },
            new Beer()
            {
                Name = "Delirium",
                Country = "Belgica"
            },
            new Beer(){Name = "Erdinger", Country = "Alemania"},
            new Beer()
            {
                Name = "Minerva",
                Country = "Mexico"
            },
        };

        var countries = new List<Country>()
        {
            new Country()
            {
                Name = "Mexico",
                Continent = "America"
            },
            new Country()
            {
                Name = "Belgica",
                Continent = "Europa"
            },
            new Country()
            {
                Name = "Alemania",
                Continent = "Europa"
            }
        };

        var beersWithContinent = from beer in beers
                                 join country in countries
                                 on beer.Country equals country.Name
                                 select new
                                 {
                                     Name = beer.Name,
                                     Country = beer.Country,
                                     Continent = country.Continent
                                 };
        foreach(var beer in beersWithContinent)
            Console.WriteLine($"Cerverza: {beer.Name}, Pais: {beer.Country}, Continente: {beer.Continent}");
    }
}

public class Beer
{
    public string Name { get; set; }
    public string Country { get; set; }
}

public class Country
{
    public string Name { get; set; }
    public string Continent { get; set; }
}