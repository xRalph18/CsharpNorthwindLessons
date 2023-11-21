

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

    private static List<Foods> GetAllFoods()
    {
        using (DbConnection connection = new SqlConnection(ConnectionString))
        {
            var db = RainbowDatabase.Init(connection, commandTimeout: 2);

            List<Foods> foods = db.Foods.All().ToList();

            return foods;
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

    private static Foods GetFood(int id)
    {
        using (DbConnection connection = new SqlConnection(ConnectionString))
        {
            var db = RainbowDatabase.Init(connection, commandTimeout: 2);

            Foods food = db.Foods.Get(id);

            return food;
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

    private static void InsertSingleFood(string name, int quantity, double averageUSDPrice, int foodType)
    {
        using (DbConnection connection = new SqlConnection(ConnectionString))
        {
            var db = RainbowDatabase.Init(connection, commandTimeout: 2);

            Foods food = new Foods()
            {
                Name = name,
                Quantity = quantity,
                AverageUSDPrice = averageUSDPrice,
                FoodType = foodType
            };

            db.Foods.Insert(food);
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

    private static void UpdateSingleFood(int id, string name, int quantity, double averageUSDPrice, int foodType)
    {
        using (DbConnection connection = new SqlConnection(ConnectionString))
        {
            var db = RainbowDatabase.Init(connection, commandTimeout: 2);

            Foods food = new Foods { Id = id, Name = name, Quantity = quantity, AverageUSDPrice = averageUSDPrice, FoodType = foodType };
            db.Foods.Update(id, food);
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

    private static void DeleteSingleFood(int id)
    {
        using (DbConnection connection = new SqlConnection(ConnectionString))
        {
            var db = RainbowDatabase.Init(connection, commandTimeout: 2);
            db.Foods.Delete(id);
        }
    }

    public static void Main()
    {
        Console.WriteLine("1 = 1st table, 2 = 2nd table");
        int table = int.Parse(Console.ReadLine());

        if (table == 1)
        {
            while (true)
            {

                Console.WriteLine("1 Show, 2 Add, 3 Update, 4 Delete, 0 End Program");
                int whatToDo = int.Parse(Console.ReadLine());

                if (whatToDo == 1)
                {
                    var foods = GetAllFoods();

                    Console.WriteLine();

                    foreach (var item in foods)
                    {
                        Console.WriteLine($"{item.Id} \t {item.Name} \t {item.Quantity} \t {item.AverageUSDPrice} \t {item.FoodType}");
                    }
                }
                else if (whatToDo == 2)
                {
                    var foods = GetAllFoods();

                    Console.WriteLine();

                    Console.WriteLine("Food Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Food quantity:");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Food average price:");
                    double averageUSDPrice = double.Parse(Console.ReadLine());
                    Console.WriteLine("Food type:");
                    int foodType = int.Parse(Console.ReadLine());

                    InsertSingleFood(name, quantity, averageUSDPrice, foodType);
                }
                else if (whatToDo == 3)
                {
                    Console.WriteLine();

                    Console.WriteLine("Id of data you want to update:");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Food Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Food quantity:");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Food average price:");
                    double averageUSDPrice = double.Parse(Console.ReadLine());
                    Console.WriteLine("Food type:");
                    int foodType = int.Parse(Console.ReadLine());

                    UpdateSingleFood(id, name, quantity, averageUSDPrice, foodType);
                }
                else if (whatToDo == 4)
                {
                    Console.WriteLine();

                    Console.WriteLine("Id of data you want to delete:");
                    int id = int.Parse(Console.ReadLine());

                    DeleteSingleFood(id);
                }
                else
                {
                    return;
                }

            }
        }
        else if (table == 2)
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
}
