using EducationERP.Models.Modules.EducationalInstitution;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;

namespace EducationERP.Common.Components.Repositories
{
    public interface IStructEducationRepository
    {
        StructEducationalInstitution GetStructEducation();
        Task SaveStructEducation(StructEducationalInstitution structEducation);

        Task<bool> CreateFaculty(Faculty faculty);
        Task<bool> UpdateFaculty(FacultyVM facultyVM);
        Task<bool> DeleteFaculty(Guid id);

        Task<bool> CreateDepartment(Department department);
        Task<bool> UpdateDepartment(DepartmentVM departmentVM);
        Task<bool> DeleteDepartment(Guid id);

        Task<Guid> GetAccessFaculty(string passwordFaculty);
    }
}