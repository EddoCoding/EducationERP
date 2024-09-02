using EducationERP.Models;
using EducationERP.ViewModels.Modules.AdmissionsCampaign;
using System.Collections.ObjectModel;

namespace EducationERP.Common.Components.Repositories
{
    public interface IApplicantRepository
    {
        ObservableCollection<ApplicantVM> Applicants { get; set; }

        void CreatePersonalFile();
        Task<Applicant> ChangePersonalFile();
        void DeletePersonalFile();
        Task<ApplicantVM[]> UpdatePersonalFiles();
    }
}