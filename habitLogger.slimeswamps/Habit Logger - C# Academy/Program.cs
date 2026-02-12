using Microsoft.Data.Sqlite;
using System.Globalization;

namespace Habit_Logger
{
    internal class Program
    {
        static string connectionString = @"DataSource = habitTracker.db";
        static void Main(string[] args)
        {

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS drinkingWater (
                        LogID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT,
                        Quantity INTEGER
                        )";

                tableCmd.ExecuteNonQuery();
                connection.Close();
            }

            bool appOpen = true;
            while (appOpen)
            {
                Console.Clear();
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("\nCHOSE AN OPTION");
                Console.WriteLine("TYPE 1 TO VIEW RECORDS");
                Console.WriteLine("TYPE 2 TO CREATE NEW RECORD");
                Console.WriteLine("TYPE 3 TO UPDATE A RECOED");
                Console.WriteLine("TYPE 4 TO DELETE A RECORD");
                Console.WriteLine("TYPE 0 TO EXIT THE APPLICATION\n");

                string? option = Console.ReadLine();
                while (option != "0" && option != "1" && option != "2" && option != "3" && option != "4")
                {
                    Console.WriteLine("Invalid input. Please enter 0 - 4");
                    option = Console.ReadLine();
                }

                switch (option)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        ViewRecords();
                        break;
                    case "2":
                        InsertRecord();
                        break;
                    case "3":
                        UpadateRecord();
                        break;
                    case "4":
                        DeleteRecord();
                        break;
                }
            }
        }
        private static void ViewRecords()
        {
            Console.Clear();
            Console.WriteLine("Currently: Viewing records\n");

            GetRecords();

            Console.ReadKey();
        }
        private static void InsertRecord()
        {
            Console.Clear();
            Console.WriteLine("Currently: Creating New Record\n");

            string date = DateTime.Today.ToString("dd-MM-yyyy");

            Console.WriteLine("Please Enter number of glasses drank or 0 to return to main menu:");
            string? input = Console.ReadLine();
            int quantity = 0;
            while(!Int32.TryParse(input, out quantity))
            {
                Console.WriteLine("Please enter a number:");
                input = Console.ReadLine();
            }
            if (quantity == 0)
            {
                return;
            }

            Console.WriteLine($"Creating Record: \n\tDate: {date} \n\tQuantity: {quantity}");


            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                
                SqliteCommand command = connection.CreateCommand();
                command.CommandText =
                    @$"INSERT INTO drinkingWater(Date,Quantity)
                        VALUES('{date}',{quantity})";
                command.ExecuteNonQuery();

                connection.Close();
            }

            Console.ReadKey();
        }
        private static void UpadateRecord()
        {
            Console.Clear();
            Console.WriteLine("Currently: Updating Record\n");

            GetRecords();
            Console.WriteLine("Select a record to update");
            Console.WriteLine("Type the ID of the record or 0 to return to main menu");
            string? input = Console.ReadLine();
            int updatedID = 0;
            while (!Int32.TryParse(input,out updatedID))
            {
                Console.WriteLine("Please enter a number:");
                input = Console.ReadLine();
            }
            if (updatedID == 0) 
            {
                return;
            }

            Console.WriteLine("Enter updated quantity:");
            string? input2 = Console.ReadLine();
            int updatedQuantity = 0;
            while (!Int32.TryParse(input2, out updatedQuantity))
            {
                Console.WriteLine("Please enter a number:");
                input2 = Console.ReadLine();
            }

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                
                command.CommandText =
                    @$"UPDATE drinkingWater
                        SET Quantity = {updatedQuantity}
                        WHERE LogID = {updatedID}";
                
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        private static void DeleteRecord()
        { 
            Console.Clear();
            Console.WriteLine("Currently: Deleting Record\n");

            GetRecords();
            Console.WriteLine("Select a record to update");
            Console.WriteLine("Type the ID of the record or 0 to return to main menu");
            string? input = Console.ReadLine();
            int id = 0;
            while (!Int32.TryParse(input, out id))
            {
                Console.WriteLine("Please enter a number:");
                input = Console.ReadLine();
            }
            if (id == 0)
            {
                return;
            }

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();

                command.CommandText =
                    $@"DELETE FROM drinkingWater
                        WHERE LogID = {id}";

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        private static void GetRecords() 
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText =
                    "SELECT * FROM drinkingWater";

                List<DrinkingWater> tableData = new List<DrinkingWater>();

                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tableData.Add(
                            new DrinkingWater
                            {
                                LogID = reader.GetInt32(0),
                                Date = DateTime.ParseExact(reader.GetString(1), "dd-MM-yyyy", new CultureInfo("en-UK")),
                                Quantity = reader.GetInt32(2)
                            });
                    }
                }
                else
                {
                    Console.WriteLine("Error: The table has no records yet");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("---------------------------------------------");
                foreach (DrinkingWater dw in tableData)
                {
                    Console.WriteLine($"{dw.LogID} - {dw.Date.ToString("dd-MM-yyyy")} - Quantity: {dw.Quantity}");
                }
                Console.WriteLine("---------------------------------------------");

                connection.Close();
            }
        }
    }

    public class DrinkingWater
    {
        public int LogID {  get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
    }
}