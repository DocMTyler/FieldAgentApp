using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FieldAgent.DAL
{
    internal static class SettingsManager
    {
        private static string _connectionString;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                var builder = new ConfigurationBuilder();

                builder.SetBasePath(Directory.GetCurrentDirectory());
                //builder.AddJsonFile("appsettings.json", false, true);
                builder.AddUserSecrets<AppDbContext>();
                
                var config = builder.Build();

                _connectionString = config["ConnectionStrings:FieldAgentTest"];
            }

            return _connectionString;
        }
    }
}
