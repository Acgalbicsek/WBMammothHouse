using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace WBMammothHouse
{
    class DatabaseHelper
    {
        private static string connectionString = "Server=localhost;Database=WelcomeBookDB;User ID=root;Password=yourpassword;";

        public static void FetchWelcomeBook()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Section, Content FROM WelcomeBook";

                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Section"]}: {reader["Content"]}");
                    }
                }
            }
        }

        public static void FetchWeatherData(string date)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Temperature, WeatherCondition FROM Weather WHERE Date = @Date";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", date);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"Weather on {date}: {reader["Temperature"]}°F, {reader["WeatherCondition"]}");
                        }
                    }
                }
            }

        }

        public static void AddWelcomeBookSection(string section, string content)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO WelcomeBook (Section, Content) VALUES (@Section, @Content)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Section", section);
                    command.Parameters.AddWithValue("@Content", content);
                    command.ExecuteNonQuery();

                    Console.WriteLine($"Added: {section}");
                }
            }
        }

        public static void AddWeatherData(string date, float temperature, string condition)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Weather (Date, Temperature, WeatherCondition) VALUES (@Date, @Temperature, @Condition)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Temperature", temperature);
                    command.Parameters.AddWithValue("@Condition", condition);
                    command.ExecuteNonQuery();

                    Console.WriteLine($"Added Weather for {date}: {temperature}°F, {condition}");
                }
            }
        }
    }
}
