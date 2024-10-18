using EducationERP.Common.Components;
using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.Administration.SettingUser;
using Raketa;
using System.Text;
using System.Windows;

namespace EducationERP.ViewModels.Modules.Administration.ControlUsers
{
    public class ChangeUserViewModel : RaketaViewModel
    {
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;

        public VisualAddUser Visual { get; set; } = new();

        public RaketaCommand GenerationIdentifierCommand { get; set; }
        public RaketaCommand GenerationPasswordCommand { get; set; }
        public RaketaTCommand<UserVM> SaveUserCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        public RaketaTCommand<string> ChangeRoleAccessAdmissionsCampaignCommand { get; set; }
        public RaketaTCommand<string> ChangeRoleAccessDeanRoomCommand { get; set; }
        public RaketaTCommand<string> ChangeRoleAccessAdministrationCommand { get; set; }

        IServiceView _serviceView;
        IUserRepository _userRepository;
        DataContext _context;
        public UserVM UserVM { get; set; }
        public ChangeUserViewModel(IServiceView serviceView, IUserRepository userRepository, DataContext context, UserVM userVM)
        {
            _serviceView = serviceView;
            _userRepository = userRepository;
            _context = context;
            UserVM = userVM;

            Mapp(userVM);

            GenerationIdentifierCommand = RaketaCommand.Launch(GenerationIdentifier);
            GenerationPasswordCommand = RaketaCommand.Launch(GenerationPassword);
            SaveUserCommand = RaketaTCommand<UserVM>.Launch(SaveUser);
            ExitCommand = RaketaCommand.Launch(CloseWindow);

            ChangeRoleAccessAdmissionsCampaignCommand = RaketaTCommand<string>.Launch(RoleAccessAdmissionsCampaign);
            ChangeRoleAccessDeanRoomCommand = RaketaTCommand<string>.Launch(ChangeRoleAccessDeanRoom);
            ChangeRoleAccessAdministrationCommand = RaketaTCommand<string>.Launch(RoleAccessAdministration);
        }

        void Mapp(UserVM userVM)
        {
            string[] parts = userVM.FullName.Split(' ');
            SurName = parts[0];
            Name = parts[1];
            MiddleName = parts[2];

            if (userVM.ModuleAdministration == true) Visual.RoleAdministration = "Полный";
            else if (userVM.ModuleAdministration == false) Visual.RoleAdministration = "Ограниченный";
            else Visual.RoleAdministration = "Без доступа";

            if (userVM.ModuleAdmissionsCampaign == true) Visual.RoleAdmissionsCampaign = "Полный";
            else if (userVM.ModuleAdmissionsCampaign == false) Visual.RoleAdmissionsCampaign = "Ограниченный";
            else Visual.RoleAdmissionsCampaign = "Без доступа";

            if (userVM.ModuleDeanRoom == true) Visual.RoleDeanRoom = "Полный";
            else if (userVM.ModuleDeanRoom == false) Visual.RoleDeanRoom = "Ограниченный";
            else Visual.RoleDeanRoom = "Без доступа";
        }
        void GenerationIdentifier() => UserVM.Identifier = Generation();
        void GenerationPassword() => UserVM.Password = Generation();

        async void SaveUser(UserVM userVM) 
        {
            bool isValidated = userVM.Validation();
            if (!isValidated) return;

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
            bool isUpdated = await _userRepository.UpdateUser(user);
            if (isUpdated)
            {
                MessageBox.Show("Данные пользователя сохранены!");
                _serviceView.Close<ChangeUserViewModel>();
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
            if (roleAccess == "Без доступа")
            {
                UserVM.ModuleAdministration = false;
                Visual.RoleAdministration = "Ограниченный";
            }
            else if (roleAccess == "Ограниченный")
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
        void CloseWindow() => _serviceView.Close<ChangeUserViewModel>();
    }
}