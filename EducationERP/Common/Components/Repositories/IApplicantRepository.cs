namespace EducationERP.Common.Components.Repositories
{
    public interface IApplicantRepository
    {
        Task<bool> Create<T>(T model) where T: class;
        Task<bool> Delete<T>(Guid id) where T: class;
    }
}