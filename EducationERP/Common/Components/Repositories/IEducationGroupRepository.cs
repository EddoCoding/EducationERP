using EducationERP.Models.Modules.EducationalInstitution;

namespace EducationERP.Common.Components.Repositories
{
    public interface IEducationGroupRepository
    {
        Task<IEnumerable<Student>> Update(Guid id);
        Task<bool> Create<T>(T model) where T : class;
        Task<bool> Delete<T>(Guid id) where T : class;
    }
}