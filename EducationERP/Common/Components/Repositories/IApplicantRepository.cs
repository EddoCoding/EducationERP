using EducationERP.Models;
using EducationERP.ViewModels.Modules.AdmissionsCampaign;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents;
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

        //Документы
        ObservableCollection<DocumentBaseViewModel> Documents { get; set; }
        void AddDocument(DocumentBaseViewModel document);
        void ChangeDocuments(DocumentBaseViewModel document);
        void DeleteDocuments(DocumentBaseViewModel document);
    }
}