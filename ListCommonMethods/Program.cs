class Program
{
    static void Main(string[] args)
    {
        var numbers = new List<int>()
        {
            4,5,7,2
        };

        Show(numbers);
        numbers.Insert(1, 10);
        Show(numbers);

        if(numbers.Contains(7))
            Console.WriteLine("Existe");
        else
            Console.WriteLine("No existe");

        int pos = numbers.IndexOf(17);
        Console.WriteLine(pos);

        numbers.Sort();
        Show(numbers);

        string name = "Hola";
        name = name.ToUpper();
        Console.WriteLine(name);

        numbers.AddRange(new List<int>() { 84, 95, 230 });
        Show(numbers);


    }

    public static void Show(List<int> numbers)
    {
        Console.WriteLine("-- Numeros --");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}