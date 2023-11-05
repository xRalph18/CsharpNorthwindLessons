using BazaDanychNorthWind_Dapper___2;
using Dapper;
using System.Data.SqlClient;

class Program
{
    public static void Main()
    {
        string connString = "Data Source=LAPTOP-2192VOI2\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";

        var sql = "SELECT * FROM Customers";
        var customers = new List<CustomerModel>();
        using (var connection = new SqlConnection(connString))
        {
            connection.Open();

            customers = connection.Query<CustomerModel>(sql).ToList();
        }

        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.ContactName}");
        }
    }
}

// wykonaj projekt, w którym tworzysz bazę danych, dla której utworzysz program używając dappera wykonując podstawowe polecenia SELECT, INSERT, DELETE, UPDATE;