using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


//(Optional: Common Dapper methods for query execution)
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
namespace Black.Infrastructure.Helpers
{
    public class DapperHelper
    {
        private readonly string _connectionString;

        // Constructor: Dependency Injection of connection string from IConfiguration
        public DapperHelper(IConfiguration configuration)
        {
            // Getting connection string from appsettings.json
            _connectionString = configuration.GetConnectionString("BlackCodingConnectionString");
        }

        // ExecuteAsync method to execute SQL commands asynchronously
        public async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            // Open the connection asynchronously and execute the SQL command
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Open connection asynchronously
                return await connection.ExecuteAsync(sql, parameters); // Execute SQL command asynchronously
            }
        }
    }
}
