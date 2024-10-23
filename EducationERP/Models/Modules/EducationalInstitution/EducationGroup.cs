using static EducationERP.ViewModels.Modules.DeanRoom.AddEducationGroupViewModel;

namespace EducationERP.Models.Modules.EducationalInstitution
{
    public class EducationGroup
    {
        public Guid Id { get; set; }
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
        public ICollection<Student> Students { get; set; }
        public string NameCuratorGroup { get; set; } = string.Empty;
        public string NameHeadmanGroup { get; set; } = string.Empty;
        public string Formed { get; set; } = string.Empty;
        public DateOnly DateOfFormed { get; set; }

        // Расписание (Объект один к одному)
        // Журнал посещений (Объект один к одному)
        // История группы (Объект один к одному) - будет хранить дату формирования, кто когда зачислен, увлен и т.д. - сделать потом.

        //public ICollection<Student> { get; set; }

        public Guid FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}