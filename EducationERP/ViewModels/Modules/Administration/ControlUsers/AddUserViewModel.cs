using EducationERP.Common.Components.Repositories;
using EducationERP.Models;
using Raketa;
using System.Windows;

namespace EducationERP.ViewModels.Modules.Administration.ControlUsers
{
    public class AddUserViewModel : RaketaViewModel
    {
        public User User { get; set; } = new();
        public UserVM UserVM { get; set; } = new();
        public VisualAddUser Visual { get; set; } = new();


        public RaketaTCommand<User> AddUserCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }
        public RaketaTCommand<string> Command { get; set; }

        IServiceView _serviceView;
        IUserRepository _userRepository;
        public AddUserViewModel(IServiceView serviceView, IUserRepository userRepository)
        {
            _serviceView = serviceView;
            _userRepository = userRepository;

            AddUserCommand = RaketaTCommand<User>.Launch(AddUser);
            ExitCommand = RaketaCommand.Launch(Exit);

            Command = RaketaTCommand<string>.Launch(Visible);
        }

        void AddUser(User user)
        {
            if (String.IsNullOrWhiteSpace(User.SurName) || String.IsNullOrWhiteSpace(User.Name)
                 || String.IsNullOrWhiteSpace(User.Identifier) || String.IsNullOrWhiteSpace(User.Password))
            {
                MessageBox.Show("Есть незаполненные поля!");
                return;
            }

            user.RoleAndAccesses = UserVM.RolesAndAccesses;

            _userRepository.AddUser(user);
            _userRepository.Users.Add(new UserVM()
            {
                Id = user.Id,
                FullName = $"{user.SurName} {user.Name} {user.MiddleName}",
                Identifier = user.Identifier,
                Password = user.Password
            });
            _serviceView.Close<AddUserViewModel>();
        }

        void Visible(string role)
        {
            switch(role)
            {
                case "Администрирование":
                    if (Visual.AdministrationVisibility == Visibility.Collapsed)
                        Visual.AdministrationVisibility = Visibility.Visible;
                    else
                    {
                        Visual.AdministrationVisibility = Visibility.Collapsed;
                        UserVM.AccessAdministration = false;
                    }
                    break;
            }
        }

        void Exit() => _serviceView.Close<AddUserViewModel>();
    }
}