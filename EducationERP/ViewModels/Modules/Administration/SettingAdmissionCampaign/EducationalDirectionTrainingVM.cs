using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class EducationalDirectionTrainingVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string DirectionCode { get; set; } = string.Empty;
        public string DirectionName { get; set; } = string.Empty;
        public ObservableCollection<EducationalProfileVM> EducationalProfiles { get; set; } = new();
    }
}