using Raketa;
using System.Collections.ObjectModel;
using System.Windows;

namespace EducationERP.ViewModels.Modules.Administration.SettingStructEducational
{
    public class FacultyVM : RaketaViewModel
    {
        string nameFaculty = string.Empty;
        string passwordFaculty = string.Empty;

        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameFaculty
        {
            get => nameFaculty;
            set => SetValue(ref nameFaculty, value);
        }
        public string PasswordFaculty
        {
            get => passwordFaculty;
            set => SetValue(ref passwordFaculty, value);
        }
        public ObservableCollection<DepartmentVM> Departments { get; set; } = new();
        public ObservableCollection<EducationGroupVM> EducationGroups { get; set; } = new();

        public bool Validation()
        {
            if (String.IsNullOrWhiteSpace(NameFaculty))
            {
                MessageBox.Show("Введите название факультета!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(PasswordFaculty))
            {
                MessageBox.Show("Введите пароль доступа к факультету!");
                return false;
            }

            return true;
        }
    }
}