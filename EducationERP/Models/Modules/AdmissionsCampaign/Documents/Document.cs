namespace EducationERP.Models.Modules.AdmissionsCampaign
{
    public class Document
    {
        public Guid Id { get; set; }
        public string TypeDocument { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; } = string.Empty;
        public string AdditionalInformation { get; set; } = string.Empty;

        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}