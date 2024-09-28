using EducationERP.Models;
using System.Windows;

namespace EducationERP.Common.Components.Repositories
{
    public class LevelRepositor : ILevelRepository
    {
        public async Task<bool> Create(EducationalLevelPreparation level)
        {
            using (var db = new DataContext())
            {
                try
                {
                    db.SettingLevels.Add(level);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления!");
                    return false; 
                }
            }
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Read<T>()
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}