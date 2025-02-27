using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace Black.Infrastructure.Data
{
    public class DatabaseInitializer
    {
        private readonly DatabaseConnection _databaseConnection;

        // Injecting DatabaseConnection into the DatabaseInitializer constructor
        public DatabaseInitializer(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        // Method to execute the SQL script for creating the table
        public void ExecuteScript()
        {
            // Step 1: Create the database if it doesn't exist
            using (var connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                var createDbCommand = new SqlCommand("IF DB_ID('BlackCodePersonDB2') IS NULL CREATE DATABASE BlackCodePersonDB2;", connection);
                createDbCommand.ExecuteNonQuery();
            }

            // Step 2: Switch to the new database and execute the table creation scripts
            using (var connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                connection.ChangeDatabase("BlackCodePersonDB2");  // Switch to the new database
                
                // Step 3: Read and execute the table creation scripts
                var personScript = File.ReadAllText(@"C:\Users\user\Desktop\Csharp\BlackWorkFolder\Blackcoding\Black.Infrastructure\Data\Scripts\CreatePersonTable.sql");
                var cardScript = File.ReadAllText(@"C:\Users\user\Desktop\Csharp\BlackWorkFolder\Blackcoding\Black.Infrastructure\Data\Scripts\CreateCardTable.sql");

                ExecuteSql(personScript, connection);
                ExecuteSql(cardScript, connection);
            }
        }
        private void ExecuteSql(string script, SqlConnection connection)
        {
            var command = new SqlCommand(script, connection);
            command.ExecuteNonQuery();  // Execute the SQL command to create the tables
        }
    }
    
}

