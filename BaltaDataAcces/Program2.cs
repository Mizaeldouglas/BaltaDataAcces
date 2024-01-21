// // See https://aka.ms/new-console-template for more information
//
//
// using Microsoft.Data.SqlClient;
//
//
// namespace BaltaDataAcces;
//
// public static class Program2
// {
//     public static void Main(string[] args)
//     {
//         const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=MyPassword123#";
//         using (var connection =  new SqlConnection(connectionString))
//         {
//             Console.WriteLine("Conectado");
//             connection.Open();
//             using (var command = new SqlCommand())
//             {
//                 command.Connection = connection;
//                 command.CommandType = System.Data.CommandType.Text;
//                 command.CommandText = "SELECT  [Id], [Title] FROM [Category]";
//
//                 var reader = command.ExecuteReader();
//                 while (reader.Read())
//                 {
//                     Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
//                 }
//             }
//             
//         }
//     }
// }