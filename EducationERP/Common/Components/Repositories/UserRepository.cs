using EducationERP.Models.Modules.Administration;
using EducationERP.ViewModels.Modules.Administration.ControlUsers;
using System.Collections.ObjectModel;
using System.Windows;

namespace EducationERP.Common.Components.Repositories
{
    public class UserRepository(DataContext context) : IUserRepository
    {
        public ObservableCollection<UserVM> Users { get; set; } = new();

        public async Task<UserVM[]> GetUsersAsync()
        {
            if (!context.CanConnect()) return null;

            try
            {
                var users = await Task.Run(() => context.Users.Select(x => new UserVM()
                {
                    Id = x.Id,
                    Identifier = x.Identifier,
                    Password = x.Password,
                    FullName = $"{x.SurName} {x.Name} {x.MiddleName}",
                    ModuleAdministration = x.ModuleAdministration,
                    ModuleAdmissionsCampaign = x.ModuleAdmissionsCampaign
                }).ToArray());

                return users;
            }
            catch 
            {
                MessageBox.Show("Ошибка получения данных");
                return null;
            }
        }
        public async Task<User> GetUserAsync(string identifier, string password)
        {
            if (!context.CanConnect()) return null;
            var user = await Task.Run(() => context?.Users.FirstOrDefault(x => x.Identifier == identifier && x.Password == password));
            return user;
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