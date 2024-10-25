using EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents;
using System.Windows;

namespace EducationERP.ViewModels.Modules.DeanRoom.DocumentsStudent
{
    class ForeignPassportStudentVM : DocumentBaseViewModel
    {
        public string IssuedBy { get; set; } = string.Empty;
        public DateOnly DateOfIssue { get; set; }
        public string SeriesNumber { get; set; } = string.Empty;
        public ForeignPassportStudentVM() { TypeDocument = "Иностранный паспорт"; }

        public override bool Validation()
        {
            if (String.IsNullOrWhiteSpace(SurName) || String.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Неполные данные!");
                return false;
            }
            if (DateOfBirth == default || DateOfBirth > DateOnly.FromDateTime(DateTime.Now))
            {
                MessageBox.Show("Дата рождения не указана или указана неверно!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(Gender))
            {
                MessageBox.Show("Пол не указан!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(PlaceOfBirth))
            {
                MessageBox.Show("Место рождения не указано!");
                return false;
            }
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
            if (String.IsNullOrWhiteSpace(SeriesNumber))
            {
                MessageBox.Show("Серия и номер не указаны!");
                return false;
            }

            return true;
        }
    }
}