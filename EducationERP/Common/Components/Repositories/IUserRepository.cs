using EducationERP.Models;
using EducationERP.ViewModels.Modules.Administration.ControlUsers;

namespace EducationERP.Common.Components.Repositories
{
    public interface IUserRepository
    {
        UserVM[] GetUsers();
        User GetUser(string identifier, string password);
    }
}