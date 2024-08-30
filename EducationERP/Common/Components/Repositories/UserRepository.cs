using EducationERP.Models;
using EducationERP.ViewModels.Modules.Administration.ControlUsers;
using System.Collections.ObjectModel;
using System.Windows;

namespace EducationERP.Common.Components.Repositories
{
    public class UserRepository(DataContext context) : IUserRepository
    {
        public ObservableCollection<UserVM> Users { get; set; } = new();

        public UserVM[] GetUsers()
        {
            if (!context.CanConnect()) return null;

            IEnumerable<UserVM> users = new List<UserVM>(context.Users.Select(x => new UserVM()
            {
                Id = x.Id,
                Identifier = x.Identifier,
                Password = x.Password,
                FullName = $"{x.SurName} {x.Name} {x.MiddleName}"
                //Здесь получить роли и доступы
            }));

            return users.ToArray();
        }
        public User GetUser(string identifier, string password)
        {
            if (!context.CanConnect()) return null;
            return context?.Users.FirstOrDefault(x => x.Identifier == identifier && x.Password == password);
        }
        public void AddUser(User user)
        {
            if (!context.CanConnect()) return;
            context.Users.Add(user);
            context.SaveChanges();
        }
        public void DeleteUser(UserVM user)
        {
            if (!context.CanConnect()) return;
            var remoteUser = context.Users.FirstOrDefault(x => x.Id == user.Id);
            if (remoteUser != null)
            {
                context.Users.Remove(remoteUser);
                context.SaveChanges();
            }
        }
    }
}