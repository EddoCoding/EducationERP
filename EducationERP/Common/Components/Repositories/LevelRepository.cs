using EducationERP.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace EducationERP.Common.Components.Repositories
{
    public class LevelRepositor : ILevelRepository
    {
        public async Task<bool> CreateLevel(EducationalLevelPreparation level)
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
        public List<EducationalLevelPreparation> ReadLevels()
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
        public async Task DeleteLevel(Guid id)
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
    }
}