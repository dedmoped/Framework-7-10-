using System;
using System.Configuration;

namespace GitHubAutomation.Services
{
    class PastDateReader
    {
        static Configuration Config
        {
            get
            {
                string file = "DateCheck";
                int index = AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin", StringComparison.Ordinal);
                var configeMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory.Substring(0, index) +
                    @"ConfigFiles\" + file + ".config"
                };
                return ConfigurationManager.OpenMappedExeConfiguration(configeMap, ConfigurationUserLevel.None);
            }
        }

        public static KeyValueConfigurationElement GetData(string key)
        {
            return Config.AppSettings.Settings[key];
        }
    }
}

