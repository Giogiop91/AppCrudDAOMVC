using AppCrudDAOMVC.Models;
using Microsoft.Data.SqlClient;

namespace AppCrudDAOMVC.Data
{

    public class OrderDAO
    {
        public void Insert(Order o)
        {
            using SqlConnection conn = DbConnectionFactory.CreateConnection();

            string sql = @"INSERT INTO Orders (UserId, ProductId, Quantity)
                           VALUES (@UserId, @ProductId, @Quantity)";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", o.UserId);
            cmd.Parameters.AddWithValue("@ProductId", o.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", o.Quantity);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<Order> GetAll()
        {
            List<Order> list = new();

            using SqlConnection conn = DbConnectionFactory.CreateConnection();
            string sql = @"SELECT OrderId, UserId, ProductId, Quantity, OrderDate
                           FROM Orders";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            using SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new Order
                {
                    OrderId = r.GetInt32(0),
                    UserId = r.GetInt32(1),
                    ProductId = r.GetInt32(2),
                    Quantity = r.GetInt32(3),
                    OrderDate = r.GetDateTime(4)
                });
            }

            return list;
        }
    }
}

