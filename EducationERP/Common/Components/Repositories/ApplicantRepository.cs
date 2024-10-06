namespace EducationERP.Common.Components.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
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
    }
}