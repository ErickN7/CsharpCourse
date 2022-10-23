class Program
{
    static void Main(string[] args)
    {
        Shark[] sharks = new Shark[]
        {
            new Shark("Tiburonzin", 56),
            new Shark("Jaws", 65)
        };

        ShowFish(sharks);
        ShowAnimals(sharks);

        IFish[] fishs = new IFish[]
        {
            new Siren(120),
            new Shark("Tiburon", 70)
        };

        ShowFish(fishs);
    }

    public static void ShowFish(IFish[] fishs)
    {
        Console.WriteLine("--Mostrar los peces--");
        int i = 0;

        while(fishs.Length > i)
        {
            Console.WriteLine(fishs[i].Swim());
            i++;
        }
    }

    public static void ShowAnimals(IAnimal[] animals)
    {
        Console.WriteLine("--Mostrar los animales--");
        int i = 0;

        while (animals.Length > i)
        {
            Console.WriteLine(animals[i].Name);
            i++;
        }
    }
}

public class Shark: IAnimal, IFish
{
    public Shark(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    public string Name { get; set; }
    public int Speed { get; set; }
    public string Swim()
    {
        return $"{Name} nada {Speed} km/h";
    }
}

public class Siren : IFish
{
    public Siren(int speed)
    {
        Speed = speed;
    }

    public int Speed { get; set; }
    public string Swim()
    {
        return $"La sirena nada {Speed}";
    }
}

public interface IAnimal
{
    public string Name { get; set; }
}

public interface IFish
{
    public int Speed { get; set; }
    public string Swim();
}