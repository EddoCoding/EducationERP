using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class SettingLevelVM : RaketaViewModel
    {
        string nameLevel = string.Empty;

        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameLevel
        {
            get => nameLevel;
            set => SetValue(ref nameLevel, value);
        }
        public ObservableCollection<SettingDirectionVM> Directions { get; set; } = new();
    }
}