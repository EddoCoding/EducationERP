using EducationERP.Models;

namespace EducationERP.Common.Components.Repositories
{
    public class UserRepository(DataContext context) : IUserRepository
    {
        public User GetUser(string identifier, string password)
        {
            if (!context.CanConnect()) return null;

            return context.Users.FirstOrDefault(u => u.Identifier == identifier && u.Password == password);
        }
    }
}