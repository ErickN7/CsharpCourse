using System.Data.SqlClient;

namespace BaseDeDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BeerDB beerDB = new BeerDB(@"(LocalDb)\Demo", "CsharpDB", "test2", "123456");
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
                            Show(beerDB);
                            break;
                        case 2:
                            Add(beerDB);
                            break;
                        case 3:
                            Edit(beerDB);
                            break;
                        case 4:
                            Delete(beerDB);
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
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
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

        public static void Show(BeerDB beerDB)
        {
            Console.Clear();
            Console.WriteLine("Cervezas de la base de datos");
            List<Beer> beers = beerDB.GetAll();
            foreach (var beer in beers)
                Console.WriteLine($"Id: {beer.Id}, Name: {beer.Name}");
        }

        public static void Add(BeerDB beerDB)
        {
            Console.Clear();
            Console.WriteLine("Agregar nueva cerveza");
            Console.WriteLine("Escribe el nombre: ");
            string name = Console.ReadLine();
            Console.WriteLine("Escribe el id de la marca: ");
            int brandId = int.Parse(Console.ReadLine());
            beerDB.Add(new Beer(name, brandId));
        }

        public static void Edit(BeerDB beerDB)
        {
            Console.Clear();
            Show(beerDB);
            Console.WriteLine("Editar cerveza");
            Console.WriteLine("Escribe el Id de tu cerveza a editar: ");
            int id = int.Parse(Console.ReadLine());
            Beer beer = beerDB.Get(id);

            if (beer != null)
            {
                Console.WriteLine("Escribe el nombre: ");
                string name = Console.ReadLine();
                Console.WriteLine("Escribe el id de la marca: ");
                int brandId = int.Parse(Console.ReadLine());
                beer.Name = name;
                beer.BrandId = brandId;
                beerDB.Edit(beer);
            }
            else
                Console.WriteLine("La cerveza no existe");
        }

        public static void Delete(BeerDB beerDB)
        {
            Console.Clear();
            Show(beerDB);
            Console.WriteLine("Eliminar cerveza");
            Console.WriteLine("Escribe el Id de tu cerveza a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            Beer beer = beerDB.Get(id);

            if (beer != null)
                beerDB.Delete(id);
            else
                Console.WriteLine("La cerveza no existe");
        }
    } 
}