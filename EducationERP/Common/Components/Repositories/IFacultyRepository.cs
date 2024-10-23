using EducationERP.Models.Modules.EducationalInstitution;

namespace EducationERP.Common.Components.Repositories
{
    public interface IFacultyRepository
    {
        Faculty GetFacultyById(Guid id);
        Task<bool> CreateEducationGroup(EducationGroup group);
        Task<bool> DeleteEducationGroup(Guid id);
    }
}