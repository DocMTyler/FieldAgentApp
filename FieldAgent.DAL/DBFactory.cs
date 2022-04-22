using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FieldAgent.DAL
{
    public class DBFactory
    {
        private readonly IConfigurationRoot Config;

        public DBFactory(IConfigurationRoot config)
        {
            Config = config;
        }

        public AppDbContext GetDbContext()
        {
            return new AppDbContext();
        }
    }
}
