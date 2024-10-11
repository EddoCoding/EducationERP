namespace EducationERP.Common.Components.Repositories
{
    public interface IApplicantRepository
    {
        Task<bool> Create<T>(T model) where T: class;
    }
}