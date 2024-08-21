using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Windows;

namespace EducationERP.Common.Components
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(string.Empty);

        public void ApplyMigrate()
        {
            Database.GetDbConnection().ConnectionString = ConfigurationManager.ConnectionStrings["StrConnection"].ConnectionString;

            if (Database.CanConnect()) 
            {
                try
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    if (Database.GetPendingMigrations().Any())
                    {
                        Database.Migrate();


                        config.AppSettings.Settings["isConfigured"].Value = "True";
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                        MessageBox.Show("Информационная система сформирована!");
                    }
                    else
                    {
                        config.AppSettings.Settings["isConfigured"].Value = "True";
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                        MessageBox.Show("Информационная система уже имеется!");
                    }
                }
                catch
                {
                    MessageBox.Show("Не хватает прав доступа!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Ошибка соединения!");
                return;
            }
        }
    }
}