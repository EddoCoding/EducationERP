using EducationERP.Common.Components;
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
            if (!_context.CanConnect()) return;

            var user = _context.Users.FirstOrDefault(u => u.Identifier == Identifier && u.Password == Password);

            if (user != null)
            {
                var fullName = $"{user.SurName} {user.Name} {user.MiddleName}";
                _serviceView.Window<EducationViewModel>(default, fullName).NonModal();
                _serviceView.Close<LoginViewModel>();
            }
            else MessageBox.Show("Ошибка соединения!");

        }
        void ExitLogin() => _serviceView.Close<LoginViewModel>();
    }
}