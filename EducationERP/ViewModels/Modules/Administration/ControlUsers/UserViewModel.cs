using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
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

        public RaketaCommand ExitCommand { get; }

        public RaketaCommand OpenWindowAddUserCommand { get; }
        public RaketaTCommand<UserVM> ChangeUserCommand { get; }
        public RaketaTCommand<UserVM> DeleteUserCommand { get; }
        public RaketaCommand UpdateUserCommand { get; }

        IServiceView _serviceView;
        IUserRepository _userRepository;
        ITabControl _tabControl;
        public UserViewModel(IServiceView serviceView, IUserRepository userRepository, ITabControl tabControl)
        {
            _serviceView = serviceView;
            _userRepository = userRepository;
            _tabControl = tabControl;

            ExitCommand = RaketaCommand.Launch(CloseTab);

            OpenWindowAddUserCommand = RaketaCommand.Launch(OpenWindowAddUser);
            ChangeUserCommand = RaketaTCommand<UserVM>.Launch(ChangeUser);
            DeleteUserCommand = RaketaTCommand<UserVM>.Launch(DeleteUser);
            UpdateUserCommand = RaketaCommand.Launch(UpdateCollectionAsync);
        }

        void OpenWindowAddUser() => _serviceView.Window<AddUserViewModel>(null, Users).Modal();
        void ChangeUser(UserVM userVM)
        {
            if(SelectedUser != null) _serviceView.Window<ChangeUserViewModel>(null, userVM).Modal();
        }
        void DeleteUser(UserVM user) 
        {
            if(user != null)
            {
                _userRepository.DeleteUser(user);
                Users.Remove(user);
            }
        }
        void UpdateCollectionAsync()
        {
            var users = _userRepository.GetUsers();
            usersFilter.Clear();
            if (users != null)
            {
                Users.Clear();
                foreach (var user in users)
                {
                    var userVM = new UserVM
                    {
                        Id = user.Id,
                        FullName = $"{user.SurName} {user.Name} {user.MiddleName}",
                        Identifier = user.Identifier,
                        Password = user.Password,
                        ModuleAdmissionsCampaign = user.ModuleAdmissionsCampaign,
                        ModuleDeanRoom = user.ModuleDeanRoom,
                        ModuleAdministration = user.ModuleAdministration
                    };

                    Users.Add(userVM);
                    usersFilter.Add(userVM);
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
        void CloseTab() => _tabControl.RemoveTab();
    }
}