using EducationERP.Models.Modules.EducationalInstitution;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace EducationERP.Common.Components.Repositories
{
    public class EducationGroupRepository : IEducationGroupRepository
    {
        public async Task<IEnumerable<Student>> Update(Guid id)
        {
            using(var db = new DataContext())
            {
                try
                {
                    var group = await db.EducationGroups
                        .Include(x => x.Students)
                        .ThenInclude(x => x.Documents)
                        .FirstOrDefaultAsync(x => x.Id == id);
                    if(group != null) return group.Students;
                }
                catch
                {
                    MessageBox.Show("Ошибка получения студентов из базы данных!");
                    return Enumerable.Empty<Student>();
                }

                return Enumerable.Empty<Student>();
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
    }
}