using Microsoft.Data.SqlClient;
using Dapper;

const string connectionString = "Server=localhost,1433;Database=balta;User Id=sa;Password=@Teste123@;TrustServerCertificate=True";

using (var connection = new SqlConnection(connectionString))
{
    var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
    foreach (var category in categories)
    {
        Console.WriteLine($"{category.Id} -- {category.Title}");
    }
}