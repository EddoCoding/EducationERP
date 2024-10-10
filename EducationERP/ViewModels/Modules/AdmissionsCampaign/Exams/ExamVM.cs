using System.Windows;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Exams
{
    public class ExamVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string AcademicSubject { get; set; } = string.Empty;
        public DateOnly DateExam { get; set; }
        public TimeOnly TimeExam { get; set; }
        public string LocationExam { get; set; } = string.Empty;
        public bool IsSpecial { get; set; }
        public string AdditionalIformation { get; set; } = string.Empty;

        public bool Validation()
        {
            if (String.IsNullOrWhiteSpace(AcademicSubject))
            {
                MessageBox.Show("Введите название сдаваемого предмета!");
                return false;
            }

            return true;
        }
    }
}