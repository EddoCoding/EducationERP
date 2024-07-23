using Raketa;
using Raketa.Commands;
using Raketa.IoC;
using System.Windows;

namespace EducationERP.Modules.Login.VM
{
    public class LoginViewModel : ViewModel
    {
        public string Identifier { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public RaketaCommand LoginCommand { get; }
        public RaketaCommand SettingBDCommand { get; }
        public RaketaCommand ExitCommand { get; }

        IServiceView _serviceView;
        public LoginViewModel(IServiceView service, Action exitWindow)
        {
            _serviceView = service;

            LoginCommand = RaketaCommand.Launch(Login);
            SettingBDCommand = RaketaCommand.Launch(OpenSettingBD);
            ExitCommand = RaketaCommand.Launch(exitWindow);
        }

        void Login() => MessageBox.Show("Вход");
        void OpenSettingBD() => _serviceView.ShowView<SettingBDViewModel>();
    }
}