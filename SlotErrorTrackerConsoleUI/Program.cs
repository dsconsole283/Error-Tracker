using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SlotErrorTrackerLibrary.Data;
using SlotErrorTrackerLibrary.Databases;
using SlotErrorTrackerLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace SlotErrorTrackerConsoleUI
{
    partial class Program
    {
        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            
            var services = scope.ServiceProvider;
            
            try
            {
                var sql = services.GetRequiredService<ISQLData>();

                Console.WriteLine(GetConnectionString());

                //sql.CreateManufacturer("BALLY");

                foreach (var item in sql.GetManufacturers())
                {
                    Console.WriteLine(item.Manufacturer);
                }

                //sql.CreateCabinetByManufacturer("ORION", "AGS");

                //foreach (var item in sql.GetCabinetsByManufacturer("ARISTOCRAT"))
                //{
                //    Console.WriteLine(item.Cabinet);
                //}

                //sql.CreateErrorDescriptionByCabinet("Memory error", "ORION");

                //foreach (var item in sql.GetErrorsByCabinet("ORION"))
                //{
                //    Console.WriteLine(item.Description);
                //}

                //sql.CreateSolutionByErrorDescription("Replace logic board", "No signal", "ORION");

                //foreach (var item in sql.GetSolutionsByErrorDescription("No signal", "ORION"))
                //{
                //    Console.WriteLine(item.Solution);
                //}
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: { ex.Message }");
                Console.ReadLine();
            }

            Console.ReadLine();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                {
                    services.AddTransient<ISQLData, SQLData>();
                    services.AddTransient<ISQLDataAccess, SQLDataAccess>();
                });

        private static string GetConnectionString(string connectionStringName = "SQLDb")
        {
            string output;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connectionStringName);

            return output;
        }
    }
}
