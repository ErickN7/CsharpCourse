Operation mySum = Functions.Suma;
//Console.WriteLine(mySum(4, 5));
mySum = Functions.Mul;
//Console.WriteLine(mySum(4,5));

Show cw = Console.WriteLine;
cw += Functions.ConsoleShow;
//cw("Hola mundo");
//Functions.Some("Mario", "Bros", cw);

#region Action
//RECIBE CUALQUIER PARAMETRO PERO NO REGRESA NADA
string hi = "Hola";
Action<string> showMessage = Console.WriteLine;
Action<string, string> showMessage2 = (a, b) =>
{
    Console.WriteLine($"{hi} {a} {b}");
};
showMessage2("Mario", "Luigi");

Action<string, string, string> showMessage3 = (a, b, c) => Console.WriteLine($"{hi} {a} {b} {c}");
showMessage3("Mario", "Luigi", "Peach");

//Functions.SomeAction("Luigi", "Bros", (a) => {
//    Console.WriteLine($"Soy una expresion labmda {a}");
//});

//showMessage("hola");
//Functions.SomeAction("Luigi", "Bros", showMessage);

#endregion

#region Func 
//REGRESA SIEMPRE CUALQUIER COSA Y PUEDE O NO RECIBIR PARAMETROS

Func<int> numberRandom = () => new Random().Next(0,100);
//Console.WriteLine(numberRandom());
Func<int, int> numberRandomLimit = (limit) => new Random().Next(0, limit);
//Console.WriteLine(numberRandomLimit(10));
#endregion

#region Predicate
//REGRESA SIEMPRE UN TRUE/FALSE Y SOLO PUEDE RECIBIR UN PARAMETRO

Predicate<string> predicate = (a) => a.Contains(" ") || a.ToUpper().Contains("A");
Console.WriteLine(predicate("Hola mundo"));

var words = new List<string>()
{
    "beer",
    "patito",
    "sandia",
    "hola mundo",
    "c#"
};

var wordsNew = words.FindAll(predicate);
foreach(var word in wordsNew)
    Console.WriteLine(word);

#endregion

#region Delegados
delegate int Operation(int a, int b);
public delegate void Show(string message); 
#endregion

public class Functions
{
    public static int Suma(int x, int y) => x + y;
    public static int Mul(int num1, int num2) => num1 * num2;
    public static void ConsoleShow(string m) => Console.WriteLine(m.ToUpper()); 
    public static void Some(string name, string lastName, Show show)
    {
        Console.WriteLine("Hago algo al inicio");
        show($"{name} {lastName}");
        Console.WriteLine("Hago algo al final");
    }

    public static void SomeAction(string name, string lastName, Action<string> show)
    {
        Console.WriteLine("Hago algo al inicio");
        show($"{name} {lastName}");
        Console.WriteLine("Hago algo al final");
    }
}