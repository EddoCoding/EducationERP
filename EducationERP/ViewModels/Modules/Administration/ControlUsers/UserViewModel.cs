using EducationERP.Common.Components.Repositories;
using EducationERP.ViewModels.Modules.Administration.ControlUsers;
using Raketa;
using System.Collections.ObjectModel;
using System.Windows;

namespace EducationERP.ViewModels.Modules.Administration
{
    public class UserViewModel : RaketaViewModel
    {
        string textSearch = string.Empty;
        public string TextSearch
        {
            get => textSearch; 
            set
            {
                SetValue(ref textSearch, value);
                if (usersFilter != null && !String.IsNullOrWhiteSpace(textSearch)) SearchUser();
                if(String.IsNullOrWhiteSpace(textSearch)) SearchUser();
            }
        }

        public ObservableCollection<UserVM> Users { get; set; } = new();
        List<UserVM> usersFilter { get; set; } = new();


        UserVM selectedUser;
        public UserVM SelectedUser
        {
            get => selectedUser;
            set => SetValue(ref selectedUser, value);
        }

        public RaketaCommand OpenWindowAddUserCommand { get; set; }
        public RaketaTCommand<UserVM> ChangeUserCommand { get; set; }
        public RaketaTCommand<UserVM> DeleteUserCommand { get; set; }
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
            ChangeUserCommand = RaketaTCommand<UserVM>.Launch(ChangeUser);
            DeleteUserCommand = RaketaTCommand<UserVM>.Launch(DeleteUser);
            UpdateUserCommand = RaketaCommand.Launch(UpdateCollection);
        }

        void OpenWindowAddUser() => _serviceView.Window<AddUserViewModel>().Modal();
        void ChangeUser(UserVM user)
        {
            if(SelectedUser != null) _serviceView.Window<ChangeUserViewModel>(null, user).NonModal();
        }
        void DeleteUser(UserVM user) 
        {
            if(user != null)
            {
                _userRepository.DeleteUser(user);
                Users.Remove(user);
            }
        }
        void UpdateCollection() 
        {
            var users = _userRepository.GetUsers();
            usersFilter.Clear();
            if (users != null)
            {
                Users.Clear();
                foreach (var user in users)
                {
                    Users.Add(user);
                    usersFilter.Add(user);
                }
            }
        }
        async Task SearchUser()
        {
            var users = await Task.Run(() => usersFilter.FindAll(x => x.FullName.IndexOf(textSearch, StringComparison.OrdinalIgnoreCase) >= 0));
            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                Users.Clear();
                foreach (var user in users) Users.Add(user);
            });
        }
    }
}