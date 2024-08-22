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

        public string GetValueConnect(string connectName) => builder[connectName]?.ToString();
        public string GetValueConfig(string configName) => ConfigurationManager.AppSettings[configName];
    }
}