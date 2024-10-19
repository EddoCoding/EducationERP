namespace EducationERP.Models.Modules.EducationalInstitution
{
    public class Faculty
    {
        public Guid Id { get; set; }
        public string NameFaculty { get; set; } = string.Empty;
        public string PasswordFaculty { get; set; } = string.Empty;
        //public ICollection<string> Departments { get; set; }

        public Guid StructEducationalInstitutionId { get; set; }
        public StructEducationalInstitution StructEducationalInstitution { get; set; }
    }
}