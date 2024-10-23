using EducationERP.Models.Modules.EducationalInstitution;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Windows;

namespace EducationERP.Common.Components.Repositories
{
    public class StructEducationRepository : IStructEducationRepository
    {
        public StructEducationalInstitution GetStructEducation()
        {
            using (var db = new DataContext())
            {
                try
                {
                    return db.StructEducationalInstitution
                        .Include(x => x.Faculties)
                        .ThenInclude(x => x.Departments)
                        .FirstOrDefault();
                }
                catch
                {
                    MessageBox.Show("Ошибка получения данных об учебном заведении из базы данных!");
                }
            }

            return null;
        }
        public async Task SaveStructEducation(StructEducationalInstitution structEducation)
        {
            using(var db = new DataContext())
            {
                try
                {
                    var entity = await db.StructEducationalInstitution.FirstOrDefaultAsync();
                    if(entity == null)
                    {
                        db.StructEducationalInstitution.Add(structEducation);
                        await db.SaveChangesAsync();
                        MessageBox.Show("Данные об учебном заведении добавлены в базу данных!");
                        return;
                    }

                    entity.NameVUZ = structEducation.NameVUZ;
                    entity.ShortNameVUZ = structEducation.ShortNameVUZ;
                    await db.SaveChangesAsync();
                    MessageBox.Show("Данные учебного заведения обновлены в базе данных!");
                }
                catch
                {
                    MessageBox.Show("Ошибка сохранения данных об учебном заведении в базу данных!");
                }
            }
        }

        public async Task<bool> CreateFaculty(Faculty faculty)
        {
            using (var db = new DataContext())
            {
                try
                {
                    db.MainFaculties.Add(faculty);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления факультета в базу данных!");
                    return false;
                }
            }
        }
        public async Task<bool> UpdateFaculty(FacultyVM facultyVM)
        {
            using(var db = new DataContext())
            {
                try 
                {
                    var faculty = db.MainFaculties.FirstOrDefault(x => x.Id == facultyVM.Id);
                    if(faculty != null)
                    {
                        faculty.NameFaculty = facultyVM.NameFaculty;
                        faculty.PasswordFaculty = facultyVM.PasswordFaculty;
                        await db.SaveChangesAsync();
                        return true;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка изменения данных факультета в базе данных!");
                    return false;
                }

                return false;
            }
        }
        public async Task<bool> DeleteFaculty(Guid id)
        {
            using(var db = new DataContext())
            {
                try
                {
                    var faculty = await db.MainFaculties.FirstOrDefaultAsync(x => x.Id == id);
                    if(faculty != null)
                    {
                        db.MainFaculties.Remove(faculty);
                        await db.SaveChangesAsync();
                        return true;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления факультета из базы данных!");
                    return false;
                }

                return false;
            }
        }

        public async Task<bool> CreateDepartment(Department department)
        {
            using (var db = new DataContext())
            {
                try
                {
                    db.MainDepartments.Add(department);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления кафедры в базу данных!");
                    return false;
                }
            }
        }
        public async Task<bool> UpdateDepartment(DepartmentVM departmentVM)
        {
            using (var db = new DataContext())
            {
                try
                {
                    var department = db.MainDepartments.FirstOrDefault(x => x.Id == departmentVM.Id);
                    if (department != null)
                    {
                        department.NameDepartment = departmentVM.NameDepartment;
                        await db.SaveChangesAsync();
                        return true;
                    }
                    return true;
                }
                catch
                {
                    MessageBox.Show("Ошибка обновления данных кафедры в базе данных!");
                    return false;
                }
            }
        }
        public async Task<bool> DeleteDepartment(Guid id)
        {
            using (var db = new DataContext())
            {
                try
                {
                    var department = await db.MainDepartments.FirstOrDefaultAsync(x => x.Id == id);
                    if (department != null)
                    {
                        db.MainDepartments.Remove(department);
                        await db.SaveChangesAsync();
                        return true;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления кафедры из базы данных!");
                    return false;
                }

                return false;
            }
        }

        public async Task<Guid> GetAccessFaculty(string passwordFaculty)
        {
            using(var db = new DataContext())
            {
                try
                {
                    var faculty = await db.MainFaculties.FirstOrDefaultAsync(x => x.PasswordFaculty == passwordFaculty);
                    if (faculty != null) return faculty.Id;
                    else
                    {
                        MessageBox.Show("Отказано в доступе!");
                        return Guid.Empty;
                    }
                }
                catch
                {
                    MessageBox.Show("Отказано в доступе!");
                    return Guid.Empty;
                }
            }
        }
    }
}