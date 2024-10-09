namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Directions
{
    public class SelectedDirectionVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameFaculty { get; set; } = string.Empty;
        public string NameLevel { get; set; } = string.Empty;
        public string CodeDirection { get; set; } = string.Empty;
        public string NameDirection { get; set; } = string.Empty;
        public string CodeProfile { get; set; } = string.Empty;
        public string NameProfile { get; set; } = string.Empty;
        public string NameFormEducation {  get; set; } = string.Empty;
        public string NameFormPayment { get; set; } = string.Empty;
    }
}