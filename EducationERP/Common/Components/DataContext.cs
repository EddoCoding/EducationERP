using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace EducationERP.Common.Components
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(string.Empty);

        public void ApplyMigrate()
        {
            if (Database.CanConnect()) 
            {
                if (Database.GetPendingMigrations().Any())
                {
                    Database.Migrate();
                    MessageBox.Show("Информационная система сформирована!");
                }
                else MessageBox.Show("Информационная система уже имеется!");
            }
            else
            {
                MessageBox.Show("Ошибка соединения!");
                return;
            }
        }
    }
}