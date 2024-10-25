using System.Windows;

namespace EducationERP.Common.Components.Repositories
{
    public class EducationGroupRepository : IEducationGroupRepository
    {
        public async Task<bool> Create<T>(T model) where T : class
        {
            using (var db = new DataContext())
            {
                try
                {
                    await db.Set<T>().AddAsync(model);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления данных в базу данных!");
                    return false;
                }
            }
        }
    }
}