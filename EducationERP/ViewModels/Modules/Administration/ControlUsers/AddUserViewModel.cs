using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.Administration.SettingUser;
using Raketa;
using System.Collections.ObjectModel;
using System.Text;

namespace EducationERP.ViewModels.Modules.Administration.ControlUsers
{
    public class AddUserViewModel : RaketaViewModel
    {
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;

        public UserVM UserVM { get; set; } = new();
        public VisualAddUser Visual { get; set; } = new();

        public RaketaCommand GenerationIdentifierCommand { get; set; }
        public RaketaCommand GenerationPasswordCommand { get; set; }
        public RaketaTCommand<UserVM> AddUserCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        public RaketaTCommand<string> ChangeRoleAccessAdmissionsCampaignCommand { get; set; }
        public RaketaTCommand<string> ChangeRoleAccessDeanRoomCommand { get; set; }
        public RaketaTCommand<string> ChangeRoleAccessAdministrationCommand { get; set; }

        IServiceView _serviceView;
        IUserRepository _userRepository;
        ObservableCollection<UserVM> _users;
        public AddUserViewModel(IServiceView serviceView, IUserRepository userRepository, ObservableCollection<UserVM> users)
        {
            _serviceView = serviceView;
            _userRepository = userRepository;
            _users = users;

            GenerationIdentifierCommand = RaketaCommand.Launch(GenerationIdentifier);
            GenerationPasswordCommand = RaketaCommand.Launch(GenerationPassword);
            AddUserCommand = RaketaTCommand<UserVM>.Launch(AddUser);
            ExitCommand = RaketaCommand.Launch(CloseWindow);

            ChangeRoleAccessAdmissionsCampaignCommand = RaketaTCommand<string>.Launch(RoleAccessAdmissionsCampaign);
            ChangeRoleAccessDeanRoomCommand = RaketaTCommand<string>.Launch(ChangeRoleAccessDeanRoom);
            ChangeRoleAccessAdministrationCommand = RaketaTCommand<string>.Launch(RoleAccessAdministration);
        }

        void GenerationIdentifier() => UserVM.Identifier = Generation();
        void GenerationPassword() => UserVM.Password = Generation();

        async void AddUser(UserVM userVM)
        {
            bool isValidated = userVM.Validation();
            if (!isValidated) return;
            
            userVM.FullName = $"{SurName} {Name} {MiddleName}";

            var user = new User
            {
                Id = userVM.Id,
                SurName = SurName,
                Name = Name,
                MiddleName = MiddleName,
                Identifier = userVM.Identifier,
                Password = userVM.Password,
                ModuleAdmissionsCampaign = userVM.ModuleAdmissionsCampaign,
                ModuleDeanRoom = userVM.ModuleDeanRoom,
                ModuleAdministration = userVM.ModuleAdministration
            };
            bool isAdded = await _userRepository.AddUser(user);
            if (isAdded)
            {
                _users.Add(userVM);
                _serviceView.Close<AddUserViewModel>();
            }
        }

        void RoleAccessAdmissionsCampaign(string roleAccess)
        {
            if (roleAccess == "Без доступа")
            {
                UserVM.ModuleAdmissionsCampaign = false;
                Visual.RoleAdmissionsCampaign = "Ограниченный";
            }
            else if (roleAccess == "Ограниченный")
            {
                UserVM.ModuleAdmissionsCampaign = true;
                Visual.RoleAdmissionsCampaign = "Полный";
            }
            else
            {
                UserVM.ModuleAdmissionsCampaign = null;
                Visual.RoleAdmissionsCampaign = "Без доступа";
            }
        }
        void ChangeRoleAccessDeanRoom(string roleAccess)
        {
            if (roleAccess == "Без доступа")
            {
                UserVM.ModuleDeanRoom = false;
                Visual.RoleDeanRoom = "Ограниченный";
            }
            else if (roleAccess == "Ограниченный")
            {
                UserVM.ModuleDeanRoom = true;
                Visual.RoleDeanRoom = "Полный";
            }
            else
            {
                UserVM.ModuleDeanRoom = null;
                Visual.RoleDeanRoom = "Без доступа";
            }
        }
        void RoleAccessAdministration(string roleAccess)
        {
            if(roleAccess == "Без доступа")
            {
                UserVM.ModuleAdministration = false;
                Visual.RoleAdministration = "Ограниченный";
            }
            else if(roleAccess == "Ограниченный")
            {
                UserVM.ModuleAdministration = true;
                Visual.RoleAdministration = "Полный";
            }
            else
            {
                UserVM.ModuleAdministration = null;
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
        void CloseWindow() => _serviceView.Close<AddUserViewModel>();
    }
}