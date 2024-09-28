using EducationERP.Models.Modules.AdmissionsCampaign;
using EducationERP.ViewModels.Modules.AdmissionsCampaign;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Education;
using System.Collections.ObjectModel;

namespace EducationERP.Common.Components.Repositories
{
    public interface IApplicantRepository
    {
        ObservableCollection<ApplicantVM> Applicants { get; set; }

        void AddPersonalFile();
        Task<Applicant> ChangePersonalFile();
        void DeletePersonalFile();
        Task<ApplicantVM[]> UpdatePersonalFiles();
    }
}