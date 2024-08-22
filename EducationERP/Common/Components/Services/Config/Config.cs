using System.Configuration;
using System.Data.Common;

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

        public void RemoveConfig()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var strConnection = config.ConnectionStrings.ConnectionStrings["StrConnection"];
            strConnection.ConnectionString = string.Empty;
            config.AppSettings.Settings["PathTemporaryData"].Value = string.Empty;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public string GetValueConnect(string connectName)
        {
            try { return builder[connectName]?.ToString(); }
            catch { return string.Empty; }
        }
        public string GetValueConfig(string configName) => ConfigurationManager.AppSettings[configName];
    }
}