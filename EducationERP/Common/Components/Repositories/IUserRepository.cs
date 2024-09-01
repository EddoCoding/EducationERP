using EducationERP.Models;
using EducationERP.ViewModels.Modules.Administration.ControlUsers;
using System.Collections.ObjectModel;

namespace EducationERP.Common.Components.Repositories
{
    public interface IUserRepository
    {
        ObservableCollection<UserVM> Users { get; set; }

        Task<UserVM[]> GetUsersAsync();
        Task<User> GetUserAsync(string identifier, string password);
        void AddUser(User user);
        void DeleteUser(UserVM user);
    }
}