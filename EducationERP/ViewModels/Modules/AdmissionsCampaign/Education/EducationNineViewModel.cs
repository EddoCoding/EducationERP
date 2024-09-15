namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Education
{
    public class EducationNineViewModel : EducationBaseViewModel
    {
        public string CodeSeriesNumber { get; set; } = string.Empty;

        public EducationNineViewModel()
        {
            TypeEducation = "Основное общее образование (9)";
            IdentificationDocument = "Аттестат об основном общем образовании (9)";
        }

        public override bool Validation()
        {
            throw new NotImplementedException();
        }
    }
}