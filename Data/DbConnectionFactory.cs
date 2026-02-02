using Microsoft.Data.SqlClient;

namespace AppCrudDAOMVC.Data
{
    public static class DbConnectionFactory
    {
        private static readonly string _connectionString =
            "Server=localhost;Database=AppDB;User Id=appuser;Password=AppUser2026!;Encrypt=True;TrustServerCertificate=True;";

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
