using EducationERP.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task Delete(Guid id)
        {
            using(var db = new DataContext())
            {
                var level = await db.SettingLevels.FindAsync(id);
                if(level != null)
                {
                    db.SettingLevels.Remove(level);
                    await db.SaveChangesAsync();            
                }
            }
        }

        public List<EducationalLevelPreparation> Read()
        {
            using (var db = new DataContext()) 
            {
                return db.SettingLevels
                    .Include(level => level.DirectionsTraining)
                    .ThenInclude(direction => direction.EducationalProfiles)
                    .ThenInclude(profile => profile.FormsOfTraining)
                    .ToList();
            }
        }

        public Task Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}