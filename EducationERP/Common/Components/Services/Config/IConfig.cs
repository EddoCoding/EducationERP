namespace EducationERP.Common.Components
{
    public interface IConfig
    {
        string GetValueConnection(string connectionName);
        string GetValueConfig(string configName);

        void SaveConfig(string host, string port, string username, string password, string database, string pathTemporaryData);
        void RemoveConfig();

        bool CheckIsConfigured();
    }
}