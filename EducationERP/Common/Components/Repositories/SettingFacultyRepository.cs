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
                    .ToArray();
            }
        }
        public bool Create<T>(T model) where T : class
        {
            using (var db = new DataContext())
            {
                db.Set<T>().Add(model);
                db.SaveChanges();
                return true;
            }

            return false;
        }
        public bool Delete<T>(Guid id) where T : class
        {
            using (var db = new DataContext()) 
            {
                var entity = db.Set<T>().Find(id);
                if (entity != null)
                {
                    db.Set<T>().Remove(entity);
                    db.SaveChanges();
                    return true;

                }
            }

            return false;
        }
    }
}