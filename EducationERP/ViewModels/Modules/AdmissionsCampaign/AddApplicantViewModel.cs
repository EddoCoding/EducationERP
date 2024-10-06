using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.DistinctiveFeatures;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Education;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Exams;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign
{
    public  class AddApplicantViewModel : RaketaViewModel
    {
        public ApplicantVM ApplicantVM { get; set; } = new();
        public VisualAddApplicant Visual { get; set; } = new();


        public RaketaCommand ExitCommand { get; set; }
        public RaketaCommand CitizenshipCommand { get; set; }
        public RaketaCommand CreatePersonalFileCommand { get; set; }


        //ДОКУМЕНТЫ
        public RaketaTCommand<ObservableCollection<DocumentBaseViewModel>> AddDocumentCommand { get; set; }
        public RaketaTCommand<DocumentBaseViewModel> ChangeDocumentCommand { get; set; }
        public RaketaTCommand<DocumentBaseViewModel> DeleteDocumentCommand { get; set; }


        //ОБРАЗОВАНИЕ
        public RaketaTCommand<ObservableCollection<EducationBaseViewModel>> AddEducationCommand { get; set; }
        public RaketaTCommand<EducationBaseViewModel> ChangeEducationCommand { get; set; }
        public RaketaTCommand<EducationBaseViewModel> DeleteEducationCommand { get; set; }


        //ЕГЭ
        public RaketaTCommand<ObservableCollection<EGEVM>> AddEGECommand { get; set; }
        public RaketaTCommand<EGEVM> DeleteEGECommand { get; set; }


        //ОТЛИЧИТЕЛЬНЫЕ ПРИЗНАКИ
        public RaketaTCommand<ObservableCollection<DistinctiveFeatureVM>> AddDistinctiveFeatureCommand { get; set; }
        public RaketaTCommand<DistinctiveFeatureVM> DeleteDistinctiveFeatureCommand { get; set; }


        //НАПРАВЛЕНИЯ ПОДГОТОВКИ
        public RaketaTCommand<ObservableCollection<string>> AddAreasOfTrainingCommand { get; set; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        IApplicantRepository _applicantRepository;
        public AddApplicantViewModel(IServiceView serviceView, ITabControl tabControl, IApplicantRepository applicantRepository)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;
            _applicantRepository = applicantRepository;

            ExitCommand = RaketaCommand.Launch(CloseTab);
            CitizenshipCommand = RaketaCommand.Launch(Citizenship);
            CreatePersonalFileCommand = RaketaCommand.Launch(CreatePersonalFile);

            AddDocumentCommand = RaketaTCommand<ObservableCollection<DocumentBaseViewModel>>.Launch(AddDocument);
            ChangeDocumentCommand = RaketaTCommand<DocumentBaseViewModel>.Launch(ChangeDocument);
            DeleteDocumentCommand = RaketaTCommand<DocumentBaseViewModel>.Launch(DeleteDocument);

            AddEducationCommand = RaketaTCommand<ObservableCollection<EducationBaseViewModel>>.Launch(AddEducation);
            ChangeEducationCommand = RaketaTCommand<EducationBaseViewModel>.Launch(ChangeEducation);
            DeleteEducationCommand = RaketaTCommand<EducationBaseViewModel>.Launch(DeleteEducation);

            AddEGECommand = RaketaTCommand<ObservableCollection<EGEVM>>.Launch(AddEGE);
            DeleteEGECommand = RaketaTCommand<EGEVM>.Launch(DeleteEGE);

            AddDistinctiveFeatureCommand = RaketaTCommand<ObservableCollection<DistinctiveFeatureVM>>.Launch(AddDistinctiveFeature);
            DeleteDistinctiveFeatureCommand = RaketaTCommand<DistinctiveFeatureVM>.Launch(DeleteDistinctiveFeature);
        }

        void CloseTab()
        {
            ApplicantVM.Dispose();
            ApplicantVM = null;
            _tabControl.RemoveTab();
        }
        void Citizenship()
        {
            if(ApplicantVM.IsCitizenRus == true)
            {
                ApplicantVM.Citizenship = string.Empty;
                Visual.IsEnabledTextBox = false;
            }
            if(ApplicantVM.NotCitizen == true)
            {
                ApplicantVM.Citizenship = string.Empty;
                Visual.IsEnabledTextBox = false;
            }
            if(ApplicantVM.IsForeign == true)
            {
                ApplicantVM.Citizenship = string.Empty;
                Visual.IsEnabledTextBox = true;
            }
        }
        void CreatePersonalFile()
        {
            #region Типа работает
            //using(var db = new DataContext())
            //{
            //    var applicant = new Applicant
            //    {
            //        Id = ApplicantVM.Id,
            //        SurName = ApplicantVM.SurName,
            //        Name = ApplicantVM.Name,
            //        MiddleName = ApplicantVM.MiddleName,
            //        DateOfBirth = ApplicantVM.DateOfBirth,
            //        Gender = ApplicantVM.Gender,
            //        PlaceOfBirth = ApplicantVM.PlaceOfBirth,
            //        IsCitizenRus = ApplicantVM.IsCitizenRus,
            //        NotCitizen = ApplicantVM.NotCitizen,
            //        IsForeign = ApplicantVM.IsForeign,
            //        CitizenshipValidFrom = ApplicantVM.CitizenshipValidFrom,
            //
            //        ResidentialAddress = ApplicantVM.ResidentialAddress,
            //        AddressOfRegistration = ApplicantVM.AddressOfRegistration,
            //        HomePhone = ApplicantVM.HomePhone,
            //        MobilePhone = ApplicantVM.MobilePhone,
            //        Mail = ApplicantVM.Mail,
            //        AdditionalInformation = ApplicantVM.AdditionalInformation
            //    };
            //    db.Applicants.Add(applicant);
            //    db.SaveChanges();
            //
            //    foreach (var document in ApplicantVM.Documents)
            //    {
            //        if(document is PassportViewModel passportVM)
            //        {
            //            var passport = new Passport
            //            {
            //                Id = passportVM.Id,
            //                TypeDocument = passportVM.TypeDocument,
            //                SurName = passportVM.SurName,
            //                Name = passportVM.Name,
            //                MiddleName = passportVM.MiddleName,
            //                Gender = passportVM.Gender,
            //                DateOfBirth = passportVM.DateOfBirth,
            //                PlaceOfBirth = passportVM.PlaceOfBirth,
            //                IssuedBy = passportVM.IssuedBy,
            //                DateOfIssue = passportVM.DateOfIssue,
            //                DepartmentCode = passportVM.DepartmentCode,
            //                SeriesNumber = passportVM.SeriesNumber,
            //                AdditionalInformation = passportVM.AdditionalInformation,
            //                ApplicantId = applicant.Id
            //            };
            //            db.Passports.Add(passport);
            //        }
            //    };
            //    db.SaveChanges();
            //}

            #endregion

            //ApplicantVM.Dispose();
            //ApplicantVM = null;
        }

        void AddDocument(ObservableCollection<DocumentBaseViewModel> documents) => _serviceView.Window<DocumentViewModel>(null, documents).Modal();
        void ChangeDocument(DocumentBaseViewModel document) => _serviceView.Window<ChangeDocumentViewModel>(null, document).Modal();
        void DeleteDocument(DocumentBaseViewModel document) => ApplicantVM.Documents.Remove(document);

        void AddEducation(ObservableCollection<EducationBaseViewModel> educations) => _serviceView.Window<EducationDocViewModel>(null, educations).Modal();
        void ChangeEducation(EducationBaseViewModel education) => _serviceView.Window<ChangeEducationDocViewModel>(null, education).Modal();
        void DeleteEducation(EducationBaseViewModel education) => ApplicantVM.Educations.Remove(education);

        void AddEGE(ObservableCollection<EGEVM> eges) => _serviceView.Window<EGEViewModel>(null, eges).Modal();
        void DeleteEGE(EGEVM ege) => ApplicantVM.EGES.Remove(ege);

        void AddDistinctiveFeature(ObservableCollection<DistinctiveFeatureVM> distinctiveFeatures) => 
            _serviceView.Window<DistinctiveFeatureViewModel>(null, distinctiveFeatures).Modal();
        void DeleteDistinctiveFeature(DistinctiveFeatureVM distinctiveFeature) => ApplicantVM.DistinguishingFeatures.Remove(distinctiveFeature);

        void AreasOfTraining() { }
    }
}