using EducationERP.Models.Modules.EducationalInstitution;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace EducationERP.Common.Components.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        public Faculty GetFacultyById(Guid id)
        {
            using (var db = new DataContext())
            {
                try
                {
                    var faculty = db.MainFaculties
                        .Include(x => x.EducationGroups)
                        .FirstOrDefault(x => x.Id == id);
                    return faculty;
                }
                catch
                {
                    MessageBox.Show("Ошибка получения данных факультета!");
                    return null;
                }
            }
        }
        public async Task<bool> CreateEducationGroup(EducationGroup group)
        {
            using(var db = new DataContext())
            {
                try
                {
                    await db.EducationGroups.AddAsync(group);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    MessageBox.Show("Ошибка создания учебной группы в базе данных!");
                    return false;
                }
            }
        }
        public async Task<bool> DeleteEducationGroup(Guid id)
        {
            using (var db = new DataContext())
            {
                try
                {
                    var educationGroup = await db.EducationGroups.FirstOrDefaultAsync(x => x.Id == id);
                    if(educationGroup != null)
                    {
                        db.EducationGroups.Remove(educationGroup);
                        await db.SaveChangesAsync();
                        return true;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления учебной группы из базы данных!");
                    return false;
                }

                return false;
            }
        }
    }
}