using Raketa;
using System.Windows;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class SettingDirectionVM : RaketaViewModel
    {
        string nameFormEducation = string.Empty;
        string nameFormPayment = string.Empty;

        public Guid Id { get; set; } = Guid.NewGuid();
        public string CodeDirection { get; set; } = string.Empty;
        public string NameDirection { get; set; } = string.Empty;
        public string CodeProfile { get; set; } = string.Empty;
        public string NameProfile { get; set; } = string.Empty;
        public string NameFormEducation
        {
            get => nameFormEducation;
            set =>  SetValue(ref nameFormEducation, value);
        }
        public string NameFormPayment
        {
            get => nameFormPayment;
            set => SetValue(ref nameFormPayment, value);
        }

        public bool Validation()
        {
            if (String.IsNullOrWhiteSpace(NameDirection))
            {
                MessageBox.Show("Введите название направления подготовки!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(NameFormEducation))
            {
                MessageBox.Show("Введите форму обучения!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(NameFormPayment))
            {
                MessageBox.Show("Введите форму оплаты!");
                return false;
            }

            return true;
        }
    }
}