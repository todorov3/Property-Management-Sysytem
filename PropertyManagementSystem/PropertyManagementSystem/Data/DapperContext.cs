using System.Data;
using System.Data.SqlClient;

namespace PropertyManagementSystem.Data
{
    public class DapperContext
    {
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration, string connectionString = "DefaultConnection") 
        { 
            _connectionString = configuration.GetConnectionString(connectionString);
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
