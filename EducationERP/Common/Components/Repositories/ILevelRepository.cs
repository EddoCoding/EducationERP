using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;

namespace EducationERP.Common.Components.Repositories
{
    public interface ILevelRepository
    {
        SettingLevel[] ReadLevels();

        bool CreateLevel(SettingLevel level);
        bool DeleteLevel(Guid id);

        bool CreateDirection(SettingDirection direction);
        bool DeleteDirection(Guid id);

        bool CreateProfile(SettingProfile profile);
        bool DeleteProfile(Guid id);

        bool CreateForm(SettingForm form);
        bool DeleteForm(Guid id);
    }
}