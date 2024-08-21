namespace EducationERP.Common.Components
{
    public interface IConfig
    {
        string StrConnection { get; set; }
        bool Login(string identifier, string password);
        string GetValueConfig(string configName);
        string GetStrConnection(string identifier, string password);
        void SaveConfig(string host, string port, string dataBase, string pathTemporaryData);
        void RemoveConfig();
    }
}