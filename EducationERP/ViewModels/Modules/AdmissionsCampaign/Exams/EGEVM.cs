namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Exams
{
    public class EGEVM
    {
        public string AcademicSubject { get; set; } = string.Empty;
        public int SubjectScores { get; set; }

        public bool Validation()
        {
            if (String.IsNullOrWhiteSpace(AcademicSubject)) return false;
            if(SubjectScores < 0) return false;

            return true;
        }
    }
}