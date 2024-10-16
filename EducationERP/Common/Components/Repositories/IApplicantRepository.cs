using EducationERP.Models.Modules.AdmissionsCampaign;
using EducationERP.Models.Modules.AdmissionsCampaign.Exams;

namespace EducationERP.Common.Components.Repositories
{
    public interface IApplicantRepository
    {
        IEnumerable<Applicant> Read();
        Task<bool> Create<T>(T model) where T: class;
        Task<bool> Delete<T>(Guid id) where T: class;
        Task<bool> Update(Applicant applicant);
        Task<bool> Update(Exam exam);
        Task<bool> UpdateSatatus(Guid id);
    }
}