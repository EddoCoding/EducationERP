using EducationERP.Common.Components.Repositories;
using EducationERP.ViewModels.Modules.Administration.ControlUsers;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration
{
    public class UserViewModel : RaketaViewModel
    {
        public string TextSearch { get; set; } = string.Empty;
        public ObservableCollection<UserVM> Users { get; set; } = new();
        public UserVM SelectedUser { get; set; }

        public RaketaCommand AddUserCommand { get; set; }
        public RaketaCommand ChangeUserCommand { get; set; }
        public RaketaCommand DeleteUserCommand { get; set; }
        public RaketaCommand UpdateUserCommand { get; set; }

        IUserRepository _userRepository;
        public UserViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            AddUserCommand = RaketaCommand.Launch(AddUser);
            ChangeUserCommand = RaketaCommand.Launch(ChangeUser);
            DeleteUserCommand = RaketaCommand.Launch(DeleteUser);
            UpdateUserCommand = RaketaCommand.Launch(UpdateCollection);
        }

        void AddUser() { }
        void ChangeUser() { }
        void DeleteUser() 
        {
            if(SelectedUser != null) Users.Remove(SelectedUser);
        }
        void UpdateCollection() 
        {
            var users = _userRepository.GetUsers();
            if (users != null)
            {
                Users.Clear();
                foreach (var user in users) Users.Add(user);
            }
        }
    }
}