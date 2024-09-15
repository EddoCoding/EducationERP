using System.Windows;

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
