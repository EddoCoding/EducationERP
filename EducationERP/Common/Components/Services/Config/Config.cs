using System.Configuration;
using System.Data.Common;
using System.Windows;

namespace EducationERP.Common.Components
{
    public class Config : IConfig
    {
        string strConnection = string.Empty;
        DbConnectionStringBuilder builder = new();

        DataContext _context;
        public Config(DataContext context)
        {
            _context = context;

            strConnection = ConfigurationManager.ConnectionStrings["StrConnection"].ConnectionString;
            builder.ConnectionString = strConnection;
        }

        public void SaveConfig(string host, string port, string username, string password, string database, string pathTemporaryData)
        {
            if (!_context.CanConnect(host, port, username, password, database))
            {
                MessageBox.Show("Ошибка соединения!");
                return;
            }

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.ConnectionStrings.ConnectionStrings["StrConnection"].ConnectionString =
                $"Host={host};Port={port};Username={username};Password={password};Database={database}";

            config.AppSettings.Settings["PathTemporaryData"].Value = pathTemporaryData;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("Конфигурации сохранены!");
        }
        public void RemoveConfig()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var strConnection = config.ConnectionStrings.ConnectionStrings["StrConnection"];
            strConnection.ConnectionString = string.Empty;
            config.AppSettings.Settings["PathTemporaryData"].Value = string.Empty;
            config.AppSettings.Settings["IsConfigured"].Value = "False";

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            ConfigurationManager.RefreshSection("connectionStrings");

            MessageBox.Show("Конфигурации удалены!");
        }

        public string GetValueConnect(string connectName)
        {
            try { return builder[connectName]?.ToString(); }
            catch { return string.Empty; }
        }
        public string GetValueConfig(string configName) => ConfigurationManager.AppSettings[configName];
    }
}