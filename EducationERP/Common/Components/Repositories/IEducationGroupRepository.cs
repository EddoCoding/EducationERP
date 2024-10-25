using EducationERP.Models.Modules.EducationalInstitution;

namespace EducationERP.Common.Components.Repositories
{
    public interface IEducationGroupRepository
    {
        Task<bool> CreateStudent(Student student);
    }
}