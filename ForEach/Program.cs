using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var numbers = new List<int> { 1, 2, 3 };
        
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }

        var students = new List<People>()
        {
            new People(){ Name = "Hector", Country = "Mexico"},
            new People(){ Name = "Luis", Country = "Italia"},
            new People(){ Name = "Mario", Country = "China"}
        };

        static void Show(List<People> students)
        {
            Console.WriteLine("-- Personas --");

            foreach(var student in students)
            {
                Console.WriteLine($"Nombre: {student.Name}, Pais: {student.Country}");
            }
        }

        Show(students);
        students.RemoveAt(1);
        Show(students);
    }
}

class People
{
    public string Name { get; set; }
    public string Country { get; set; }
}