using EducationERP.Common.Components.Configurations;
using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using EducationERP.Models.Modules.Administration.SettingUser;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Windows;

namespace EducationERP.Common.Components
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SettingLevel> Levels { get; set; }
        public DbSet<SettingDirection> Directions { get; set; }
        public DbSet<SettingProfile> Profiles { get; set; }
        public DbSet<SettingForm> Forms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["StrConnection"].ToString());

        public bool CanConnect(string host, string port, string username, string password, string database)
        {
            try
            {
                Database.GetDbConnection().ConnectionString = $"Host={host};Port={port};Username={username};Password={password};Database={database}";
                if (Database.CanConnect()) return true;
                else return false;
            }
            catch
            {
                MessageBox.Show("Ошибка ввода!");
                return false;
            }
            
        }
        public bool CanConnect()
        {
            try
            {
                if (Database.CanConnect()) return true;
                else
                {
                    MessageBox.Show("Ошибка соединения!");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка соединения!");
                return false;
            }

        }

        public bool ApplyMigrate()
        {
            Database.GetDbConnection().ConnectionString = ConfigurationManager.ConnectionStrings["StrConnection"].ToString();

            if (Database.CanConnect()) 
            {
                
                if (Database.GetPendingMigrations().Any())
                {
                    Database.Migrate();
                    SaveIsConfigured();
                    MessageBox.Show("Информационная система сформирована!");
                    return true;
                }
                else
                {
                    MessageBox.Show("Информационная система уже имеется!");
                    SaveIsConfigured();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Ошибка соединения!");
                return false;
            }
        }

        void SaveIsConfigured()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["IsConfigured"].Value = "True";
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SettingLevelConfiguration());
            modelBuilder.ApplyConfiguration(new SettingDirectionConfiguration());
            modelBuilder.ApplyConfiguration(new SettingProfileConfiguration());
            modelBuilder.ApplyConfiguration(new SettingFormConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}