using Dapper.Contrib.Extensions;
using DapperContrib___4.Model;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

class Program
{
    // Dodaj s do nazw tabel w management studio

    public static string connectionString = @"Data Source=LAPTOP-2192VOI2\SQLEXPRESS;Initial Catalog=FoodStore2;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    private static void GetAllFoodTypes()
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            List<FoodTypes> foodTypes = db.GetAll<FoodTypes>().ToList();

            foreach (FoodTypes foodType in foodTypes)
            {
                Console.WriteLine($"{foodType.Id} \t {foodType.Name} \t {foodType.Description}");
            }
        }
    }

    private static void GetFoodType(int id)
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            FoodTypes foodType = db.Get<FoodTypes>(id);

            Console.WriteLine(foodType.Name + " " + foodType.Description);
        }
    }

    public static void Main()
    {
        GetAllFoodTypes();
        //GetFoodType(1);
    }
}