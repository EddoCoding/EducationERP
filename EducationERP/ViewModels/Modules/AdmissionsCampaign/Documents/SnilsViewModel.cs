using System.Windows;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents
{
    public class SnilsViewModel : DocumentBaseViewModel
    {
        public string Number { get; set; } = string.Empty;
        public DateOnly RegistrationDate { get; set; }

        public SnilsViewModel() { TypeDocument = "Снилс"; }

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