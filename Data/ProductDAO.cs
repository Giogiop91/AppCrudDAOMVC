using AppCrudDAOMVC.Data;
using AppCrudDAOMVC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace AppCrudDAOMVC.Data
{
    public class ProductDAO
    {
        public void Insert(Product p)
        {
            using SqlConnection conn = DbConnectionFactory.CreateConnection();

            string sql = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Price", p.Price);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<Product> GetAll()
        {
            List<Product> list = new();

            using SqlConnection conn = DbConnectionFactory.CreateConnection();
            string sql = "SELECT ProductId, Name, Price FROM Products";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            using SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new Product
                {
                    ProductId = r.GetInt32(0),
                    Name = r.GetString(1),
                    Price = r.GetDecimal(2)
                });
            }

            return list;
        }
    }
}

