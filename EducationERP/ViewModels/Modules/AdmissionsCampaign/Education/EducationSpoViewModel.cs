namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Education
{
    public class EducationSpoViewModel : EducationBaseViewModel
    {
        public string FormOfEducation { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string DiplomaSeries { get; set; } = string.Empty;
        public string DiplomaNumber { get; set; } = string.Empty;
        public string SupplementSeries { get; set; } = string.Empty;
        public string SupplementNumber { get; set; } = string.Empty;

        public EducationSpoViewModel()
        {
            TypeEducation = "Среднее профессиональное образование";
            IdentificationDocument = "Диплом о среднем профессиональном образовании";
        }

        public override bool Validation()
        {
            throw new NotImplementedException();
        }
    }
}