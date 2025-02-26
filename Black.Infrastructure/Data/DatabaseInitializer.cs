using Microsoft.Data.SqlClient;

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
            var script = @"
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'People')
        BEGIN
            CREATE TABLE People (
                ID INT IDENTITY(1,1) PRIMARY KEY,
                Name NVARCHAR(100) NOT NULL,
                Surname NVARCHAR(100) NOT NULL
            );
        END";

            using (var connection = _databaseConnection.GetConnection())  // Using the DatabaseConnection class
            {
                connection.Open();
                var command = new SqlCommand(script, connection);
                command.ExecuteNonQuery();  // Execute the SQL command to create the table
            }
        }
    }
}
