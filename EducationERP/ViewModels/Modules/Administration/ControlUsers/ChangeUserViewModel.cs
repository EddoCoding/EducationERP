using EducationERP.Common.Components;
using EducationERP.Models;
using Raketa;
using System.Text;
using System.Windows;

namespace EducationERP.ViewModels.Modules.Administration.ControlUsers
{
    public class ChangeUserViewModel : RaketaViewModel
    {
        public User User { get; set; } = new();
        public VisualAddUser Visual { get; set; } = new();

        public RaketaCommand GenerationIdentifierCommand { get; set; }
        public RaketaCommand GenerationPasswordCommand { get; set; }
        public RaketaTCommand<User> SaveUserCommand { get; set; }
        public RaketaTCommand<string> ChangeRoleAccessCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        DataContext _context;
        public ChangeUserViewModel(IServiceView serviceView, DataContext context, UserVM user)
        {
            _serviceView = serviceView;
            _context = context;

            Mapp(user);

            GenerationIdentifierCommand = RaketaCommand.Launch(GenerationIdentifier);
            GenerationPasswordCommand = RaketaCommand.Launch(GenerationPassword);
            SaveUserCommand = RaketaTCommand<User>.Launch(SaveUser);
            ChangeRoleAccessCommand = RaketaTCommand<string>.Launch(RoleAccess);
            ExitCommand = RaketaCommand.Launch(Exit);
        }

        void Mapp(UserVM SelectedUser)
        {
            string[] parts = SelectedUser.FullName.Split(' ');

            User.SurName = parts[0];
            User.Name = parts[1];
            User.MiddleName = parts[2];

            User.Id = SelectedUser.Id;
            User.Identifier = SelectedUser.Identifier;
            User.Password = SelectedUser.Password;
            User.ModuleAdministration = SelectedUser.ModuleAdministration;

            if (SelectedUser.ModuleAdministration == true) Visual.RoleAdministration = "Полный";
            else if (SelectedUser.ModuleAdministration == false) Visual.RoleAdministration = "Ограниченный";
            else Visual.RoleAdministration = "Без доступа";
        }
        void GenerationIdentifier() => User.Identifier = Generation();
        void GenerationPassword() => User.Password = Generation();

        void SaveUser(User SelectedUser) 
        {
            if (String.IsNullOrWhiteSpace(User.SurName) || String.IsNullOrWhiteSpace(User.Name)
                 || String.IsNullOrWhiteSpace(User.Identifier) || String.IsNullOrWhiteSpace(User.Password))
            {
                MessageBox.Show("Есть незаполненные поля!");
                return;
            }

            var user = _context.Users.FirstOrDefault(x => x.Id == SelectedUser.Id);

            if (user != null) 
            {
                user.SurName = User.SurName;
                user.Name = User.Name;
                user.MiddleName = User.MiddleName;

                user.Identifier = User.Identifier;
                user.Password = User.Password;
                user.ModuleAdministration= User.ModuleAdministration;

                _context.SaveChanges();

                MessageBox.Show("Данные пользователя сохранены!");
                _serviceView.Close<ChangeUserViewModel>();
            }
        }
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
        void Exit() => _serviceView.Close<ChangeUserViewModel>();
    }
}