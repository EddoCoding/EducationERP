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

            bool user = _context.Users.Any(u => u.Username == "postgres" && 
                                                 u.Password == "qwerty");

            if (user) _serviceView.Window<EducationViewModel>().NonModal();
            else MessageBox.Show("Вход не возможен");
        }
        void ExitLogin() => _serviceView.Close<LoginViewModel>();
    }
}