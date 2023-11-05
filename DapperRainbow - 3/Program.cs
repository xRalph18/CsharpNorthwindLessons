

using DapperRainbow___3.Model;
using System.Data.Common;
using System.Data.SqlClient;

class Program
{
    static string ConnectionString = @"Data Source=LAPTOP-2192VOI2\SQLEXPRESS;Initial Catalog=FoodStore2;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    private static List<FoodTypes> GetAllFoodTypes()
    {
        using (DbConnection connection = new SqlConnection(ConnectionString))
        {
            var db = RainbowDatabase.Init(connection, commandTimeout: 2);

            List<FoodTypes> foodTypes = db.FoodTypes.All().ToList();

            return foodTypes;
        }
    }

    private static FoodTypes GetFoodTypes(int id)
    {
        using (DbConnection connection = new SqlConnection(ConnectionString))
        {
            var db = RainbowDatabase.Init(connection, commandTimeout: 2);

            FoodTypes foodTypes = db.FoodTypes.Get(id);

            return foodTypes;
        }
    }

    private static void InsertSingleFoodType(int id, string name, string description)
    {
        using (DbConnection connection = new SqlConnection(ConnectionString))
        {
            var db = RainbowDatabase.Init(connection, commandTimeout: 2);

            FoodTypes foodType = new FoodTypes()
            {
                Id = id,
                Name = name,
                Description = description
            };

            db.FoodTypes.Insert(foodType);
        }
    }

    private static void UpdateSingleFoodType(int id, string name, string description)
    {
        using (DbConnection connection = new SqlConnection(ConnectionString))
        {
            var db = RainbowDatabase.Init(connection, commandTimeout: 2);

            FoodTypes foodType = new FoodTypes { Id = id, Name = name, Description = description };
            db.FoodTypes.Update(id, foodType);
        }
    }

    private static void DeleteSingleFoodType(int id)
    {
        using (DbConnection connection = new SqlConnection(ConnectionString))
        {
            var db = RainbowDatabase.Init(connection, commandTimeout: 2);
            db.FoodTypes.Delete(id);
        }
    }

    public static void Main()
    {

        while (true)
        {

            Console.WriteLine("1 Show, 2 Add, 3 Update, 4 Delete, 0 End Program");
            int whatToDo = int.Parse(Console.ReadLine());

            if (whatToDo == 1)
            {
                var foodTypes = GetAllFoodTypes();

                Console.WriteLine();

                foreach (var item in foodTypes)
                {
                    Console.WriteLine($"{item.Id} \t {item.Name} \t {item.Description}");
                }
            }
            else if (whatToDo == 2)
            {
                var foodTypes = GetAllFoodTypes();

                Console.WriteLine();

                Console.WriteLine("Food Type Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Food Type Description:");
                string description = Console.ReadLine();

                InsertSingleFoodType(foodTypes.Select(n => n.Id).LastOrDefault(), name, description);
            }
            else if (whatToDo == 3)
            {
                Console.WriteLine();

                Console.WriteLine("Id of data you want to update:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Food Type Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Food Type Description:");
                string description = Console.ReadLine();

                UpdateSingleFoodType(id, name, description);
            }
            else if (whatToDo == 4)
            {
                Console.WriteLine();

                Console.WriteLine("Id of data you want to delete:");
                int id = int.Parse(Console.ReadLine());

                DeleteSingleFoodType(id);
            }
            else
            {
                return;
            }

        }
    }
}
