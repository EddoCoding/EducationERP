namespace EducationERP.Models.Modules.AdmissionsCampaign.Exams
{
    public class EGE
    {
        public Guid Id { get; set; }
        public string AcademicSubject { get; set; } = string.Empty;
        public int SubjectScores { get; set; }

        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}