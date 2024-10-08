namespace EducationERP.Common.Components.Repositories
{
    public interface IApplicantRepository
    {
        bool Create<T>(T model) where T: class;
    }
}