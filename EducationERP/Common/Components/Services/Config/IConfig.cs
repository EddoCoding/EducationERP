namespace EducationERP.Common.Components
{
    public interface IConfig
    {
        string GetValueConnect(string connectName);
        string GetValueConfig(string configName);
    }
}