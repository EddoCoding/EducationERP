using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingStructEducational
{
    public class StructEducationalInstitutionVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameVUZ { get; set; } = string.Empty;
        public string ShortNameVUZ { get; set; } = string.Empty;
        public ObservableCollection<FacultyVM> Faculties { get; set; } = new();
    }
}