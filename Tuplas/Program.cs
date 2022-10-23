class Program
{
    static void Main(string[] args)
    {
        (int id, string name) product = (1, "cerveza stout");
        Console.WriteLine($"{product.id} - {product.name}");
        product.name = "cerveza porter";
        Console.WriteLine($"{product.id} - {product.name}");

        var person1 = (1, "Hola");
        Console.WriteLine($"{person1.Item1} - {person1.Item2}");

        var people = new[]
        {
            (1, "Juan"),
            (2, "Marcos")
        };

        foreach(var person in people)
        {
            Console.WriteLine($"{person.Item1} - {person.Item2}");
        }

        (int id, string name)[] people2 = new[]
        {
            (1, "Juan"),
            (2, "Marcos")
        };

        foreach (var person in people2)
        {
            Console.WriteLine($"{person.id} - {person.name}");
        }

        var location = getLocationCDMX();
        Console.WriteLine($"lat: {location.lat} - long: {location.lng} - nombre: {location.name}");

        var (_, lng, _) = getLocationCDMX();
        Console.WriteLine( $"{lng}");
    }

    public static (float lat, float lng, string name) getLocationCDMX()
    {
        float lat = 19.1212f;
        float lng = -9.39848f;
        string name = "CDMX";

        return (lat, lng, name);
    }
}