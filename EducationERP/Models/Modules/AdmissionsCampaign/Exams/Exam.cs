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
        public string AdditionalInformation { get; set; } = string.Empty;
        public int SubjectScores { get; set; }

        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}