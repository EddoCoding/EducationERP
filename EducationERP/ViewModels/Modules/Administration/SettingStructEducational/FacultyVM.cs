namespace EducationERP.ViewModels.Modules.Administration.SettingStructEducational
{
    public class FacultyVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameFaculty { get; set; } = string.Empty;
        public string PasswordFaculty { get; set; } = string.Empty;
        //public ObservableCollection<string> Departments { get; set; } = new();
    }
}