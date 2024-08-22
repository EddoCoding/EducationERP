using EducationERP.Common.Components;
using EducationERP.Common.ToolsDev;
using EducationERP.ViewModels.LoginSetting;
using Microsoft.EntityFrameworkCore;
using Raketa;
using System.Windows;

namespace EducationERP.ViewModels.Login
{
    public class LoginViewModel : RaketaViewModel
    {
        public string Identifier { get; set; }
        public string Password { get; set; }

        public RaketaCommand LoginCommand { get; }
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
            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        void Login()
        {
            Dev.NotReady();
            //if (string.IsNullOrWhiteSpace(Identifier) || string.IsNullOrWhiteSpace(Password))
            //    MessageBox.Show("Заполните все поля!");
            //else
            //{
            //    var isConnected = _config.Login(Identifier, Password);
            //    if (isConnected)
            //    {
            //        if (_context.Database.GetPendingMigrations().Any())
            //            MessageBox.Show("Информационная система отсутствует!");
            //        else
            //        {
            //            _serviceView.Window<EducationViewModel>().NonModal();
            //            _serviceView.Close<LoginViewModel>();
            //        }
            //    }
            //}
        }
        void ExitLogin() => _serviceView.Close<LoginViewModel>();
    }
}