using EducationERP.Models.Modules.Administration.SettingUser;
using EducationERP.ViewModels.Modules.Administration.ControlUsers;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace EducationERP.Common.Components.Repositories
{
    public class UserRepository(DataContext context) : IUserRepository
    {
        public IEnumerable<User> GetUsers()
        {
            using(var db = new DataContext())
            {
                try
                {
                    return db.Users.ToArray();
                }
                catch
                {
                    MessageBox.Show("Ошибка получения пользователей из базы данных!");
                    return Enumerable.Empty<User>();
                }
            }

            return null;
        }
        public async Task<User> GetUserAsync(string identifier, string password)
        {
            using(var db = new DataContext())
            {
                try
                {
                    var user = await db.Users
                        .FirstOrDefaultAsync(x => x.Identifier == identifier && x.Password == password);
                    if(user != null) return user;
                }
                catch
                {
                    MessageBox.Show("Ошибка получения данных о пользователе!");
                    return null;
                }

                return null;
            }
        }
        public async Task<bool> AddUser(User user)
        {
            using(var db = new DataContext())
            {
                try
                {
                    await db.Users.AddAsync(user);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления пользователя в базу данных!");
                    return false;
                }
            }
        }
        public async Task<bool> DeleteUser(UserVM userVM)
        {
            using(var db = new DataContext())
            {
                try
                {
                    var user = await db.Users.FirstOrDefaultAsync(x => x.Id == userVM.Id);
                    if(user != null)
                    {
                        db.Users.Remove(user);
                        await db.SaveChangesAsync();
                    }
                    return true;
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления пользователя из базы данных!");
                    return false;
                }
            }
        }
        public async Task<bool> UpdateUser(User user)
        {
            using(var db = new DataContext())
            {
                try
                {
                    var entity = await db.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
                    if(entity != null)
                    {
                        entity.SurName = user.SurName;
                        entity.Name = user.Name;
                        entity.MiddleName = user.MiddleName;
                        entity.Identifier = user.Identifier;
                        entity.Password = user.Password;
                        entity.ModuleAdmissionsCampaign = user.ModuleAdmissionsCampaign;
                        entity.ModuleDeanRoom = user.ModuleDeanRoom;
                        entity.ModuleAdministration = user.ModuleAdministration;
                    }
                    await db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    MessageBox.Show("Ошибка обновления данных пользователя в базе данных!");
                    return false;
                }
            }
        }
    }
}