using EducationERP.Models.Modules.DeanRoom.DocumentsStudent;
using static EducationERP.ViewModels.Modules.DeanRoom.AddEducationGroupViewModel;

namespace EducationERP.Models.Modules.EducationalInstitution
{
    public class Student
    {
        public Guid Id { get; set; }
        #region Личная информация
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string PlaceOfBirth { get; set; } = string.Empty;
        public string Citizenship { get; set; } = string.Empty;
        public DateOnly CitizenshipValidFrom { get; set; }
        public bool IsNeedHostel { get; set; }
        public bool IsNotNeedHostel { get; set; }
        #endregion
        #region Контактная информация
        public string ResidentialAddress { get; set; } = string.Empty;
        public string AddressOfRegistration { get; set; } = string.Empty;
        public string HomePhone { get; set; } = string.Empty;
        public string MobilePhone { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string AdditionalContactInformation { get; set; } = string.Empty;
        #endregion
        #region Доп. свойства, коллекции
        public string Accepted { get; set; } = string.Empty;
        public ICollection<DocumentStudentBase> Documents { get; set; }
        #endregion
        #region Где учится
        public string NameEducationGroup { get; set; } = string.Empty;
        public string LevelGroup { get; set; } = string.Empty;
        public string FormGroup { get; set; } = string.Empty;
        public GroupTypes TypeGroup { get; set; }
        public int Course { get; set; }
        public string CodeDirection { get; set; } = string.Empty;
        public string NameDirection { get; set; } = string.Empty;
        public string CodeProfile { get; set; } = string.Empty;
        public string NameProfile { get; set; } = string.Empty;
        #endregion

        public Guid EducationGroupId { get; set; }
        public EducationGroup EducationGroup { get; set; }
    }
}