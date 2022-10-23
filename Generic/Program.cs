class Program
{
    static void Main(string[] args)
    {
        MyList<int> numbers = new MyList<int>(10);
        numbers.Add(10);
        numbers.Add(4);
        Console.WriteLine(numbers.GetElement(11));

        Console.WriteLine(numbers.GetString());

        MyList<string> words = new MyList<string>(4);
        words.Add("Hola");
        words.Add("mundo");
        Console.WriteLine(words.GetElement(1));
        Console.WriteLine(words.GetString());

        MyList<People> people = new MyList<People>(2);
        people.Add(new People() { Name = "HOla", Country = "MUndo" });
        people.Add(new People() { Name = "HOla2", Country = "MUndo2" });
        Console.WriteLine(people.GetString());
    }
}

public class People
{
    public string Name { get; set; }
    public string Country { get; set; }

    public override string ToString()
    {
        return $"Nombre: {Name}, Pais: {Country}";
    }
}

public class MyList<T>
{
    private T[] _elements;
    private int _index = 0;

    public MyList(int n)
    {
        _elements = new T[n];
    }

    public void Add(T e)
    {
        if(_elements.Length > _index)
        {
            _elements[_index] = e;
            _index++;
        }
    }

    public T GetElement(int i)
    {
        if(_elements.Length > i && i >= 0)
        {
            return _elements[i];
        }

        return default(T);//Regresa dependiendo del tipo el valor por defecto, int = 0, string = "",etc
    }

    public string GetString()
    {
        int i = 0;
        string result = "";

        while (i < _index)
        {
            result += _elements[i].ToString() + "|";
            i++;
        }

        return result;
    }
}