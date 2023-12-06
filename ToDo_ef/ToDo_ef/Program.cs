using Pomelo.EntityFrameworkCore.MySql;

namespace ToDo_ef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Context példányosítása (ekkol létrejön a kapcsolat és a a DbSet pubélikus tulajdonság is...)
            TodoContext context = new TodoContext();

            //Ha a ConnectionString-ben leírt adatbázis nem létezne, akkor létrehozza
            //Táblanév --> DbSet neve
            //Mezők    --> publikus tulajdonságok + adattípusok  (Id --> PK)
            context.Database.EnsureCreated();
            Console.WriteLine("Todo Alkalmazás: ");

            byte menuPont;
            do
            {
                Console.Clear();
                menuPont = menu();
                Console.WriteLine();
                if (menuPont == 1)
                {
                    Todo t = new Todo();
                    Console.WriteLine("Add meg a feltölteni kívánt todo adatait");
                    Console.Write("tevékenység: ");
                    t.Tevekenyseg = Console.ReadLine();
                    Console.Write("dátum: ");
                    t.Datum = DateOnly.Parse(Console.ReadLine());
                    Console.Write("fontosság(1-5): ");
                    t.Fontossag = Convert.ToByte(Console.ReadLine());
                    Console.Write("folyamatos? (igen-nem): ");
                    t.Folyamatos = Console.ReadLine() == "igen";
                    Console.Write("elvégzett? (igen-nem): ");
                    t.Elvegzett = Console.ReadLine() == "igen";

                    context.TodoLista.Add(t);
                    context.SaveChanges();
                    Console.WriteLine("OK");
                    
                    Console.ReadLine();
                }

                if (menuPont == 2)
                {
                    foreach (Todo t in context.TodoLista)
                    {
                        todokiir(t);
                    }
                    Console.ReadLine();
                }

                if (menuPont == 3)
                {
                    Console.WriteLine("Az elvégzett tevékenységek: \n");
                    foreach (Todo t in context.TodoLista)
                    {
                        if (t.Elvegzett)
                        {
                            todokiir(t);
                        }
                    }
                    Console.ReadLine();
                }

                if (menuPont == 4)
                {
                    Console.Write("Add meg mit keresel (tevékenység): ");
                    string keresett_tev = Console.ReadLine().ToLower();
                    Console.WriteLine("Keresés...\n");
                    foreach (Todo t in context.TodoLista)
                    {
                        if (t.Tevekenyseg.ToLower().Contains(keresett_tev))
                        {
                            todokiir(t);
                        }
                    }
                    Console.ReadLine();
                }
            } while (menuPont != 5);
        }

        static void todokiir(Todo t)
        {
            Console.WriteLine($"Tevékenység Neve: {t.Tevekenyseg}\nTevékenység Dátuma: {t.Datum}\nTevékenység fontossága: {t.Fontossag}");
            if (t.Elvegzett)
            {
                Console.WriteLine("A tevékenység el lett végezve");
            }
            else
            {
                Console.WriteLine("A tevékenység nem lett el végezve");
            }
            if(t.Folyamatos)
            {
                Console.WriteLine("A tevékenység folyamatos");
            }
            else
            {
                Console.WriteLine("A tevékenység nem folyamatos");
            }
            Console.WriteLine();
        }

        static byte menu()
        {

            string[] menuElemek = new string[]
            {   "Új tevékenység rögzítése",
                "Tevékenységek listája",
                "Elvégzett tevékenységek",
                "Tevékenység-kereső",
                "Kilépés"};
            for (byte k = 0; k < menuElemek.Length; k++)
                Console.WriteLine($"{k + 1}. {menuElemek[k]}");
            Console.Write("\nVálassz a fenti lehetőségek közül: ");
            return byte.Parse(Console.ReadLine());

        }
    }
}