using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;

namespace EducationERP.Common.Components.Repositories
{
    public interface ILevelRepository
    {
        void CreateLevel(SettingLevel level);
        SettingLevel[] ReadLevels();
    }
}