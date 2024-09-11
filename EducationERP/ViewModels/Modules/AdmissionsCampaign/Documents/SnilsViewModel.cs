namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents
{
    public class SnilsViewModel : DocumentBaseViewModel
    {
        public string Number { get; set; } = string.Empty;
        public DateOnly RegistrationDate { get; set; }

        public SnilsViewModel() { TypeDocument = "Снилс"; }
    }
}