namespace EducationERP.Models.Modules.EducationalInstitution
{
    public class Faculty
    {
        public Guid Id { get; set; }
        public string NameFaculty { get; set; } = string.Empty;
        public string PasswordFaculty { get; set; } = string.Empty;
        public ICollection<Department> Departments { get; set; }
        public ICollection<EducationGroup> EducationGroups { get; set; }

        public Guid StructEducationalInstitutionId { get; set; }
        public StructEducationalInstitution StructEducationalInstitution { get; set; }
    }
}