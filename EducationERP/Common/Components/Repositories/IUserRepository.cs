using EducationERP.Models.Modules.Administration.SettingUser;
using EducationERP.ViewModels.Modules.Administration.ControlUsers;
using System.Collections.ObjectModel;

namespace EducationERP.Common.Components.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        Task<User> GetUserAsync(string identifier, string password);
        Task<bool> AddUser(User user);
        Task<bool> DeleteUser(UserVM user);
        Task<bool> UpdateUser(User user);
    }
}