using EducationERP.Models.Modules.EducationalInstitution;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
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
                        .ThenInclude(x => x.Students)
                        .ThenInclude(x => x.Documents)
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
        public async Task<IEnumerable<EducationGroup>> GetGroups(Guid Id)
        {
            using (var db = new DataContext())
            {
                try
                {
                    var groups = await db.EducationGroups
                        .Where(x => x.FacultyId == Id)
                        .Include(x => x.Students)
                        .ToArrayAsync();

                    return groups;
                }
                catch
                {
                    MessageBox.Show("Ошибка получения групп из базы данных!");
                    return Enumerable.Empty<EducationGroup>();
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
        public async Task<bool> UpdateEducationGroup(EducationGroupVM groupVM)
        {
            using (var db = new DataContext())
            {
                try
                {
                    var educationGroup = await db.EducationGroups.FirstOrDefaultAsync(x => x.Id == groupVM.Id);
                    if(educationGroup != null)
                    {
                        educationGroup.CodeEducationGroup = groupVM.CodeEducationGroup;
                        educationGroup.NameEducationGroup = groupVM.NameEducationGroup;
                        educationGroup.LevelGroup = groupVM.LevelGroup;
                        educationGroup.FormGroup = groupVM.FormGroup;
                        educationGroup.TypeGroup = groupVM.TypeGroup;
                        educationGroup.Course = groupVM.Course;
                        educationGroup.MaxNumberStudents = groupVM.MaxNumberStudents;
                        educationGroup.CodeDirection = groupVM.CodeDirection;
                        educationGroup.NameDirection = groupVM.NameDirection;
                        educationGroup.CodeProfile = groupVM.CodeProfile;
                        educationGroup.NameProfile = groupVM.NameProfile;
                        educationGroup.NameCuratorGroup = groupVM.NameCuratorGroup;
                        educationGroup.NameHeadmanGroup = groupVM.NameHeadmanGroup;

                        await db.SaveChangesAsync();
                        return true;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка обновления данных учебной группы в базе данных!");
                    return false;
                }

                return false;
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