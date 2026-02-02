
using AppCrudDAOMVC.Data;
using AppCrudDAOMVC.Models;

namespace AppCrudDAOMVC.Controllers
{
    public class UserController
    {
        private readonly UserDAO _dao = new UserDAO();

        public void CreateUser()
        {
            Console.Write("Nome completo: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            User user = new User
            {
                FullName = name,
                Email = email
            };

            _dao.Insert(user);
            Console.WriteLine("Utente inserito.");
        }

        public void ListUsers()
        {
            var users = _dao.GetAll();

            foreach (var u in users)
            {
                Console.WriteLine($"{u.UserId} | {u.FullName} | {u.Email} | {u.CreatedAt}");
            }
        }

        public void UpdateUser()
        {
            Console.Write("ID utente da aggiornare: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nuovo nome: ");
            string name = Console.ReadLine();

            Console.Write("Nuova email: ");
            string email = Console.ReadLine();

            User user = new User
            {
                UserId = id,
                FullName = name,
                Email = email
            };

            _dao.Update(user);
            Console.WriteLine("Utente aggiornato.");
        }

        public void DeleteUser()
        {
            Console.Write("ID utente da eliminare: ");
            int id = int.Parse(Console.ReadLine());

            _dao.Delete(id);
            Console.WriteLine("Utente eliminato.");
        }
    }
}



