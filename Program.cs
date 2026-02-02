using AppCrudDAOMVC.Controllers;

namespace AppCrudDAOMVC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserController users = new();
            ProductController products = new();
            OrderController orders = new();

            while (true)
            {
                Console.WriteLine("\n--- MENU PRINCIPALE ---");
                Console.WriteLine("1. Gestione Utenti");
                Console.WriteLine("2. Gestione Prodotti");
                Console.WriteLine("3. Gestione Ordini");
                Console.WriteLine("0. Esci");
                Console.Write("Scelta: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        MenuUsers(users);
                        break;
                    case "2":
                        MenuProducts(products);
                        break;
                    case "3":
                        MenuOrders(orders);
                        break;
                    case "0":
                        return;
                }
            }

            static void MenuUsers(UserController c)
            {
                Console.WriteLine("\n1. Inserisci utente");
                Console.WriteLine("2. Lista utenti");
                Console.WriteLine("3. Aggiorna utente");
                Console.WriteLine("4. Elimina utente");
                Console.Write("Scelta: ");

                switch (Console.ReadLine())
                {
                    case "1": c.CreateUser(); break;
                    case "2": c.ListUsers(); break;
                    case "3": c.UpdateUser(); break;
                    case "4": c.DeleteUser(); break;
                }
            }

            static void MenuProducts(ProductController c)
            {
                Console.WriteLine("\n1. Inserisci prodotto");
                Console.WriteLine("2. Lista prodotti");
                Console.Write("Scelta: ");

                switch (Console.ReadLine())
                {
                    case "1": c.CreateProduct(); break;
                    case "2": c.ListProducts(); break;
                }
            }

            static void MenuOrders(OrderController c)
            {
                Console.WriteLine("\n1. Inserisci ordine");
                Console.WriteLine("2. Lista ordini");
                Console.Write("Scelta: ");

                switch (Console.ReadLine())
                {
                    case "1": c.CreateOrder(); break;
                    case "2": c.ListOrders(); break;
                }
            }


        }
    }
}
