using EducationERP.Common.Components.Repositories;
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
        IUserRepository _userRepository;
        public LoginViewModel(IServiceView serviceView, IUserRepository userRepository)
        {
            _serviceView = serviceView;
            _userRepository = userRepository;

            LoginCommand = RaketaCommand.Launch(Login);
            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        void Login()
        {
            var user = _userRepository.GetUser(Identifier, Password);
            if (user != null)
            {
                var fullName = $"{user.SurName} {user.Name} {user.MiddleName}";
                _serviceView.Window<EducationViewModel>().NonModal();
                _serviceView.Close<LoginViewModel>();
            }
            else MessageBox.Show("Ошибка соединения!");
        }

        void ExitLogin() => _serviceView.Close<LoginViewModel>();
    }
}