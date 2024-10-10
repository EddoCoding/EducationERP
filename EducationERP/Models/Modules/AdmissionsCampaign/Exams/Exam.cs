namespace EducationERP.Models.Modules.AdmissionsCampaign.Exams
{
    public class Exam
    {
        public Guid Id { get; set; }
        public string AcademicSubject { get; set; } = string.Empty;
        public DateOnly DateExam { get; set; }
        public TimeOnly TimeExam { get; set; }
        public string LocationExam { get; set; } = string.Empty;
        public bool IsSpecial { get; set; }
        public string AdditionalIformation { get; set; } = string.Empty;

        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}