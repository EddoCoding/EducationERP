using EducationERP.Models;
using EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign;

namespace EducationERP.Common.Components.Repositories
{
    public interface ILevelRepository
    {
        Task<bool> Create(EducationalLevelPreparation level);
        List<EducationalLevelPreparationVM> Read();
        Task Update(Guid id);
        Task Delete(Guid id);
    }
}