using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class EducationalProfileVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ProfileCode { get; set; } = string.Empty;
        public string ProfileName { get; set; } = string.Empty;
        public ObservableCollection<string> FormsOfTraining { get; set; } = new();
    }
}