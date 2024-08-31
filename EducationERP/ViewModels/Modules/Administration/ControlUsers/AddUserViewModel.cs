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
        public RaketaTCommand<string> ChangeRoleAccessCommand { get; set; }

        IServiceView _serviceView;
        IUserRepository _userRepository;
        public AddUserViewModel(IServiceView serviceView, IUserRepository userRepository)
        {
            _serviceView = serviceView;
            _userRepository = userRepository;

            AddUserCommand = RaketaTCommand<User>.Launch(AddUser);
            ExitCommand = RaketaCommand.Launch(Exit);

            ChangeRoleAccessCommand = RaketaTCommand<string>.Launch(RoleAccess);
        }

        void AddUser(User user)
        {
            if (String.IsNullOrWhiteSpace(User.SurName) || String.IsNullOrWhiteSpace(User.Name)
                 || String.IsNullOrWhiteSpace(User.Identifier) || String.IsNullOrWhiteSpace(User.Password))
            {
                MessageBox.Show("Есть незаполненные поля!");
                return;
            }

            _userRepository.AddUser(user);
            _userRepository.Users.Add(new UserVM()
            {
                Id = user.Id,
                FullName = $"{user.SurName} {user.Name} {user.MiddleName}",
                Identifier = user.Identifier,
                Password = user.Password,
                ModuleAdministration = user.ModuleAdministration
            });
            _serviceView.Close<AddUserViewModel>();
        }
        void RoleAccess(string roleAccess)
        {
            if(roleAccess == "Без доступа")
            {
                User.ModuleAdministration = false;
                Visual.RoleAdministration = "Ограниченный";
            }
            else if(roleAccess == "Ограниченный")
            {
                User.ModuleAdministration = true;
                Visual.RoleAdministration = "Полный";
            }
            else
            {
                User.ModuleAdministration = null;
                Visual.RoleAdministration = "Без доступа";
            }
        }

        void Exit() => _serviceView.Close<AddUserViewModel>();
    }
}