namespace EducationERP.Models.Modules.AdmissionsCampaign.Educations
{
    public class EducationBase
    {
        public string TypeEducation { get; set; } = string.Empty;
        public string IdentificationDocument { get; set; } = string.Empty;
        public string IssuedBy { get; set; } = string.Empty;
        public DateOnly DateOfIssue { get; set; }
        public bool Honours { get; set; }
        public string AdditionalInformation { get; set; } = string.Empty;
    }
}