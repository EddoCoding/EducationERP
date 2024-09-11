namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents
{
    public class InnViewModel : DocumentBaseViewModel
    {
        public string NumberINN { get; set; } = string.Empty;
        public DateOnly DateAssigned { get; set; }
        public string SeriesNumber { get; set; } = string.Empty;

        public InnViewModel() { TypeDocument = "Инн"; }
    }
}