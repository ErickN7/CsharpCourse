using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Beer myBeer = new Beer
        {
            Name = "Pikantus",
            Brand = "Erdinger"
        };

        string json = "{ \"Name\": \"Pikantus\", \"Brand\": \"Erdinger\"  }";

        string jsonMyBeer = JsonSerializer.Serialize(myBeer);//convertir a string de un objeto
        Beer myBeerObject = JsonSerializer.Deserialize<Beer>(json);//convertir a objeto de un string

        Beer[] beers = new Beer[]
        {
            new Beer()
            {Name = "Pikantus",
            Brand = "Erdinger" },
            new Beer()
            {Name = "Corona",
            Brand = "Modelo" }
        };

        string json2 = "[{ \"Name\": \"Pikantus\", \"Brand\": \"Erdinger\"  },{ \"Name\": \"Corona\", \"Brand\": \"Modelo\"  }]";
        string jsonBeers = JsonSerializer.Serialize(beers);
        Beer[] beersObject = JsonSerializer.Deserialize<Beer[]>(json2);//convertir a objeto de un string

    }

    public class Beer
    {
        public string Name { get; set; }
        public string Brand { get; set; }
    }
}

