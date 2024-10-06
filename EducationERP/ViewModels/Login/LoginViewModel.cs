using EducationERP.Common.Components;
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
        UserSystem _userSystem;
        public LoginViewModel(IServiceView serviceView, IUserRepository userRepository, UserSystem userSystem)
        {
            _serviceView = serviceView;
            _userRepository = userRepository;
            _userSystem = userSystem;

            LoginCommand = RaketaCommand.Launch(LoginAsync);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        async void LoginAsync()
        {
            var user = await _userRepository.GetUserAsync(Identifier, Password);
            if (user != null)
            {
                _userSystem.FullName = $"{user.SurName} {user.Name} {user.MiddleName}";
                _userSystem.Administration = user.ModuleAdministration;
                _userSystem.AdmissionsCampaign = user.ModuleAdmissionsCampaign;

                _serviceView.Window<EducationViewModel>().NonModal();
                _serviceView.Close<LoginViewModel>();
            }
            else MessageBox.Show("Ошибка соединения!");
        }

        void CloseWindow() => _serviceView.Close<LoginViewModel>();
    }
}