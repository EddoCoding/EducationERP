namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Education
{
    public abstract class EducationBaseViewModel
    {
        public string TypeEducation { get; set; } = string.Empty;                         // -- Тип образования --
        public string IdentificationDocument { get; set; } = string.Empty;                // -- Удостоверяющий документ --
        public string IssuedBy { get; set; } = string.Empty;                              
        public DateTime DateOfIssue { get; set; }                                         
        public bool Honours { get; set; }                                                 // -- С отличием -- 
        public string AdditionalInformation { get; set; } = string.Empty;                 

        public abstract bool Validation();
    }
}