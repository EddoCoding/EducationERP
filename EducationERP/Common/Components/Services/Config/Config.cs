using Microsoft.EntityFrameworkCore;
using Raketa;
using System.Configuration;
using System.Data.Common;
using System.Windows;

namespace EducationERP.Common.Components
{
    public class Config : RaketaViewModel, IConfig
    {
        string _strConnection = string.Empty;
        string _isConfigured;
        DbConnectionStringBuilder _builder;

        public Config()
        {
            _isConfigured = ConfigurationManager.AppSettings["isConfigured"];
            _strConnection = ConfigurationManager.ConnectionStrings["StrConnection"].ConnectionString;
            _builder = new DbConnectionStringBuilder { ConnectionString = _strConnection };
        }

        public string GetValueConnection(string connectionName)
        {
            if (_builder.ContainsKey(connectionName)) return _builder[connectionName].ToString();
            else return default;
        }
        public string GetValueConfig(string configName) => ConfigurationManager.AppSettings[configName];

        public void SaveConfig(string host, string port, string username, string password, string database, string pathTemporaryData)
        {
            if (String.IsNullOrWhiteSpace(host)) return;

            using(var context = new DataContext())
            {
                try
                {
                    context.Database.GetDbConnection().ConnectionString = $"Host={host};Port={port};Username={username};Password={password};Database={database};";
                }
                catch
                {
                    MessageBox.Show("Некорректный ввод!");
                    return;
                }

                if (context.Database.CanConnect())
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                    config.ConnectionStrings.ConnectionStrings["StrConnection"].ConnectionString =
                        $"Host={host};Port={port};Username={username};Password={password};Database={database};";
                    config.AppSettings.Settings["PathTemporaryData"].Value = pathTemporaryData;

                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("connectionStrings");
                    ConfigurationManager.RefreshSection("appSettings");

                    MessageBox.Show("Настройки конфигурации сохранены!");
                }
                else
                {
                    MessageBox.Show("Невозможно сохранить! Ошибка подключения!");
                    return;
                }
            }
        }
        public void RemoveConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.ConnectionStrings.ConnectionStrings["StrConnection"].ConnectionString = string.Empty;
            config.AppSettings.Settings["PathTemporaryData"].Value = string.Empty;
            config.AppSettings.Settings["isConfigured"].Value = "False";

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            ConfigurationManager.RefreshSection("appSettings");
            
            MessageBox.Show("Настройки удалены!");
        }

        public bool CheckIsConfigured() => bool.TryParse(_isConfigured, out var isConfigured) && isConfigured;
    }
}