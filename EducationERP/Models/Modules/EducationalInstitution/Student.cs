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

        public string Accepted { get; set; } = string.Empty;

        public Guid EducationGroupId { get; set; }
        public EducationGroup EducationGroup { get; set; }
    }
}