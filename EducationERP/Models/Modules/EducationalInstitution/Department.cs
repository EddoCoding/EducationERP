namespace EducationERP.Models.Modules.EducationalInstitution
{
    public class Department
    {
        public Guid Id { get; set; }
        public string NameDepartment { get; set; }

        public Guid FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}