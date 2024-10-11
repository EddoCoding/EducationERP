namespace EducationERP.Common.Components.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
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