namespace EducationERP.Models.Modules.EducationalInstitution
{
    public class Student
    {
        public Guid Id { get; set; }

        public Guid EducationGroupId { get; set; }
        public EducationGroup EducationGroup { get; set; }
    }
}