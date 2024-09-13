using EducationERP.Common.ToolsDev;
using EducationERP.Models;
using EducationERP.ViewModels.Modules.AdmissionsCampaign;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents;
using System.Collections.ObjectModel;

namespace EducationERP.Common.Components.Repositories
{
    public class ApplicantRepository(DataContext context) : IApplicantRepository
    {
        public ObservableCollection<ApplicantVM> Applicants { get; set; } = new();

        public void AddPersonalFile() => throw new NotImplementedException();
        public Task<Applicant> ChangePersonalFile() => throw new NotImplementedException();
        public Task<ApplicantVM[]> UpdatePersonalFiles() => throw new NotImplementedException();
        public void DeletePersonalFile() => throw new NotImplementedException();



        public ObservableCollection<DocumentBaseViewModel> Documents { get; set; } = new();
        public void AddDocument(DocumentBaseViewModel document) => Documents.Add(document);
        public void ChangeDocuments(DocumentBaseViewModel document) => Dev.NotReady();
        public void DeleteDocuments(DocumentBaseViewModel document) => Documents.Remove(document);
    }
}