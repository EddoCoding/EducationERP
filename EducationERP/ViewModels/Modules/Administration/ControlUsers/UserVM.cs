using Raketa;
using System.Windows;

namespace EducationERP.ViewModels.Modules.Administration.ControlUsers
{
    public class UserVM : RaketaViewModel
    {
        string identifier = string.Empty;
        string password = string.Empty;

        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; } = string.Empty;
        public string Identifier
        {
            get => identifier;
            set => SetValue(ref identifier, value);
        }
        public string Password
        {
            get => password;
            set => SetValue(ref password, value);
        }

        public bool? ModuleAdmissionsCampaign { get; set; } = null;
        public bool? ModuleAdministration { get; set; } = null;
        public bool? ModuleDeanRoom { get; set; } = null;

        public bool Validation()
        {
            if(String.IsNullOrWhiteSpace(Identifier))
            {
                MessageBox.Show("Идентификатор не может быть пустым!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Пароль не может быть пустым!");
                return false;
            }

            return true;
        }
    }
}