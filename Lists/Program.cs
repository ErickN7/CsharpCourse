using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        numbers.Add(5);
        numbers.Add(7);
        Console.WriteLine(numbers.Count);

        List<int> numbers2 = new List<int>()
        {
            3,4,6,7
        };
        Console.WriteLine(numbers2.Count);
        numbers2.Clear();
        numbers2.Add(44);
        Console.WriteLine(numbers2.Count);

        List<string> countries = new List<string>()
        {
            "Mexico","Argentina","Colombia"
        };

        Console.WriteLine(countries.Count);
    }
}