using EducationERP.Models;

namespace EducationERP.Common.Components.Repositories
{
    public interface ILevelRepository
    {
        Task<bool> CreateLevel(EducationalLevelPreparation level);
        List<EducationalLevelPreparation> ReadLevels();
        Task DeleteLevel(Guid id);
    }
}