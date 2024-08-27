using EducationERP.Models;
using EducationERP.ViewModels.Modules.Administration.ControlUsers;
using System.Collections.ObjectModel;

namespace EducationERP.Common.Components.Repositories
{
    public interface IUserRepository
    {
        ObservableCollection<UserVM> Users { get; set; }

        UserVM[] GetUsers();
        User GetUser(string identifier, string password);
    }
}