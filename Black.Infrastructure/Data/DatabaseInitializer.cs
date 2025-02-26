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
            // Get the path to the SQL script file
            string personScriptPath = @"C:\Users\user\Desktop\Csharp\BlackWorkFolder\Blackcoding\Black.Infrastructure\Data\Scripts\CreatePersonTable.sql";
            string cardScriptPath = @"C:\Users\user\Desktop\Csharp\BlackWorkFolder\Blackcoding\Black.Infrastructure\Data\Scripts\CreateCardTable.sql";

            // Read the script file content
            var personScript = File.ReadAllText(personScriptPath);
            var cardScript = File.ReadAllText(cardScriptPath);
            // Execute the Person table creation script
            ExecuteSql(personScript);

            // Execute the Cards table creation script
            ExecuteSql(cardScript);
        }
        private void ExecuteSql(string script)
        {
            using (var connection = _databaseConnection.GetConnection())  // Using the DatabaseConnection class
            {
                connection.Open();
                var command = new SqlCommand(script, connection);
                command.ExecuteNonQuery();  // Execute the SQL command to create the tables
            }
        }
    }
}

