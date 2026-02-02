using Microsoft.Data.SqlClient;
using AppCrudDAOMVC.Models;

namespace AppCrudDAOMVC.Data
{
    public class UserDAO
    {
        public void Insert(User user)
        {
            using SqlConnection conn = DbConnectionFactory.CreateConnection();

            string sql = "INSERT INTO Users (FullName, Email) VALUES (@FullName, @Email)";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@FullName", user.FullName);
            cmd.Parameters.AddWithValue("@Email", user.Email);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();

            using SqlConnection conn = DbConnectionFactory.CreateConnection();
            string sql = "SELECT UserId, FullName, Email, CreatedAt FROM Users";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new User
                {
                    UserId = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    Email = reader.GetString(2),
                    CreatedAt = reader.GetDateTime(3)
                });
            }

            return users;
        }

        public void Update(User user)
        {
            using SqlConnection conn = DbConnectionFactory.CreateConnection();

            string sql = @"
                UPDATE Users
                SET FullName = @FullName,
                    Email = @Email
                WHERE UserId = @UserId";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@FullName", user.FullName);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@UserId", user.UserId);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int userId)
        {
            using SqlConnection conn = DbConnectionFactory.CreateConnection();

            string sql = "DELETE FROM Users WHERE UserId = @UserId";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}

