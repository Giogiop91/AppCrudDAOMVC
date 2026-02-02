using AppCrudDAOMVC.Data;
using AppCrudDAOMVC.Models;

namespace AppCrudDAOMVC.Controllers
{
   
    public class ProductController
    {
        private readonly ProductDAO _dao = new();

        public void CreateProduct()
        {
            Console.Write("Nome prodotto: ");
            string name = Console.ReadLine();

            Console.Write("Prezzo: ");
            decimal price = decimal.Parse(Console.ReadLine());

            _dao.Insert(new Product { Name = name, Price = price });
            Console.WriteLine("Prodotto inserito.");
        }

        public void ListProducts()
        {
            var list = _dao.GetAll();

            foreach (var p in list)
                Console.WriteLine($"{p.ProductId} | {p.Name} | {p.Price} | {p.CreatedAt}");
        }
    }
}
