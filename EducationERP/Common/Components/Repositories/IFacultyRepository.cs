using EducationERP.Models.Modules.EducationalInstitution;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;

namespace EducationERP.Common.Components.Repositories
{
    public interface IFacultyRepository
    {
        Faculty GetFacultyById(Guid id);
        Task<bool> CreateEducationGroup(EducationGroup group);
        Task<bool> UpdateEducationGroup(EducationGroupVM groupVM);
        Task<bool> DeleteEducationGroup(Guid id);
    }
}