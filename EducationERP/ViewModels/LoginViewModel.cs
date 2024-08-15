using EducationERP.Common.Components;
using Microsoft.EntityFrameworkCore;
using Raketa;
using System.Windows;

namespace EducationERP.ViewModels
{
    public class LoginViewModel : RaketaViewModel
    {
        public string Identifier { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public RaketaCommand LoginCommand { get; }
        public RaketaCommand CreateISCommand { get; }
        public RaketaCommand SettingBDCommand { get; }
        public RaketaCommand ExitCommand { get; }

        IServiceView _serviceView;
        IConfig _config;
        DataContext _context;
        public LoginViewModel(IServiceView serviceView, IConfig config, DataContext context)
        {
            _serviceView = serviceView;
            _config = config;
            _context = context;

            LoginCommand = RaketaCommand.Launch(Login);
            CreateISCommand = RaketaCommand.Launch(CreateIS);
            SettingBDCommand = RaketaCommand.Launch(OpenSettingBD);
            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        void Login()
        {
            if (string.IsNullOrWhiteSpace(Identifier) || string.IsNullOrWhiteSpace(Password))
                MessageBox.Show("Заполните все поля!");
            else
            {
                var isConnected = _config.Login(Identifier, Password);
                if(isConnected)
                {
                    _serviceView.Window<EducationViewModel>().NonModal();
                    _serviceView.Close<LoginViewModel>();
                }
            }
        }
        void CreateIS()
        {
            _context.Database.GetDbConnection().ConnectionString = _config.GetStrConnection(Identifier, Password);
            var isConnection = _context.IsConnection();
            if (isConnection)
            {
                if (_context.Database.GetPendingMigrations().Any())
                {
                    _context.Database.Migrate();
                    MessageBox.Show("Информационная система сформирована!");
                }
                else MessageBox.Show("Информационная система уже есть!");
            }
        }
        void OpenSettingBD() => _serviceView.Window<SettingBDViewModel>().Modal();
        void ExitLogin() => _serviceView.Close<LoginViewModel>();
    }
}