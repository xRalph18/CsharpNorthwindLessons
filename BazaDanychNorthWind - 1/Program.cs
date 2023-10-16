using System.Data.SqlClient;

class Program
{
    public static void Main()
    {
        string connectionString = "Data Source=LAPTOP-2192VOI2\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";

        string queryString2 = "SELECT CategoryID, CategoryName, Description FROM Categories ORDER BY CategoryID;";
        string insertString1 = "INSERT INTO Categories (CategoryName, Description) VALUES (@categoryName, @description);";
        string deleteString = "DELETE FROM Categories WHERE CategoryID = @categoryid;";
        string updateString = "UPDATE Categories SET CategoryName = @updatecategoryname, Description = @updatedescription WHERE CategoryID = @updateid;";

        Console.WriteLine("Czy chcesz dodać jakieś dane? [0 - nie, 1 - tak]");
        int check1 = int.Parse(Console.ReadLine());

        string categoryName = "";
        string description = "";

        if (check1 == 1)
        {
            Console.WriteLine("Podaj nazwę kategori");
            categoryName = Console.ReadLine();
            Console.WriteLine("Podaj opis kategori");
            description = Console.ReadLine();
        }

        Console.WriteLine("Czy chcesz usunąć jakieś dane? [0 - nie, 1 - tak]");
        int check2 = int.Parse(Console.ReadLine());

        int deleteId = 0;

        if (check2 == 1)
        {
            Console.WriteLine("Podaj id pola, które chcesz usunąć");
            deleteId = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Czy chcesz uaktualnić jakieś dane? [0 - nie, 1 - tak]");
        int check3 = int.Parse(Console.ReadLine());

        int updateId = 0;
        string updateName = "";
        string updateDescription = "";

        if (check3 == 1)
        {
            Console.WriteLine("Podaj id pola, które chcesz uaktualnić");
            updateId = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj nową nazwę kategorii");
            updateName = Console.ReadLine();
            Console.WriteLine("Podaj nowy opis kategorii");
            updateDescription = Console.ReadLine();
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(queryString2, connection);
            SqlCommand insertCommand = new SqlCommand(insertString1, connection);
            insertCommand.Parameters.AddWithValue("@categoryName", categoryName);
            insertCommand.Parameters.AddWithValue("@description", description);
            SqlCommand deleteCommand = new SqlCommand(deleteString, connection);
            deleteCommand.Parameters.AddWithValue("@categoryid", deleteId);
            SqlCommand updateCommand = new SqlCommand(updateString, connection);
            updateCommand.Parameters.AddWithValue("@updateid", updateId);
            updateCommand.Parameters.AddWithValue("@updatecategoryname", updateName);
            updateCommand.Parameters.AddWithValue("@updatedescription", updateDescription);
            

            try
            {
                connection.Open();
                if (check1 == 1)
                {
                    insertCommand.ExecuteNonQuery();
                }
                if (check2 == 1)
                {
                    deleteCommand.ExecuteNonQuery();
                }
                if (check3 == 1)
                {
                    updateCommand.ExecuteNonQuery();
                }
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}