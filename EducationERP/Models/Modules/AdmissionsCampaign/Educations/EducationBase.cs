namespace EducationERP.Models.Modules.AdmissionsCampaign.Educations
{
    public class EducationBase
    {
        public Guid Id { get; set; }
        public string TypeEducation { get; set; } = string.Empty;
        public string IdentificationDocument { get; set; } = string.Empty;
        public string IssuedBy { get; set; } = string.Empty;
        public DateOnly DateOfIssue { get; set; }
        public bool Honours { get; set; }
        public string AdditionalInformation { get; set; } = string.Empty;

        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}