using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace EducationERP.Common.Components.Repositories
{
    public class SettingFacultyRepository : ISettingFacultyRepository
    {
        public IEnumerable<SettingFaculty> Read()
        {
            using (var db = new DataContext())
            {
                try
                {
                    return db.ACFaculties
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
                catch
                {
                    MessageBox.Show("Ошибка получения данных из базы данных!");
                    return Enumerable.Empty<SettingFaculty>();
                }
            }
        }
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
        public async Task<bool> Delete<T>(Guid id) where T : class
        {
            using (var db = new DataContext()) 
            {
                try
                {
                    var entity = await db.Set<T>().FindAsync(id);
                    if (entity != null)
                    {
                        db.Set<T>().Remove(entity);
                        await db.SaveChangesAsync();
                        return true;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления данных из базы данных!");
                    return false;
                }

            }

            return false;
        }
        public async Task<Guid> GetIdVuz()
        {
            using (var db = new DataContext())
            {
                return await db.StructEducationalInstitution
                    .Select(x => x.Id)
                    .FirstOrDefaultAsync();
            }
        }
    }
}