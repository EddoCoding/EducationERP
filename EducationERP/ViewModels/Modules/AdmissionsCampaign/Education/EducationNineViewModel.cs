using System.Windows;

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
            if (String.IsNullOrWhiteSpace(CodeSeriesNumber))
            {
                MessageBox.Show("Код, серия и номер аттестата не указаны!");
                return false;
            }

            return true;
        }
    }
}