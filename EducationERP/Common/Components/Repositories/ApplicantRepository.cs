using EducationERP.Models.Modules.AdmissionsCampaign;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace EducationERP.Common.Components.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        public IEnumerable<Applicant> Read()
        {
            try
            {
                using (var db = new DataContext())
                {
                    return db.Applicants
                        .Include(x => x.Documents)
                        .Include(x => x.Educations)
                        .Include(x => x.EGES)
                        .Include(x => x.DistinguishingFeatures)
                        .Include(x => x.DirectionsOfTraining)
                        .Include(x => x.Exams)
                        .ToArray();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка получения данных из базы данных!");
                return Enumerable.Empty<Applicant>();
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