namespace EducationERP.Common.Components.Repositories
{
    public interface IEducationGroupRepository
    {
        Task<bool> Create<T>(T model) where T : class;
    }
}