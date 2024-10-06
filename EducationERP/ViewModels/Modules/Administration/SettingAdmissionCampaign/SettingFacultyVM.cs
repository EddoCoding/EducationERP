using System.Collections.ObjectModel;
using System.Windows;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class SettingFacultyVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameFaculty { get; set; } = string.Empty;
        public ObservableCollection<SettingLevelVM> Levels { get; set; } = new();

        public bool Validation()
        {
            if (String.IsNullOrWhiteSpace(NameFaculty))
            {
                MessageBox.Show("Введите название факультета!");
                return false;
            }

            return true;
        }
    }
}