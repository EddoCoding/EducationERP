using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;

namespace EducationERP.Common.Components.Repositories
{
    public interface ISettingFacultyRepository
    {
        IEnumerable<SettingFaculty> Read();

        bool Create<T>(T model) where T: class;
        bool Delete<T>(Guid id) where T: class;
    }
}