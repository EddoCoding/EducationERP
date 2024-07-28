using EducationERP.Modules.Components.Notification.VM;
using Npgsql;
using Raketa;
using Raketa.Commands;
using Raketa.IoC;
using System.Configuration;
using System.Data;
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
        public LoginViewModel(IServiceView serviceView, Action exitWindow)
        {
            _serviceView = serviceView;

            LoginCommand = RaketaCommand.Launch(Login);
            SettingBDCommand = RaketaCommand.Launch(OpenSettingBD);
            ExitCommand = RaketaCommand.Launch(exitWindow);
        }

        void Login()
        {
            if (String.IsNullOrWhiteSpace(Identifier) || String.IsNullOrWhiteSpace(Password))
                _serviceView.ShowView<NoteViewModel>("Не все поля заполнены!");
            else
            {
                try
                {
                    var stringConnection = $"Host={ConfigurationManager.AppSettings["Host"]};" +
                                           $"Port={ConfigurationManager.AppSettings["Port"]};" +
                                           $"Username={Identifier};" +
                                           $"Password={Password};" +
                                           $"Database={ConfigurationManager.AppSettings["Database"]};";

                    using (var connection = new NpgsqlConnection(stringConnection)) connection.Open();
                    _serviceView.ShowView<NoteViewModel>("Подключение");


                }
                catch { _serviceView.ShowView<NoteViewModel>("Ошибка подключения"); }
            }
        }
        void OpenSettingBD() => _serviceView.ShowView<SettingBDViewModel>();
    }
}