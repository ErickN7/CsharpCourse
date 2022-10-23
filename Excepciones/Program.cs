class Program
{
    static void Main(string[] args)
    {
		try
		{
			string content = File.ReadAllText(@"C:\Users\DEV-005\Documents\test.txt");
			Console.WriteLine(content);

			//string content2 = File.ReadAllText(@"C:\Users\DEV-005\Documents\test2.txt");
			//Console.WriteLine(content2);
			throw new Exception("Ocurrio algo raro");
		}
		catch (FileNotFoundException e)
		{
			Console.WriteLine("El archivo no existe");
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
		finally
		{
			Console.WriteLine("Aqui se ejecuta");
		}
    }
}