// See https://aka.ms/new-console-template for more information


using BaltaDataAcces.Models;
using Dapper;
using Microsoft.Data.SqlClient;


namespace BaltaDataAcces;

public static class Program
{
    public static void Main(string[] args)
    {
        const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=MyPassword123#";


        using (var connection = new SqlConnection(connectionString))
        {
            UpdateCategoy(connection);
            ListCategories(connection);
            // CreateCategory(connection);
        }
    }

    static void ListCategories(SqlConnection connection)
    {
        var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

        foreach (var item in categories)
        {
            Console.WriteLine($"{item.Id} - {item.Title}");
        }
    }

    static void CreateCategory(SqlConnection connection)
    {
        var category = new Category();
        category.Id = Guid.NewGuid();
        category.Title = "Amazon AWS";
        category.Description = "Categoria destidana a serviços do AWS";
        category.Url = "Amazon";
        category.Order = 8;
        category.Summary = "AWS Cloud";
        category.Featured = false;
            
        var insertSql = "INSERT INTO [Category] VALUES(@Id,@Title,@Url,@Summary, @Order, @Description, @Featured)";

        var rows = connection.Execute(insertSql, new
        {
            category.Id,
            category.Url,
            category.Title,
            category.Summary,
            category.Order,
            category.Description,
            category.Featured 
        });
        Console.WriteLine($"{rows} linhas inseridas");


    }

    static void UpdateCategoy(SqlConnection connection)
    {
        var updateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id]= @id";
        var rows = connection.Execute(updateQuery, new
        {
            id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
            title = "FrontEnd 2024"
        });
        Console.WriteLine($"{rows} Registros atualizados");
    }
}