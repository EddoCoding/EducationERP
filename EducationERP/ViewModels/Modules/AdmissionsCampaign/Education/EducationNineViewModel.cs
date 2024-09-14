namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Education
{
    public class EducationNineViewModel : EducationBaseViewModel
    {
        public string Code { get; set; } = string.Empty;
        public string Series { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;

        public EducationNineViewModel()
        {
            TypeEducation = "Основное общее образование";
            IdentificationDocument = "Аттестат об основном общем образовании";
        }

        public override bool Validation()
        {
            throw new NotImplementedException();
        }
    }
}