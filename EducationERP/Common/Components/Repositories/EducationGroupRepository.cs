using EducationERP.Models.Modules.EducationalInstitution;
using System.Windows;

namespace EducationERP.Common.Components.Repositories
{
    public class EducationGroupRepository : IEducationGroupRepository
    {
        public async Task<bool> CreateStudent(Student student)
        {
            using (var db = new DataContext())
            {
                try
                {
                    await db.Students.AddAsync(student);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    MessageBox.Show("");
                    return false;
                }
            }
        }
    }
}