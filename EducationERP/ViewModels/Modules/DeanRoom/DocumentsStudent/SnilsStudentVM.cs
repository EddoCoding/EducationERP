using EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents;
using System.Windows;

namespace EducationERP.ViewModels.Modules.DeanRoom.DocumentsStudent
{
    public class SnilsStudentVM : DocumentStudentBaseVM
    {
        public string Number { get; set; } = string.Empty;
        public DateOnly RegistrationDate { get; set; }
        public SnilsStudentVM() { TypeDocument = "Снилс"; }

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
            if (String.IsNullOrWhiteSpace(Number))
            {
                MessageBox.Show("Номер Снилс не указан!");
                return false;
            }
            if (RegistrationDate == default || RegistrationDate > DateOnly.FromDateTime(DateTime.Now))
            {
                MessageBox.Show("Дата регистрации не указана или указана неверно!");
                return false;
            }

            return true;
        }
    }
}