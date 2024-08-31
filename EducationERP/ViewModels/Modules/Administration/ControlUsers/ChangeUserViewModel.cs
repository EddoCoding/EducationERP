using EducationERP.Common.ToolsDev;
using EducationERP.Models;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.ControlUsers
{
    public class ChangeUserViewModel : RaketaViewModel
    {
        public User User { get; set; } = new();
        public VisualAddUser Visual { get; set; } = new();

        public RaketaTCommand<User> SaveUserCommand { get; set; }
        public RaketaTCommand<string> ChangeRoleAccessCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        public ChangeUserViewModel(IServiceView serviceView, UserVM user)
        {
            _serviceView = serviceView;

            Mapp(user);

            SaveUserCommand = RaketaTCommand<User>.Launch(SaveUser);
            ChangeRoleAccessCommand = RaketaTCommand<string>.Launch(RoleAccess);
            ExitCommand = RaketaCommand.Launch(Exit);
        }

        void Mapp(UserVM user)
        {
            string[] parts = user.FullName.Split(' ');

            User.SurName = parts[0];
            User.Name = parts[1];
            User.MiddleName = parts[2];

            User.Id = user.Id;
            User.Identifier = user.Identifier;
            User.Password = user.Password;
            User.ModuleAdministration = user.ModuleAdministration;

            if (user.ModuleAdministration == true) Visual.RoleAdministration = "Полный";
            else if (user.ModuleAdministration == false) Visual.RoleAdministration = "Ограниченный";
            else Visual.RoleAdministration = "Без доступа";
        }

        void SaveUser(User user) => Dev.NotReady();
        void RoleAccess(string roleAccess)
        {
            if (roleAccess == "Без доступа")
            {
                User.ModuleAdministration = false;
                Visual.RoleAdministration = "Ограниченный";
            }
            else if (roleAccess == "Ограниченный")
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
        void Exit() => _serviceView.Close<ChangeUserViewModel>();
    }
}