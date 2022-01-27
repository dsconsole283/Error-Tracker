using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace SlotErrorTrackerLibrary.Databases
{
    public class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _config;

        public SQLDataAccess(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddAzureAppConfiguration(Environment.GetEnvironmentVariable("ConnectionString"));

            configuration = builder.Build();

            _config = configuration;
        }

        public List<T> LoadData<T, U>(string sqlStatement,
                                      U parameters,
                                      string key,
                                      bool isStoredProcedure = false)
        {

            string connectionString = _config.GetSection(key).Value;

            CommandType commandType = CommandType.Text;

            if (isStoredProcedure == true)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sqlStatement, parameters, commandType: commandType).ToList();
                return rows;
            }
        }

        public void SaveData<T>(string sqlStatement,
                                T parameters,
                                string key,
                                bool isStoredProcedure = false)
        {

            string connectionString = _config.GetSection(key).Value;

            CommandType commandType = CommandType.Text;

            if (isStoredProcedure == true)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(sqlStatement, parameters, commandType: commandType);
            }
        }
    }
}
