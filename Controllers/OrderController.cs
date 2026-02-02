using AppCrudDAOMVC.Data;
using AppCrudDAOMVC.Models;

namespace AppCrudDAOMVC.Controllers
{
    
    public class OrderController
    {
        private readonly OrderDAO _dao = new();

        public void CreateOrder()
        {
            Console.Write("UserId: ");
            int userId = int.Parse(Console.ReadLine());

            Console.Write("ProductId: ");
            int productId = int.Parse(Console.ReadLine());

            Console.Write("Quantità: ");
            int qty = int.Parse(Console.ReadLine());

            _dao.Insert(new Order
            {
                UserId = userId,
                ProductId = productId,
                Quantity = qty
            });

            Console.WriteLine("Ordine inserito.");
        }

        public void ListOrders()
        {
            var list = _dao.GetAll();

            foreach (var o in list)
                Console.WriteLine($"{o.OrderId} | User {o.UserId} | Product {o.ProductId} | Qty {o.Quantity} | {o.CreatedAt}");
        }
    }
}

