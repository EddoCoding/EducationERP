namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Education
{
    public class EducationElevenViewModel : EducationBaseViewModel
    {
        public string Code { get; set; } = string.Empty;
        public string Series { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;

        public EducationElevenViewModel()
        {
            TypeEducation = "Среднее общее образование";
            IdentificationDocument = "Аттестат о среднем общем образовании";
        }

        public override bool Validation()
        {
            throw new NotImplementedException();
        }
    }
}
