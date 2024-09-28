using EducationERP.Models;

namespace EducationERP.Common.Components.Repositories
{
    public interface ILevelRepository
    {
        Task<bool> Create(EducationalLevelPreparation level);
        Task<List<T>> Read<T>();
        Task Update(Guid id);
        Task Delete(Guid id);
    }
}