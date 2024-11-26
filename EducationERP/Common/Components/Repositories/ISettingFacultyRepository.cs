using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;

namespace EducationERP.Common.Components.Repositories
{
    public interface ISettingFacultyRepository
    {
        IEnumerable<SettingFaculty> Read();
        Task<bool> Create<T>(T model) where T: class;
        Task<bool> Delete<T>(Guid id) where T: class;
        Task<Guid> GetIdVuz();
    }
}