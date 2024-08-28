using EducationERP.Common.Components.Repositories;
using EducationERP.Models;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.ControlUsers
{
    public class AddUserViewModel : RaketaViewModel
    {
        public User User { get; set; } = new();


        public RaketaTCommand<User> AddUserCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        IUserRepository _userRepository;
        public AddUserViewModel(IServiceView serviceView, IUserRepository userRepository)
        {
            _serviceView = serviceView;
            _userRepository = userRepository;

            AddUserCommand = RaketaTCommand<User>.Launch(AddUser);
            ExitCommand = RaketaCommand.Launch(Exit);
        }

        void AddUser(User user)
        {
            _userRepository.AddUser(user);
            _userRepository.Users.Add(new UserVM()
            {
                FullName = $"{user.SurName} {user.Name} {user.MiddleName}",
                Identifier = user.Identifier,
                Password = user.Password
            });
            _serviceView.Close<AddUserViewModel>();
        }
        void Exit() => _serviceView.Close<AddUserViewModel>();
    }
}