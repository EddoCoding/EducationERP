using System.Windows;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Exams
{
    public class EGEVM
    {
        public Guid Id { get; set; } = Guid .NewGuid();
        public string AcademicSubject { get; set; } = string.Empty;
        public int SubjectScores { get; set; }

        public bool Validation()
        {
            if (String.IsNullOrWhiteSpace(AcademicSubject) || String.IsNullOrWhiteSpace(SubjectScores.ToString()))
            {
                MessageBox.Show("Данные неполные!");
                return false;
            }
            if(SubjectScores < 0)
            {
                MessageBox.Show("Балл не может быть меньше нуля");
                return false;
            }

            return true;
        }
    }
}