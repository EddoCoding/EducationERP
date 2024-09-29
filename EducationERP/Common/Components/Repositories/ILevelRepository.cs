using EducationERP.Models;

namespace EducationERP.Common.Components.Repositories
{
    public interface ILevelRepository
    {
        Task<bool> Create(EducationalLevelPreparation level);
        List<EducationalLevelPreparation> Read();
        Task Update(Guid id);
        Task Delete(Guid id);
    }
}