using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace EducationERP.Common.Components
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(string.Empty);

        public bool IsConnection()
        {
            if (Database.CanConnect()) return true;
            else 
            {
                MessageBox.Show("Ошибка соединения!");
                return false;
            }
        }
    }
}