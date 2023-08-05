using Microsoft.Data.SqlClient;
using Dapper;

const string connectionString = "Server=localhost,1433;Database=balta;User Id=sa;Password=@Teste123@;TrustServerCertificate=True";

var category = new Category();
category.Id = Guid.NewGuid();
category.Title = "Amazon AWS";
category.Url = "amazon";
category.Description = "Categoria destinada a serviços do AWS";
category.Order = 8;
category.Summary = "AWS Cloud";
category.Featured = false;

//Nunca concatenar Strings, Receber parâmetros
var insertSql = @"INSERT INTO 
    [Category] 
VALUES(
    @Id, 
    @Title, 
    @Url, 
    @Summary, 
    @Order, 
    @Description, 
    @Featured)";

using (var connection = new SqlConnection(connectionString))
{
    //mapeia os parâmetros, retorna um int
    var rows = connection.Execute(insertSql, new 
    {
        category.Id,
        category.Title,
        category.Url,
        category.Summary,
        category.Order,
        category.Description,
        category.Featured
    });
    Console.WriteLine($"{rows} linhas inseridas");

    var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
    foreach (var item in categories)
    {
        Console.WriteLine($"{item.Id} -- {item.Title}");
    }
}