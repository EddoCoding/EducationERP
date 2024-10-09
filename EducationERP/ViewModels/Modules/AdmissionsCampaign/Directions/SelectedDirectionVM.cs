using System.Windows;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Directions
{
    public class SelectedDirectionVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameFaculty { get; set; } = string.Empty;
        public string NameLevel { get; set; } = string.Empty;
        public string CodeDirection { get; set; } = string.Empty;
        public string NameDirection { get; set; } = string.Empty;
        public string CodeProfile { get; set; } = string.Empty;
        public string NameProfile { get; set; } = string.Empty;
        public string NameFormEducation {  get; set; } = string.Empty;
        public string NameFormPayment { get; set; } = string.Empty;

        public bool Validation()
        {
            if(String.IsNullOrWhiteSpace(NameFaculty))
            {
                MessageBox.Show("Факультет не выбран!");
                return false;
            }
            if(String.IsNullOrWhiteSpace(NameLevel))
            {
                MessageBox.Show("Уровень не выбран!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(NameDirection))
            {
                MessageBox.Show("Направление не выбрано!");
                return false;
            }

            return true;
        }
    }
}