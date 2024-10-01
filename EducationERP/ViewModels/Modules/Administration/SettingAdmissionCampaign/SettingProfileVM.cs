using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class SettingProfileVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CodeProfile { get; set; } = string.Empty;
        public string NameProfile { get; set; } = string.Empty;
        public ObservableCollection<SettingFormVM> Forms { get; set; } = new();
    }
}