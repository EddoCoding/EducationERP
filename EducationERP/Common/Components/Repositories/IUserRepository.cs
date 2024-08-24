using EducationERP.Models;

namespace EducationERP.Common.Components.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string identifier, string password);
    }
}