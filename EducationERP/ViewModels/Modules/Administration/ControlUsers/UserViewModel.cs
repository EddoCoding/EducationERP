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

        public RaketaCommand OpenWindowAddUserCommand { get; set; }
        public RaketaCommand ChangeUserCommand { get; set; }
        public RaketaCommand DeleteUserCommand { get; set; }
        public RaketaCommand UpdateUserCommand { get; set; }

        IServiceView _serviceView;
        IUserRepository _userRepository;
        public UserViewModel(IServiceView serviceView, IUserRepository userRepository)
        {
            _serviceView = serviceView;
            _userRepository = userRepository;

            userRepository.Users.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (UserVM item in e.OldItems) Users.Remove(item);
                if (e.NewItems != null) foreach (UserVM item in e.NewItems) Users.Add(item);
            };

            OpenWindowAddUserCommand = RaketaCommand.Launch(OpenWindowAddUser);
            ChangeUserCommand = RaketaCommand.Launch(ChangeUser);
            DeleteUserCommand = RaketaCommand.Launch(DeleteUser);
            UpdateUserCommand = RaketaCommand.Launch(UpdateCollection);
        }

        void OpenWindowAddUser() => _serviceView.Window<AddUserViewModel>().Modal();
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