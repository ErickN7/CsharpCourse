class Program
{
    static void Main(string[] args)
    {
        People people1 = new People() 
        {
            Name = "Erick",
            Age = 27
        };
        People people2 = new People()
        {
            Name = "Erick",
            Age = 27
        };

        Console.WriteLine(People.Count);
        Console.WriteLine(People.GetCount());
    }

    public class People
    {
        public static int Count = 0;
        public string Name { get; set; }
        public int Age { get; set; }

        public People()
        {
            Count++;
        }

        public static string GetCount()
        {
            return $"Esta clase se ha utilizado {Count} veces";
        }
    }
}