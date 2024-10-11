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
    }
}