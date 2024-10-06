namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Education
{
    public abstract class EducationBaseViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TypeEducation { get; set; } = string.Empty;                         
        public string IdentificationDocument { get; set; } = string.Empty;
        public string IssuedBy { get; set; } = string.Empty;
        public DateOnly DateOfIssue { get; set; }
        public bool Honours { get; set; }
        public string AdditionalInformation { get; set; } = string.Empty;

        public abstract bool Validation();
    }
}