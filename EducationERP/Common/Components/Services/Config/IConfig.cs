using System.Windows;

namespace EducationERP.Common.Components
{
    public interface IConfig
    {
        void SaveConfig(string host, string port, string username, string password, string database, string pathTemporaryData);
        void RemoveConfig();

        string GetValueConnect(string connectName);
        string GetValueConfig(string configName);

        bool GetIsConfigured();
    }
}