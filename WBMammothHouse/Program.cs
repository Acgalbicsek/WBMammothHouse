using System;





namespace WBMammothHouse
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            Console.WriteLine("Welcome Book Information:");
            DatabaseHelper.FetchWelcomeBook();

            Console.WriteLine("\nToday's Weather:");
            DatabaseHelper.FetchWeatherData("2025-06-16");

            Console.WriteLine("\nAdding a New Section...");
            DatabaseHelper.AddWelcomeBookSection("Check-Out Info", "Please leave keys inside and lock the door.");

            Console.WriteLine("\nAdding a New Weather Record...");
            DatabaseHelper.AddWeatherData("2025-06-17", 72.5f, "Partly Cloudy");
        }
    }
}