namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Education
{
    public class EducationElevenViewModel : EducationBaseViewModel
    {
        public string CodeSeriesNumber { get; set; } = string.Empty;

        public EducationElevenViewModel()
        {
            TypeEducation = "Среднее общее образование (11)";
            IdentificationDocument = "Аттестат о среднем общем образовании (11)";
        }

        public override bool Validation()
        {
            throw new NotImplementedException();
        }
    }
}
