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
    }
}