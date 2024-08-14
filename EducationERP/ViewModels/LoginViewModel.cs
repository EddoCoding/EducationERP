using EducationERP.Common.Components;
using Npgsql;
using Raketa;
using System.Configuration;
using System.Windows;

namespace EducationERP.ViewModels
{
    public class LoginViewModel : RaketaViewModel
    {
        public string Identifier { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public RaketaCommand LoginCommand { get; }
        public RaketaCommand SettingBDCommand { get; }
        public RaketaCommand ExitCommand { get; }

        IServiceView _serviceView;
        DataContext _dataContext;
        public LoginViewModel(IServiceView serviceView)
        {
            _serviceView = serviceView;

            LoginCommand = RaketaCommand.Launch(Login);
            SettingBDCommand = RaketaCommand.Launch(OpenSettingBD);
            ExitCommand = RaketaCommand.Launch(ExitSettingBD);
        }

        void Login()
        {
            if (string.IsNullOrWhiteSpace(Identifier) || string.IsNullOrWhiteSpace(Password))
                MessageBox.Show("Не все поля заполнены!");
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

                    MessageBox.Show("Подключено");              // -- ДЛЯ ПРОВЕРКИ, ПОТОМ УБРАТЬ --
                    
                    ConnectionProvider.StrConnection = stringConnection;

                    using (var context = new DataContext()) context.Database.EnsureCreated();
                }
                catch { MessageBox.Show("Ошибка подключения"); }
            }
        }
        void OpenSettingBD() => _serviceView.Window<SettingBDViewModel>().Modal();
        void ExitSettingBD() => _serviceView.Close<LoginViewModel>();
    }
}