using EducationERP.Models.Modules.AdmissionsCampaign;

namespace EducationERP.Common.Components.Repositories
{
    public interface IApplicantRepository
    {
        IEnumerable<Applicant> Read();
        Task<bool> Create<T>(T model) where T: class;
        Task<bool> Delete<T>(Guid id) where T: class;
        Task<bool> Update(Applicant applicant);
    }
}