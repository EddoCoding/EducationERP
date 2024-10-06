using EducationERP.Common.Components;
using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Models.Modules.AdmissionsCampaign;
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
        public RaketaTCommand<ApplicantVM> CreatePersonalFileCommand { get; set; }


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
            CreatePersonalFileCommand = RaketaTCommand<ApplicantVM>.Launch(CreatePersonalFile);

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
        void CreatePersonalFile(ApplicantVM applicantVM)
        {
            //ВЫЗВАТЬ МЕТОД Validation() МОДЕЛИ ПРЕДСТАВЛЕНИЯ ApplicantVM, И ЕСЛИ ВСЕ ХОРОШО ДЕЛАЕМ МАПИНГ
            //Если добавился, то добавляем в коллекцию абитуриентов applicantVM

            var applicant = new Applicant
            {
                Id = applicantVM.Id,
                SurName = applicantVM.SurName,
                Name = applicantVM.Name,
                MiddleName = applicantVM.MiddleName,
                DateOfBirth = applicantVM.DateOfBirth,
                Gender = applicantVM.Gender,
                PlaceOfBirth = applicantVM.PlaceOfBirth,
                IsCitizenRus = applicantVM.IsCitizenRus,
                NotCitizen = applicantVM.NotCitizen,
                IsForeign = applicantVM.IsForeign,
                Citizenship = applicantVM.Citizenship,
                CitizenshipValidFrom = applicantVM.CitizenshipValidFrom,

                ResidentialAddress = applicantVM.ResidentialAddress,
                AddressOfRegistration = applicantVM.AddressOfRegistration,
                HomePhone = applicantVM.HomePhone,
                MobilePhone = applicantVM.MobilePhone,
                Mail = applicantVM.Mail,
                AdditionalInformation = applicantVM.AdditionalInformation
            };
            _applicantRepository.Create<Applicant>(applicant);

            foreach(var document in applicantVM.Documents)
            {
                if(document is PassportViewModel passportVM)
                {
                    var passport = new Passport
                    {
                        Id = passportVM.Id,
                        TypeDocument = passportVM.TypeDocument,
                        SurName = passportVM.SurName,
                        Name = passportVM.Name,
                        MiddleName = passportVM.MiddleName,
                        Gender = passportVM.Gender,
                        DateOfBirth = passportVM.DateOfBirth,
                        PlaceOfBirth = passportVM.PlaceOfBirth,
                        IssuedBy = passportVM.IssuedBy,
                        DateOfIssue = passportVM.DateOfIssue,
                        DepartmentCode = passportVM.DepartmentCode,
                        SeriesNumber = passportVM.SeriesNumber,
                        AdditionalInformation = passportVM.AdditionalInformation,
                        ApplicantId = applicant.Id
                    };
                    _applicantRepository.Create<Passport>(passport);
                }
                else if (document is SnilsViewModel snilsVM)
                {
                    var snils = new Snils
                    {
                        Id = snilsVM.Id,
                        TypeDocument = snilsVM.TypeDocument,
                        SurName = snilsVM.SurName,
                        Name = snilsVM.Name,
                        MiddleName = snilsVM.MiddleName,
                        Gender = snilsVM.Gender,
                        DateOfBirth = snilsVM.DateOfBirth,
                        PlaceOfBirth = snilsVM.PlaceOfBirth,
                        Number = snilsVM.Number,
                        RegistrationDate = snilsVM.RegistrationDate,
                        AdditionalInformation = snilsVM.AdditionalInformation,
                        ApplicantId = applicant.Id
                    };
                    _applicantRepository.Create<Snils>(snils);
                }
                else if (document is InnViewModel innVM)
                {
                    var inn = new Inn
                    {
                        Id = innVM.Id,
                        TypeDocument = innVM.TypeDocument,
                        SurName = innVM.SurName,
                        Name = innVM.Name,
                        MiddleName = innVM.MiddleName,
                        Gender = innVM.Gender,
                        DateOfBirth = innVM.DateOfBirth,
                        PlaceOfBirth = innVM.PlaceOfBirth,
                        NumberINN = innVM.NumberINN,
                        DateAssigned = innVM.DateAssigned,
                        SeriesNumber = innVM.SeriesNumber,
                        AdditionalInformation = innVM.AdditionalInformation,
                        ApplicantId = applicant.Id
                    };
                    _applicantRepository.Create<Inn>(inn);
                }
                else if (document is ForeignPassportViewModel foreignPassportVM)
                {
                    var foreignPassport = new ForeignPassport
                    {
                        Id = foreignPassportVM.Id,
                        TypeDocument = foreignPassportVM.TypeDocument,
                        SurName = foreignPassportVM.SurName,
                        Name = foreignPassportVM.Name,
                        MiddleName = foreignPassportVM.MiddleName,
                        Gender = foreignPassportVM.Gender,
                        DateOfBirth = foreignPassportVM.DateOfBirth,
                        PlaceOfBirth = foreignPassportVM.PlaceOfBirth,
                        IssuedBy = foreignPassportVM.IssuedBy,
                        DateOfIssue = foreignPassportVM.DateOfIssue,
                        SeriesNumber = foreignPassportVM.SeriesNumber,
                        AdditionalInformation = foreignPassportVM.AdditionalInformation,
                        ApplicantId = applicant.Id
                    };
                    _applicantRepository.Create<ForeignPassport>(foreignPassport);
                }
            }

            //ApplicantVM.Dispose();
            //ApplicantVM = null;
            //Вызываем закрытие вкладки
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
    }
}