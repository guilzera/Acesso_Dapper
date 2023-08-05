using Microsoft.Data.SqlClient;

const string connectionString = "Server=localhost,1433;Database=balta;User Id=sa;Password=@Teste123@;TrustServerCertificate=True";

using (var connection = new SqlConnection(connectionString))
{
    Console.WriteLine("Conectado");
    connection.Open();  
    
    using(var command = new SqlCommand())
    {
        command.Connection = connection;
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "SELECT [Id], [Title] FROM [Category]";

        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
        }
    }
}