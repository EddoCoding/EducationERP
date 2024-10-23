using EducationERP.ViewModels.Modules.DeanRoom;
using System.Collections.ObjectModel;
using static EducationERP.ViewModels.Modules.DeanRoom.AddEducationGroupViewModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingStructEducational
{
    public class EducationGroupVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CodeEducationGroup { get; set; } = string.Empty;
        public string NameEducationGroup { get; set; } = string.Empty;
        public string LevelGroup { get; set; } = string.Empty;
        public string FormGroup { get; set; } = string.Empty;
        public GroupTypes TypeGroup { get; set; }
        public int Course { get; set; }
        public int MaxNumberStudents { get; set; }
        public string CodeDirection { get; set; } = string.Empty;
        public string NameDirection { get; set; } = string.Empty;
        public string CodeProfile { get; set; } = string.Empty;
        public string NameProfile { get; set; } = string.Empty;
        public ObservableCollection<StudentVM> Students { get; set; } = new();
        public string NameCuratorGroup { get; set; } = string.Empty;
        public string NameHeadmanGroup { get; set; } = string.Empty;
        public string Formed { get; set; } = string.Empty;
        public DateOnly DateOfFormed { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}