using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Windows;

namespace EducationERP.Common.Components
{
    public class Config(DataContext context) : IConfig
    {
        public string StrConnection { get; set; } = string.Empty;
        public bool Login(string identifier, string password)
        {
            context.Database.GetDbConnection().ConnectionString = $"Host={GetValueConfig("Host")};" +
                                                                  $"Port={GetValueConfig("Port")};" +
                                                                  $"Username={identifier};" +
                                                                  $"Password={password};" +
                                                                  $"Database={GetValueConfig("Database")};";

            if (context.Database.CanConnect()) return true;
            else
            {
                MessageBox.Show("Ошибка подключения!");
                return false;
            }
        }
        public string GetValueConfig(string configName) => ConfigurationManager.AppSettings[configName];
        public string GetStrConnection(string identifier, string password)
        {
            StrConnection = $"Host={GetValueConfig("Host")};" +
                            $"Port={GetValueConfig("Port")};" +
                            $"Username={identifier};" +
                            $"Password={password};" +
                            $"Database={GetValueConfig("Database")};";

            return StrConnection;
        }
        public void SaveConfig(string host, string port, string dataBase, string pathTemporaryData)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Host"].Value = host;
            config.AppSettings.Settings["Port"].Value = port;
            config.AppSettings.Settings["Database"].Value = dataBase;
            config.AppSettings.Settings["PathTemporaryData"].Value = pathTemporaryData;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("Настройки сохранены!");
        }
        public void RemoveConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Host"].Value = string.Empty;
            config.AppSettings.Settings["Port"].Value = string.Empty;
            config.AppSettings.Settings["Database"].Value = string.Empty;
            config.AppSettings.Settings["PathTemporaryData"].Value = string.Empty;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("Настройки удалены!");
        }
    }
}