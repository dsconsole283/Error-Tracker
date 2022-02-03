using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SlotErrorTrackerLibrary.Data;
using SlotErrorTrackerLibrary.Databases;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SlotErrorTrackerConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            try
            {
                var sql = services.GetRequiredService<ISQLData>();

                //sql.CreateManufacturer("ARISTOCRAT");

                foreach (var item in sql.GetManufacturers())
                {
                    Console.WriteLine(item.Manufacturer);
                }

                //sql.CreateCabinetByManufacturer("Arc", "ARISTOCRAT");

                //foreach (var item in sql.GetCabinetsByManufacturer("ARISTOCRAT"))
                //{
                //    Console.WriteLine(item.Cabinet);
                //}

                //sql.CreateErrorDescriptionByCabinet("Memory error", "ORION");

                //foreach (var item in sql.GetErrorsByCabinet("ORION"))
                //{
                //    Console.WriteLine(item.Description);
                //}

                //sql.CreateSolutionByErrorDescription("RAM clear", "Memory Error", "ORION");

                //foreach (var item in sql.GetSolutionsByErrorDescription("Memory Error", "ORION"))
                //{
                //    Console.WriteLine(item.Solution);
                //}

                //sql.CreateErrorDescription("System launcher not found");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: { ex.Message }");
                Console.ReadLine();
            }

            Console.ReadLine();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                {
                    services.AddTransient<ISQLData, SQLData>();
                    services.AddTransient<ISQLDataAccess, SQLDataAccess>();
                });
    }
}
