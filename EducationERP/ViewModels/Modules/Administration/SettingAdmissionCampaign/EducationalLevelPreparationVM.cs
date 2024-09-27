using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class EducationalLevelPreparationVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string LevelName { get; set; } = string.Empty;
        public ObservableCollection<EducationalDirectionTrainingVM> DirectionsTraining { get; set; } = new();
    }
}