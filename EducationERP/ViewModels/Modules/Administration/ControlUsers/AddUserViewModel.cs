using EducationERP.Common.Components.Repositories;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.ControlUsers
{
    public class AddUserViewModel : RaketaViewModel
    {
        public RaketaCommand Command { get; set; }
        public RaketaCommand CommandExit { get; set; }

        IServiceView _serviceView;
        IUserRepository _userRepository;
        public AddUserViewModel(IServiceView serviceView, IUserRepository userRepository)
        {
            _serviceView = serviceView;
            _userRepository = userRepository;

            Command = RaketaCommand.Launch(AddUser);
            CommandExit = RaketaCommand.Launch(Exit);
        }

        void AddUser()
        {
            _userRepository.Users.Add(new UserVM()
            {
                Identifier = "sadsad",
                Password = "asdsadasfs",
                FullName = "Викторова Виктория Викторовна"
            });
        }
        void Exit() => _serviceView.Close<AddUserViewModel>();
    }
}