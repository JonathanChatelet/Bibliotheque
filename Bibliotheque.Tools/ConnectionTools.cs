using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Bibliotheque.Tools
{
    public static class ConnectionTools
    {
        public static string getConnectionString()
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            return config.GetConnectionString("BibliothequeDB");
        }
    }
}
