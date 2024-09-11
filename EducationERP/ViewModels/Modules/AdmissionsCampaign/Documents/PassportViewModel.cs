namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents
{
    public class PassportViewModel : DocumentBaseViewModel
    {
        public string IssuedBy { get; set; } = string.Empty;
        public DateOnly DateOfIssue { get; set; }
        public string DepartmentCode { get; set; } = string.Empty;
        public string SeriesNumber { get; set; } = string.Empty;

        public PassportViewModel() { TypeDocument = "Паспорт"; }
    }
}