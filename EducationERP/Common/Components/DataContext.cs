using Microsoft.EntityFrameworkCore;

namespace EducationERP.Common.Components
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(ConnectionProvider.StrConnection);
    }
}