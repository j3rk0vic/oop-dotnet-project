using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.DataLayer.Configuration
{
    public enum DataSourceType 
    {
        Api,
        Json
    }
    public static class ConfigManager
    {
        private static readonly string configFile = "config.txt";

        public static DataSourceType GetDataSource()
        {
            if (!File.Exists(configFile))
                return DataSourceType.Api;

            string value = File.ReadAllText(configFile).Trim().ToLower();

            if (value == "json")
            { 
                return DataSourceType.Json;
            }
            else
            {
                return DataSourceType.Api;
            }
        }
    }
}
