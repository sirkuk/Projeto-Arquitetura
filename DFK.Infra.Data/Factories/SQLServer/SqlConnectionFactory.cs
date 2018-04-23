using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System;
namespace DFK.Infra.Data.Factories.SQLServer
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            if (!string.IsNullOrEmpty(connectionString))
            {
                _connectionString = "DB.SITE";
            }

            _connectionString = config.GetConnectionString(connectionString);
        }

        public SqlConnectionFactory()
        {
            _connectionString = "DB.SITE";
        }

        public IDbConnection CreateConnection()
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var conn = new SqlConnection(config.GetConnectionString(_connectionString));

            return conn;
        }
    }
}
