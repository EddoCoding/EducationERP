using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.Administration.SettingUser;
using Raketa;
using System.Text;
using System.Windows;

namespace EducationERP.ViewModels.Modules.Administration.ControlUsers
{
    public class AddUserViewModel : RaketaViewModel
    {
        public User User { get; set; } = new();
        public UserVM UserVM { get; set; } = new();
        public VisualAddUser Visual { get; set; } = new();

        public RaketaCommand GenerationIdentifierCommand { get; set; }
        public RaketaCommand GenerationPasswordCommand { get; set; }
        public RaketaTCommand<User> AddUserCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        public RaketaTCommand<string> ChangeRoleAccessAdmissionsCampaignCommand { get; set; }
        public RaketaTCommand<string> ChangeRoleAccessAdministrationCommand { get; set; }

        IServiceView _serviceView;
        IUserRepository _userRepository;
        public AddUserViewModel(IServiceView serviceView, IUserRepository userRepository)
        {
            _serviceView = serviceView;
            _userRepository = userRepository;

            GenerationIdentifierCommand = RaketaCommand.Launch(GenerationIdentifier);
            GenerationPasswordCommand = RaketaCommand.Launch(GenerationPassword);
            AddUserCommand = RaketaTCommand<User>.Launch(AddUser);
            ExitCommand = RaketaCommand.Launch(Exit);

            ChangeRoleAccessAdmissionsCampaignCommand = RaketaTCommand<string>.Launch(RoleAccessAdmissionsCampaign);
            ChangeRoleAccessAdministrationCommand = RaketaTCommand<string>.Launch(RoleAccessAdministration);
        }

        void GenerationIdentifier() => User.Identifier = Generation();
        void GenerationPassword() => User.Password = Generation();

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

        void RoleAccessAdmissionsCampaign(string roleAccess)
        {
            if (roleAccess == "Без доступа")
            {
                User.ModuleAdmissionsCampaign = false;
                Visual.RoleAdmissionsCampaign = "Ограниченный";
            }
            else if (roleAccess == "Ограниченный")
            {
                User.ModuleAdmissionsCampaign = true;
                Visual.RoleAdmissionsCampaign = "Полный";
            }
            else
            {
                User.ModuleAdmissionsCampaign = null;
                Visual.RoleAdmissionsCampaign = "Без доступа";
            }
        }
        void RoleAccessAdministration(string roleAccess)
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

        string Generation()
        {
            string signs = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder sb = new StringBuilder(8);

            for (int i = 0; i < 8; i++)
            {
                int index = new Random().Next(signs.Length);
                sb.Append(signs[index]);
            }

            return sb.ToString();
        }
        void Exit() => _serviceView.Close<AddUserViewModel>();
    }
}