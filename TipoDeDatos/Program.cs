public class Program
{
    static void Main(string[] args)
    {
        int a = 1;
        int b = 3;
        Show();
        Sum(4,5);
        int m = Mul(2,3);
        Console.WriteLine(m);
    }

    static int Mul(int num1, int num2)
    {
        return num1 * num2;
    }

    static void Sum(int num1, int num2)
    {
        int num3 = num1 + num2;
        Console.WriteLine(num3);
    }

    static void Show()
    {
        Console.WriteLine("Hola mundo");
    }
}