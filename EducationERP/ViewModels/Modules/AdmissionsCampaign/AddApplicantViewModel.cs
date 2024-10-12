using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Models.Modules.AdmissionsCampaign;
using EducationERP.Models.Modules.AdmissionsCampaign.Directions;
using EducationERP.Models.Modules.AdmissionsCampaign.DistinctiveFeatures;
using EducationERP.Models.Modules.AdmissionsCampaign.Educations;
using EducationERP.Models.Modules.AdmissionsCampaign.Exams;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Directions;
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
        public RaketaTCommand<ObservableCollection<DocumentBaseViewModel>> OpenWindowAddDocumentCommand { get; set; }
        public RaketaTCommand<DocumentBaseViewModel> ChangeDocumentCommand { get; set; }
        public RaketaTCommand<DocumentBaseViewModel> DeleteDocumentCommand { get; set; }

        //ОБРАЗОВАНИЕ
        public RaketaTCommand<ObservableCollection<EducationBaseViewModel>> OpenWindowAddEducationCommand { get; set; }
        public RaketaTCommand<EducationBaseViewModel> ChangeEducationCommand { get; set; }
        public RaketaTCommand<EducationBaseViewModel> DeleteEducationCommand { get; set; }

        //ЕГЭ
        public RaketaTCommand<ObservableCollection<EGEVM>> OpenWindowAddEGECommand { get; set; }
        public RaketaTCommand<EGEVM> DeleteEGECommand { get; set; }

        //ОТЛИЧИТЕЛЬНЫЕ ПРИЗНАКИ
        public RaketaTCommand<ObservableCollection<DistinctiveFeatureVM>> OpenWindowAddDistinctiveFeatureCommand { get; set; }
        public RaketaTCommand<DistinctiveFeatureVM> DeleteDistinctiveFeatureCommand { get; set; }

        //НАПРАВЛЕНИЯ ПОДГОТОВКИ
        public RaketaTCommand<ObservableCollection<SelectedDirectionVM>> OpenWindowAddDirectionCommand { get; set; }
        public RaketaTCommand<SelectedDirectionVM> DeleteSelectedDirectionVMCommand { get; set; }

        //ИСПЫТАНИЯ/ЭКЗАМЕНЫ
        public RaketaTCommand<ObservableCollection<ExamVM>> OpenWindowAddExamCommand { get; set; }
        public RaketaTCommand<ExamVM> DeleteExamCommand { get; set; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        IApplicantRepository _applicantRepository;
        ObservableCollection<ApplicantVM> _applicants;
        public AddApplicantViewModel(IServiceView serviceView, ITabControl tabControl, IApplicantRepository applicantRepository,
            ObservableCollection<ApplicantVM> applicants)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;
            _applicantRepository = applicantRepository;
            _applicants = applicants;

            ExitCommand = RaketaCommand.Launch(CloseTab);
            CitizenshipCommand = RaketaCommand.Launch(Citizenship);
            CreatePersonalFileCommand = RaketaTCommand<ApplicantVM>.Launch(CreatePersonalFile);

            OpenWindowAddDocumentCommand = RaketaTCommand<ObservableCollection<DocumentBaseViewModel>>.Launch(OpenWindowAddDocument);
            ChangeDocumentCommand = RaketaTCommand<DocumentBaseViewModel>.Launch(ChangeDocument);
            DeleteDocumentCommand = RaketaTCommand<DocumentBaseViewModel>.Launch(DeleteDocument);

            OpenWindowAddEducationCommand = RaketaTCommand<ObservableCollection<EducationBaseViewModel>>.Launch(OpenWindowAddEducation);
            ChangeEducationCommand = RaketaTCommand<EducationBaseViewModel>.Launch(ChangeEducation);
            DeleteEducationCommand = RaketaTCommand<EducationBaseViewModel>.Launch(DeleteEducation);

            OpenWindowAddEGECommand = RaketaTCommand<ObservableCollection<EGEVM>>.Launch(OpenWindowAddEGE);
            DeleteEGECommand = RaketaTCommand<EGEVM>.Launch(DeleteEGE);

            OpenWindowAddDistinctiveFeatureCommand = RaketaTCommand<ObservableCollection<DistinctiveFeatureVM>>.Launch(OpenWindowAddDistinctiveFeature);
            DeleteDistinctiveFeatureCommand = RaketaTCommand<DistinctiveFeatureVM>.Launch(DeleteDistinctiveFeature);

            OpenWindowAddDirectionCommand = RaketaTCommand<ObservableCollection<SelectedDirectionVM>>.Launch(OpenWindowAddDirection);
            DeleteSelectedDirectionVMCommand = RaketaTCommand<SelectedDirectionVM>.Launch(DeleteSelectedDirectionVM);

            OpenWindowAddExamCommand = RaketaTCommand<ObservableCollection<ExamVM>>.Launch(OpenWindowAddExam);
            DeleteExamCommand = RaketaTCommand<ExamVM>.Launch(DeleteExam);
        }

        void Citizenship()
        {
            if(ApplicantVM.IsCitizenRus == true)
            {
                ApplicantVM.Citizenship = "Россия";
                Visual.IsEnabledTextBox = false;
            }
            else if(ApplicantVM.NotCitizen == true)
            {
                ApplicantVM.Citizenship = "Без гражданства";
                Visual.IsEnabledTextBox = false;
            }
            else
            {
                ApplicantVM.Citizenship = string.Empty;
                Visual.IsEnabledTextBox = true;
            }
        }

        void OpenWindowAddDocument(ObservableCollection<DocumentBaseViewModel> documents) => 
            _serviceView.Window<DocumentViewModel>(null, documents, null, false).Modal();
        void ChangeDocument(DocumentBaseViewModel document) => _serviceView.Window<ChangeDocumentViewModel>(null, document).Modal();
        void DeleteDocument(DocumentBaseViewModel document) => ApplicantVM.Documents.Remove(document);

        void OpenWindowAddEducation(ObservableCollection<EducationBaseViewModel> educations) => 
            _serviceView.Window<EducationDocViewModel>(null, educations, null, false).Modal();
        void ChangeEducation(EducationBaseViewModel education) => _serviceView.Window<ChangeEducationDocViewModel>(null, education).Modal();
        void DeleteEducation(EducationBaseViewModel education) => ApplicantVM.Educations.Remove(education);

        void OpenWindowAddEGE(ObservableCollection<EGEVM> eges) => 
            _serviceView.Window<EGEViewModel>(null, eges, null, false).Modal();
        void DeleteEGE(EGEVM ege) => ApplicantVM.EGES.Remove(ege);

        void OpenWindowAddDistinctiveFeature(ObservableCollection<DistinctiveFeatureVM> distinctiveFeatures) => 
            _serviceView.Window<DistinctiveFeatureViewModel>(null, distinctiveFeatures, null, false).Modal();
        void DeleteDistinctiveFeature(DistinctiveFeatureVM distinctiveFeature) => 
            ApplicantVM.DistinguishingFeatures.Remove(distinctiveFeature);

        void OpenWindowAddDirection(ObservableCollection<SelectedDirectionVM> directions) =>
            _serviceView.Window<AddDirectionViewModel>(null, directions, null, false).Modal();
        void DeleteSelectedDirectionVM(SelectedDirectionVM selectedDirectionVM) => 
            ApplicantVM.DirectionsOfTraining.Remove(selectedDirectionVM);

        void OpenWindowAddExam(ObservableCollection<ExamVM> exams) => 
            _serviceView.Window<AddExamViewModel>(null, exams, null, false).Modal();
        void DeleteExam(ExamVM examVM) => ApplicantVM.Exams.Remove(examVM);

        async void CreatePersonalFile(ApplicantVM applicantVM)
        {
            bool isValidated = applicantVM.Validation();
            if (isValidated)
            {
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
                    AdditionalInformation = applicantVM.AdditionalInformation,

                    TotalPoints = applicantVM.TotalPoints,
                    PointsDistinctiveFeatures = applicantVM.PointsDistinctiveFeatures,
                    SumPointsExam = applicantVM.SumPointsExam
                };
                bool isAdded = await _applicantRepository.Create<Applicant>(applicant);
                if (isAdded)
                {
                    //Перебор документов
                    foreach (var document in applicantVM.Documents)
                    {
                        if (document is PassportViewModel passportVM)
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
                            await _applicantRepository.Create<Passport>(passport);
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
                        await _applicantRepository.Create<Snils>(snils);
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
                        await _applicantRepository.Create<Inn>(inn);
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
                        await _applicantRepository.Create<ForeignPassport>(foreignPassport);
                    }
                    }

                    //Перебор образований
                    foreach (var education in applicantVM.Educations)
                    {
                        if (education is EducationNineViewModel educationNineVM)
                    {
                        var educationNine = new EducationNine
                        {
                            Id = educationNineVM.Id,
                            TypeEducation = educationNineVM.TypeEducation,
                            IdentificationDocument = educationNineVM.IdentificationDocument,
                            IssuedBy = educationNineVM.IssuedBy,
                            DateOfIssue = educationNineVM.DateOfIssue,
                            Honours = educationNineVM.Honours,
                            CodeSeriesNumber = educationNineVM.CodeSeriesNumber,
                            AdditionalInformation = educationNineVM.AdditionalInformation,
                            ApplicantId = applicant.Id
                        };
                        await _applicantRepository.Create<EducationNine>(educationNine);
                    }
                        else if (education is EducationElevenViewModel educationElevenVM)
                    {
                        var educationEleven = new EducationEleven
                        {
                            Id = educationElevenVM.Id,
                            TypeEducation = educationElevenVM.TypeEducation,
                            IdentificationDocument = educationElevenVM.IdentificationDocument,
                            IssuedBy = educationElevenVM.IssuedBy,
                            DateOfIssue = educationElevenVM.DateOfIssue,
                            Honours = educationElevenVM.Honours,
                            CodeSeriesNumber = educationElevenVM.CodeSeriesNumber,
                            AdditionalInformation = educationElevenVM.AdditionalInformation,
                            ApplicantId = applicant.Id
                        };
                        await _applicantRepository.Create<EducationEleven>(educationEleven);
                    }
                        else if (education is EducationSpoViewModel educationSpoVM)
                    {
                        var educationSpo = new EducationSPO
                        {
                            Id = educationSpoVM.Id,
                            TypeEducation = educationSpoVM.TypeEducation,
                            IdentificationDocument = educationSpoVM.IdentificationDocument,
                            IssuedBy = educationSpoVM.IssuedBy,
                            DateOfIssue = educationSpoVM.DateOfIssue,
                            Honours = educationSpoVM.Honours,
                            FormOfEducation = educationSpoVM.FormOfEducation,
                            RegistrationNumber = educationSpoVM.RegistrationNumber,
                            DiplomaSeries = educationSpoVM.DiplomaSeries,
                            DiplomaNumber = educationSpoVM.DiplomaNumber,
                            SupplementSeries = educationSpoVM.SupplementSeries,
                            SupplementNumber = educationSpoVM.SupplementNumber,
                            AdditionalInformation = educationSpoVM.AdditionalInformation,
                            ApplicantId = applicant.Id
                        };
                        await _applicantRepository.Create<EducationSPO>(educationSpo);
                    }
                        else if (education is EducationBakViewModel educationBakVM)
                    {
                        var educationBak = new EducationBak
                        {
                            Id = educationBakVM.Id,
                            TypeEducation = educationBakVM.TypeEducation,
                            IdentificationDocument = educationBakVM.IdentificationDocument,
                            IssuedBy = educationBakVM.IssuedBy,
                            DateOfIssue = educationBakVM.DateOfIssue,
                            Honours = educationBakVM.Honours,
                            FormOfEducation = educationBakVM.FormOfEducation,
                            RegistrationNumber = educationBakVM.RegistrationNumber,
                            DiplomaSeries = educationBakVM.DiplomaSeries,
                            DiplomaNumber = educationBakVM.DiplomaNumber,
                            SupplementSeries = educationBakVM.SupplementSeries,
                            SupplementNumber = educationBakVM.SupplementNumber,
                            AdditionalInformation = educationBakVM.AdditionalInformation,
                            ApplicantId = applicant.Id
                        };
                        await _applicantRepository.Create<EducationBak>(educationBak);
                    }
                        else if (education is EducationMagViewModel educationMagVM)
                    {
                        var educationMag = new EducationMag
                        {
                            Id = educationMagVM.Id,
                            TypeEducation = educationMagVM.TypeEducation,
                            IdentificationDocument = educationMagVM.IdentificationDocument,
                            IssuedBy = educationMagVM.IssuedBy,
                            DateOfIssue = educationMagVM.DateOfIssue,
                            Honours = educationMagVM.Honours,
                            FormOfEducation = educationMagVM.FormOfEducation,
                            RegistrationNumber = educationMagVM.RegistrationNumber,
                            DiplomaSeries = educationMagVM.DiplomaSeries,
                            DiplomaNumber = educationMagVM.DiplomaNumber,
                            SupplementSeries = educationMagVM.SupplementSeries,
                            SupplementNumber = educationMagVM.SupplementNumber,
                            AdditionalInformation = educationMagVM.AdditionalInformation,
                            ApplicantId = applicant.Id
                        };
                        await _applicantRepository.Create<EducationMag>(educationMag);
                    }
                        else if (education is EducationAspViewModel educationAspVM)
                    {
                        var educationAsp = new EducationAsp
                        {
                            Id = educationAspVM.Id,
                            TypeEducation = educationAspVM.TypeEducation,
                            IdentificationDocument = educationAspVM.IdentificationDocument,
                            IssuedBy = educationAspVM.IssuedBy,
                            DateOfIssue = educationAspVM.DateOfIssue,
                            Honours = educationAspVM.Honours,
                            FormOfEducation = educationAspVM.FormOfEducation,
                            RegistrationNumber = educationAspVM.RegistrationNumber,
                            DiplomaSeries = educationAspVM.DiplomaSeries,
                            DiplomaNumber = educationAspVM.DiplomaNumber,
                            SupplementSeries = educationAspVM.SupplementSeries,
                            SupplementNumber = educationAspVM.SupplementNumber,
                            AdditionalInformation = educationAspVM.AdditionalInformation,
                            ApplicantId = applicant.Id
                        };
                        await _applicantRepository.Create<EducationAsp>(educationAsp);
                    }
                    }

                    //Перебор ЕГЭ
                    if (applicantVM.TotalPoints > 0)
                {
                    foreach (var egeVM in applicantVM.EGES)
                    {
                        var ege = new EGE
                        {
                            Id = egeVM.Id,
                            AcademicSubject = egeVM.AcademicSubject,
                            SubjectScores = egeVM.SubjectScores,
                            ApplicantId = applicant.Id
                        };
                        await _applicantRepository.Create<EGE>(ege);
                    }
                }

                    //Перебор отличительных признаков
                    if (applicantVM.PointsDistinctiveFeatures > 0)
                {
                    foreach (var distinguishingFeatureVM in applicantVM.DistinguishingFeatures)
                    {
                        var distinguishingFeature = new DistinctiveFeature
                        {
                            Id = distinguishingFeatureVM.Id,
                            NameFeature = distinguishingFeatureVM.NameFeature,
                            FeatureScore = distinguishingFeatureVM.FeatureScore,
                            ApplicantId = applicant.Id
                        };
                        await _applicantRepository.Create<DistinctiveFeature>(distinguishingFeature);
                    }
                }

                    //Перебор направлений подготовки
                    if (applicantVM.DirectionsOfTraining.Count > 0)
                {
                    foreach (var directionVM in applicantVM.DirectionsOfTraining)
                    {
                        var direction = new SelectedDirection
                        {
                            Id = directionVM.Id,
                            NameFaculty = directionVM.NameFaculty,
                            NameLevel = directionVM.NameLevel,
                            CodeDirection = directionVM.CodeDirection,
                            NameDirection = directionVM.NameDirection,
                            CodeProfile = directionVM.CodeProfile,
                            NameProfile = directionVM.NameProfile,
                            NameFormEducation = directionVM.NameFormEducation,
                            NameFormPayment = directionVM.NameFormPayment,
                            ApplicantId = applicant.Id
                        };
                        await _applicantRepository.Create<SelectedDirection>(direction);
                    }
                }

                    //Перебор испытаний/экзаменов
                    if (applicantVM.Exams.Count > 0)
                {
                    foreach (var examVM in applicantVM.Exams)
                    {
                        var exam = new Exam
                        {
                            Id = examVM.Id,
                            AcademicSubject = examVM.AcademicSubject,
                            DateExam = examVM.DateExam,
                            TimeExam = examVM.TimeExam,
                            LocationExam = examVM.LocationExam,
                            IsSpecial = examVM.IsSpecial,
                            AdditionalInformation = examVM.AdditionalInformation,
                            SubjectScores = examVM.SubjectScores,
                            ApplicantId = applicant.Id
                        };
                        await _applicantRepository.Create<Exam>(exam);
                    }
                }

                    _applicants.Add(applicantVM);

                   CloseTab();
                }
            }
        }
        void CloseTab()
        {
            ApplicantVM = null;
            _tabControl.RemoveTab();
        }
    }
}