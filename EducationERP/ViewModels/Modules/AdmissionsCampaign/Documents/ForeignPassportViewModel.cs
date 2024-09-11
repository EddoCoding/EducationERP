namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents
{
    public class ForeignPassportViewModel : DocumentBaseViewModel
    {
        public string IssuedBy { get; set; } = string.Empty;
        public DateOnly DateOfIssue { get; set; }
        public string SeriesNumber { get; set; } = string.Empty;

        public ForeignPassportViewModel() { TypeDocument = "Иностранный паспорт"; }
    }
}