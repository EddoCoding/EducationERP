using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class SettingDirectionVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CodeDirection { get; set; } = string.Empty;
        public string NameDirection { get; set; } = string.Empty;
        public ObservableCollection<SettingProfileVM> Profiles { get; set; } = new();
    }
}