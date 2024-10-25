using EducationERP.Models.Modules.EducationalInstitution;

namespace EducationERP.Models.Modules.DeanRoom.DocumentsStudent
{
    public abstract class DocumentStudentBase
    {
        public Guid Id { get; set; }
        public string TypeDocument { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string PlaceOfBirth { get; set; } = string.Empty;
        public string AdditionalInformation { get; set; } = string.Empty;

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}