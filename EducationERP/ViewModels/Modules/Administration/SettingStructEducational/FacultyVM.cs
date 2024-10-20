using Raketa;

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
        //public ObservableCollection<string> Departments { get; set; } = new();
    }
}