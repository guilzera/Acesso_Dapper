using Microsoft.Data.SqlClient;

const string connectionString = "Server=localhost,1433;Database=balta;User Id=sa;Password=@Teste123@;TrustServerCertificate=True";

using (var connection = new SqlConnection(connectionString))
{
    
}