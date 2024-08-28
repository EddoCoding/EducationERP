﻿using EducationERP.Models;
using EducationERP.ViewModels.Modules.Administration.ControlUsers;
using System.Collections.ObjectModel;

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
                Identifier = x.Identifier,
                Password = x.Password,
                FullName = $"{x.SurName} {x.Name} {x.Name}",
                Role = x.Role
            }));

            return users.ToArray();
        }
        public User GetUser(string identifier, string password)
        {
            if (!context.CanConnect()) return null;

            return context.Users.FirstOrDefault(u => u.Identifier == identifier && u.Password == password);
        }
        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}