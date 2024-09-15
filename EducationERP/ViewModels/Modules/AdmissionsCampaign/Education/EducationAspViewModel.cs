using System.Windows;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Education
{
    public class EducationAspViewModel : EducationBaseViewModel
    {
        public string FormOfEducation { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string DiplomaSeries { get; set; } = string.Empty;
        public string DiplomaNumber { get; set; } = string.Empty;
        public string SupplementSeries { get; set; } = string.Empty;
        public string SupplementNumber { get; set; } = string.Empty;

        public EducationAspViewModel()
        {
            TypeEducation = "Аспирантура";
            IdentificationDocument = "Диплом аспирантуры";
        }

        public override bool Validation()
        {
            if (String.IsNullOrWhiteSpace(IssuedBy))
            {
                MessageBox.Show("Выдан кем не указано!");
                return false;
            }
            if (DateOfIssue == default || DateOfIssue > DateOnly.FromDateTime(DateTime.Now))
            {
                MessageBox.Show("Дата выдачи не указана или указана неверно!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(FormOfEducation))
            {
                MessageBox.Show("Форма обучения не указана!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(RegistrationNumber))
            {
                MessageBox.Show("Регистрационный номер не указан!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(DiplomaSeries))
            {
                MessageBox.Show("Серия диплома не указана!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(DiplomaNumber))
            {
                MessageBox.Show("Номер диплома не указан!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(SupplementSeries))
            {
                MessageBox.Show("Серия приложения не указана!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(SupplementNumber))
            {
                MessageBox.Show("Номер приложения не указан!");
                return false;
            }

            return true;
        }
    }
}