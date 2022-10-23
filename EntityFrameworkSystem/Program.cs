using BD;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        DbContextOptionsBuilder<CsharpDBContext> optionBuilder = 
            new DbContextOptionsBuilder<CsharpDBContext>();
        optionBuilder.UseSqlServer("Server=(LocalDb)\\Demo; Database=CsharpDB; Trusted_Connection=True;");

        bool again = true;
        int op = 0;

        do
        {
            ShowMenu();
            Console.WriteLine("Elige una opcion: ");
            op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Show(optionBuilder);
                    break;
                case 2:
                    Add(optionBuilder);
                    break;
                case 3:
                    Edit(optionBuilder);
                    break;
                case 4:
                    Delete(optionBuilder);
                    break;
                case 5:
                    again = false;
                    break;
                default:
                    again = false;
                    break;
            }
        } while (again);
    }
    public static void ShowMenu()
    {
        Console.WriteLine("\n--------------Menu------------------");
        Console.WriteLine("1.- Mostrar");
        Console.WriteLine("2.- Agregar");
        Console.WriteLine("3.- Editar");
        Console.WriteLine("4.- Eliminar");
        Console.WriteLine("5.- Salir");
    }

    public static void Show(DbContextOptionsBuilder<CsharpDBContext> optionBuilder)
    {
        Console.Clear();
        Console.WriteLine("Cervezas en la base de datos: ");
        using(var dbContext = new CsharpDBContext(optionBuilder.Options))
        {
            List<Beer> beers = dbContext.Beers.OrderBy(s => s.Name).ToList();//Equivalente en EF
            List<Beer> beers2 = (from s in dbContext.Beers
                                orderby s.Name
                                select s).Include(s => s.Brand).ToList();//Equivalente en Linq
            foreach (var beer in beers)
                Console.WriteLine($"{beer.Id} - {beer.Name} - {beer.Brand.Name}");
        }
    }

    public static void Add(DbContextOptionsBuilder<CsharpDBContext> optionBuilder)
    {
        Console.Clear();
        Console.WriteLine("Agregar nueva cerveza");
        Console.WriteLine("Escribe el nombre:");
        string name = Console.ReadLine();
        Console.WriteLine("Escribe el id de la marca:");
        int brandId = int.Parse(Console.ReadLine());
        
        using(var context = new CsharpDBContext(optionBuilder.Options))
        {
            Beer beer = new Beer()
            {
                Name = name,
                BrandId = brandId
            };

            context.Add(beer);
            context.SaveChanges();
        }
    }   

    public static void Edit(DbContextOptionsBuilder<CsharpDBContext> optionBuilder)
    {
        Console.Clear();
        Show(optionBuilder);
        Console.WriteLine("Editar cerveza");
        Console.WriteLine("Escribe el id de tu cerveza a editar");
        int id = int.Parse(Console.ReadLine());

        using(var context = new CsharpDBContext(optionBuilder.Options))
        {
            Beer beer = context.Beers.Find(id);

            if(beer != null)
            {
                Console.WriteLine("Escribe el nombre: ");
                string name = Console.ReadLine();
                Console.WriteLine("Escribe el id de la marca");
                int branId = int.Parse(Console.ReadLine());
                beer.Name = name;
                beer.BrandId = branId;
                context.Entry(beer).State = EntityState.Modified;
                context.SaveChanges();
            }
            else
                Console.WriteLine("Cerveza no existe");
        }
    }

    public static void Delete(DbContextOptionsBuilder<CsharpDBContext> optionBuilder)
    {
        Console.Clear();
        Show(optionBuilder);
        Console.WriteLine("Eliminar cerveza");
        Console.WriteLine("Escribe el id de tu cerveza a eliminar");
        int id = int.Parse(Console.ReadLine());

        using (var context = new CsharpDBContext(optionBuilder.Options))
        {
            Beer beer = context.Beers.Find(id);

            if (beer != null)
            {
                context.Beers.Remove(beer);
                context.SaveChanges();
            }
            else
                Console.WriteLine("Cerveza no existe");
        }
    }
}