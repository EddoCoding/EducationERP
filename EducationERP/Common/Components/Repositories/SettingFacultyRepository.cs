using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Microsoft.EntityFrameworkCore;

namespace EducationERP.Common.Components.Repositories
{
    public class SettingFacultyRepository : ISettingFacultyRepository
    {
        public IEnumerable<SettingFaculty> Read()
        {
            using (var db = new DataContext())
            {
                return db.Faculties
                    .Include(x => x.Levels)
                    .ThenInclude(x => x.Directions)
                    .ToArray()
                    .Select(faculty =>
                    {
                        foreach (var level in faculty.Levels)
                        {
                            level.Directions = level.Directions.OrderBy(x => x.NameDirection).ToArray();
                        }
                        return faculty;
                    });
            }
        }
        public async Task<bool> Create<T>(T model) where T : class
        {
            using (var db = new DataContext())
            {
                await db.Set<T>().AddAsync(model);
                await db.SaveChangesAsync();
                return true;
            }
        }
        public async Task<bool> Delete<T>(Guid id) where T : class
        {
            using (var db = new DataContext()) 
            {
                var entity = await db.Set<T>().FindAsync(id);
                if (entity != null)
                {
                    db.Set<T>().Remove(entity);
                    await db.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }
    }
}