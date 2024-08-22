namespace EducationERP.Common.Components
{
    public interface IConfig
    {
        void RemoveConfig();

        string GetValueConnect(string connectName);
        string GetValueConfig(string configName);
    }
}