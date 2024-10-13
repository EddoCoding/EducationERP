using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Models.Modules.AdmissionsCampaign;
using EducationERP.Models.Modules.AdmissionsCampaign.Educations;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Directions;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.DistinctiveFeatures;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Education;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Exams;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign
{
    public class AdmissionsCampaignViewModel : RaketaViewModel
    {
        ApplicantVM _selectedApplicant;

        public ObservableCollection<ApplicantVM> Applicants { get; set; } = new();
        public ApplicantVM SelectedApplicant
        {
            get => _selectedApplicant;
            set => SetValue(ref _selectedApplicant, value);
        }

        public RaketaCommand ExitCommand { get; set; }
        public RaketaTCommand<ObservableCollection<ApplicantVM>> OpenTabPersonalFileCommand { get; set; }
        public RaketaTCommand<ApplicantVM> ChangePersonalFileCommand { get; set; }
        public RaketaCommand DeletePersonalFileCommand { get; set; }
        public RaketaCommand UpdatePersonalFileCommand { get; set; }
        public RaketaTCommand<ExamVM> OpenWindowInsertPointExamCommand { get; set; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        IApplicantRepository _applicantRepository;
        public AdmissionsCampaignViewModel(IServiceView serviceView, ITabControl tabControl, IApplicantRepository applicantRepository)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;
            _applicantRepository = applicantRepository;

            GetApplicant();

            ExitCommand = RaketaCommand.Launch(CloseTab);
            OpenTabPersonalFileCommand = RaketaTCommand<ObservableCollection<ApplicantVM>>.Launch(CreatePersonalFile);
            ChangePersonalFileCommand = RaketaTCommand<ApplicantVM>.Launch(ChangePersonalFile);
            DeletePersonalFileCommand = RaketaCommand.Launch(DeletePersonalFile);
            UpdatePersonalFileCommand = RaketaCommand.Launch(UpdatePersonalFile);
            OpenWindowInsertPointExamCommand = RaketaTCommand<ExamVM>.Launch(OpenWindowInsertPointExam);
        }

        void GetApplicant()
        {
            foreach (var applicant in _applicantRepository.Read())
            {
                var applicantVM = new ApplicantVM
                {
                    Id = applicant.Id,
                    SurName = applicant.SurName,
                    Name = applicant.Name,
                    MiddleName = applicant.MiddleName,
                    DateOfBirth = applicant.DateOfBirth,
                    Gender = applicant.Gender,
                    PlaceOfBirth = applicant.PlaceOfBirth,
                    IsCitizenRus = applicant.IsCitizenRus,
                    NotCitizen = applicant.NotCitizen,
                    IsForeign = applicant.IsForeign,
                    Citizenship = applicant.Citizenship,
                    CitizenshipValidFrom = applicant.CitizenshipValidFrom,

                    ResidentialAddress = applicant.ResidentialAddress,
                    AddressOfRegistration = applicant.AddressOfRegistration,
                    HomePhone = applicant.HomePhone,
                    MobilePhone = applicant.MobilePhone,
                    Mail = applicant.Mail,
                    AdditionalInformation = applicant.AdditionalInformation,

                    SumPointsExam = applicant.SumPointsExam,

                    Documents = new(),
                    Educations = new(),
                    EGES = new(),
                    DistinguishingFeatures = new(),
                    DirectionsOfTraining = new(),
                    Exams = new()
                };
                applicantVM.EGES.CollectionChanged += (sender, e) =>
                {
                    if (e.NewItems != null)
                        foreach (var newItem in e.NewItems)
                            if (newItem is EGEVM ege) applicantVM.TotalPoints += ege.SubjectScores;
                    if (e.OldItems != null)
                        foreach (var oldItem in e.OldItems)
                            if (oldItem is EGEVM ege) applicantVM.TotalPoints -= ege.SubjectScores;
                };
                applicantVM.DistinguishingFeatures.CollectionChanged += (sender, e) =>
                {
                    if (e.NewItems != null)
                        foreach (var newItem in e.NewItems)
                            if (newItem is DistinctiveFeatureVM distinctiveFeature) applicantVM.PointsDistinctiveFeatures += distinctiveFeature.FeatureScore;
                    if (e.OldItems != null)
                        foreach (var oldItem in e.OldItems)
                            if (oldItem is DistinctiveFeatureVM distinctiveFeature) applicantVM.PointsDistinctiveFeatures -= distinctiveFeature.FeatureScore;
                };

                //Перебор документов
                foreach (var document in applicant.Documents)
                {
                    if (document is Passport passport)
                    {
                        var passportVM = new PassportViewModel
                        {
                            Id = passport.Id,
                            TypeDocument = passport.TypeDocument,
                            SurName = passport.SurName,
                            Name = passport.Name,
                            MiddleName = passport.MiddleName,
                            DateOfBirth = passport.DateOfBirth,
                            Gender = passport.Gender,
                            PlaceOfBirth = passport.PlaceOfBirth,
                            IssuedBy = passport.IssuedBy,
                            DateOfIssue = passport.DateOfIssue,
                            DepartmentCode = passport.DepartmentCode,
                            SeriesNumber = passport.SeriesNumber,
                            AdditionalInformation = passport.AdditionalInformation
                        };
                        applicantVM.Documents.Add(passportVM);
                    }
                    if (document is Snils snils)
                    {
                        var snilsVM = new SnilsViewModel
                        {
                            Id = snils.Id,
                            TypeDocument = snils.TypeDocument,
                            SurName = snils.SurName,
                            Name = snils.Name,
                            MiddleName = snils.MiddleName,
                            DateOfBirth = snils.DateOfBirth,
                            Gender = snils.Gender,
                            PlaceOfBirth = snils.PlaceOfBirth,
                            Number = snils.Number,
                            RegistrationDate = snils.RegistrationDate,
                            AdditionalInformation = snils.AdditionalInformation
                        };
                        applicantVM.Documents.Add(snilsVM);
                    }
                    if (document is Inn inn)
                    {
                        var innVM = new InnViewModel
                        {
                            Id = inn.Id,
                            TypeDocument = inn.TypeDocument,
                            SurName = inn.SurName,
                            Name = inn.Name,
                            MiddleName = inn.MiddleName,
                            DateOfBirth = inn.DateOfBirth,
                            Gender = inn.Gender,
                            PlaceOfBirth = inn.PlaceOfBirth,
                            NumberINN = inn.NumberINN,
                            DateAssigned = inn.DateAssigned,
                            SeriesNumber = inn.SeriesNumber,
                            AdditionalInformation = inn.AdditionalInformation
                        };
                        applicantVM.Documents.Add(innVM);
                    }
                    if (document is ForeignPassport foreignPassport)
                    {
                        var foreignPassportVM = new ForeignPassportViewModel
                        {
                            Id = foreignPassport.Id,
                            TypeDocument = foreignPassport.TypeDocument,
                            SurName = foreignPassport.SurName,
                            Name = foreignPassport.Name,
                            MiddleName = foreignPassport.MiddleName,
                            DateOfBirth = foreignPassport.DateOfBirth,
                            Gender = foreignPassport.Gender,
                            PlaceOfBirth = foreignPassport.PlaceOfBirth,
                            IssuedBy = foreignPassport.IssuedBy,
                            DateOfIssue = foreignPassport.DateOfIssue,
                            SeriesNumber = foreignPassport.SeriesNumber,
                            AdditionalInformation = foreignPassport.AdditionalInformation
                        };
                        applicantVM.Documents.Add(foreignPassportVM);
                    }
                }
                //Перебор образований
                foreach (var education in applicant.Educations)
                {
                    if (education is EducationNine educationNine)
                    {
                        var educationNineVM = new EducationNineViewModel
                        {
                            Id = educationNine.Id,
                            TypeEducation = educationNine.TypeEducation,
                            IdentificationDocument = educationNine.IdentificationDocument,
                            IssuedBy = educationNine.IssuedBy,
                            DateOfIssue = educationNine.DateOfIssue,
                            Honours = educationNine.Honours,
                            CodeSeriesNumber = educationNine.CodeSeriesNumber,
                            AdditionalInformation = educationNine.AdditionalInformation
                        };
                        applicantVM.Educations.Add(educationNineVM);
                    }
                    if (education is EducationEleven educationEleven)
                    {
                        var educationElevenVM = new EducationElevenViewModel
                        {
                            Id = educationEleven.Id,
                            TypeEducation = educationEleven.TypeEducation,
                            IdentificationDocument = educationEleven.IdentificationDocument,
                            IssuedBy = educationEleven.IssuedBy,
                            DateOfIssue = educationEleven.DateOfIssue,
                            Honours = educationEleven.Honours,
                            CodeSeriesNumber = educationEleven.CodeSeriesNumber,
                            AdditionalInformation = educationEleven.AdditionalInformation
                        };
                        applicantVM.Educations.Add(educationElevenVM);
                    }
                    if (education is EducationSPO educationSPO)
                    {
                        var educationSPOVM = new EducationSpoViewModel
                        {
                            Id = educationSPO.Id,
                            TypeEducation = educationSPO.TypeEducation,
                            IdentificationDocument = educationSPO.IdentificationDocument,
                            IssuedBy = educationSPO.IssuedBy,
                            DateOfIssue = educationSPO.DateOfIssue,
                            Honours = educationSPO.Honours,
                            FormOfEducation = educationSPO.FormOfEducation,
                            RegistrationNumber = educationSPO.RegistrationNumber,
                            DiplomaSeries = educationSPO.DiplomaSeries,
                            DiplomaNumber = educationSPO.DiplomaNumber,
                            SupplementSeries = educationSPO.SupplementSeries,
                            SupplementNumber = educationSPO.SupplementNumber,
                            AdditionalInformation = educationSPO.AdditionalInformation
                        };
                        applicantVM.Educations.Add(educationSPOVM);
                    }
                    if (education is EducationBak educationBak)
                    {
                        var educationBakVM = new EducationBakViewModel
                        {
                            Id = educationBak.Id,
                            TypeEducation = educationBak.TypeEducation,
                            IdentificationDocument = educationBak.IdentificationDocument,
                            IssuedBy = educationBak.IssuedBy,
                            DateOfIssue = educationBak.DateOfIssue,
                            Honours = educationBak.Honours,
                            FormOfEducation = educationBak.FormOfEducation,
                            RegistrationNumber = educationBak.RegistrationNumber,
                            DiplomaSeries = educationBak.DiplomaSeries,
                            DiplomaNumber = educationBak.DiplomaNumber,
                            SupplementSeries = educationBak.SupplementSeries,
                            SupplementNumber = educationBak.SupplementNumber,
                            AdditionalInformation = educationBak.AdditionalInformation
                        };
                        applicantVM.Educations.Add(educationBakVM);
                    }
                    if (education is EducationMag educationMag)
                    {
                        var educationMagVM = new EducationMagViewModel
                        {
                            Id = educationMag.Id,
                            TypeEducation = educationMag.TypeEducation,
                            IdentificationDocument = educationMag.IdentificationDocument,
                            IssuedBy = educationMag.IssuedBy,
                            DateOfIssue = educationMag.DateOfIssue,
                            Honours = educationMag.Honours,
                            FormOfEducation = educationMag.FormOfEducation,
                            RegistrationNumber = educationMag.RegistrationNumber,
                            DiplomaSeries = educationMag.DiplomaSeries,
                            DiplomaNumber = educationMag.DiplomaNumber,
                            SupplementSeries = educationMag.SupplementSeries,
                            SupplementNumber = educationMag.SupplementNumber,
                            AdditionalInformation = educationMag.AdditionalInformation
                        };
                        applicantVM.Educations.Add(educationMagVM);
                    }
                    if (education is EducationAsp educationAsp)
                    {
                        var educationAspVM = new EducationAspViewModel
                        {
                            Id = educationAsp.Id,
                            TypeEducation = educationAsp.TypeEducation,
                            IdentificationDocument = educationAsp.IdentificationDocument,
                            IssuedBy = educationAsp.IssuedBy,
                            DateOfIssue = educationAsp.DateOfIssue,
                            Honours = educationAsp.Honours,
                            FormOfEducation = educationAsp.FormOfEducation,
                            RegistrationNumber = educationAsp.RegistrationNumber,
                            DiplomaSeries = educationAsp.DiplomaSeries,
                            DiplomaNumber = educationAsp.DiplomaNumber,
                            SupplementSeries = educationAsp.SupplementSeries,
                            SupplementNumber = educationAsp.SupplementNumber,
                            AdditionalInformation = educationAsp.AdditionalInformation
                        };
                        applicantVM.Educations.Add(educationAspVM);
                    }
                }
                //Перебор ЕГЭ
                foreach (var ege in applicant.EGES)
                {
                    var egeVM = new EGEVM
                    {
                        Id = ege.Id,
                        AcademicSubject = ege.AcademicSubject,
                        SubjectScores = ege.SubjectScores
                    };
                    applicantVM.EGES.Add(egeVM);
                }
                //Перебор отличительных признаков
                foreach (var distinguishingFeatures in applicant.DistinguishingFeatures)
                {
                    var distinguishingFeaturesVM = new DistinctiveFeatureVM
                    {
                        Id = distinguishingFeatures.Id,
                        NameFeature = distinguishingFeatures.NameFeature,
                        FeatureScore = distinguishingFeatures.FeatureScore
                    };
                    applicantVM.DistinguishingFeatures.Add(distinguishingFeaturesVM);
                }
                //Перебор выбранных направлений
                foreach (var direction in applicant.DirectionsOfTraining)
                {
                    var directionVM = new SelectedDirectionVM
                    {
                        Id = direction.Id,
                        NameFaculty = direction.NameFaculty,
                        NameLevel = direction.NameLevel,
                        CodeDirection = direction.CodeDirection,
                        NameDirection = direction.NameDirection,
                        CodeProfile = direction.CodeProfile,
                        NameProfile = direction.NameProfile,
                        NameFormEducation = direction.NameFormEducation,
                        NameFormPayment = direction.NameFormPayment
                    };
                    applicantVM.DirectionsOfTraining.Add(directionVM);
                }
                //Перебор экзаменов/испытаний
                foreach (var exam in applicant.Exams)
                {
                    var examVM = new ExamVM
                    {
                        Id = exam.Id,
                        AcademicSubject = exam.AcademicSubject,
                        DateExam = exam.DateExam,
                        TimeExam = exam.TimeExam,
                        LocationExam = exam.LocationExam,
                        IsSpecial = exam.IsSpecial,
                        SubjectScores = exam.SubjectScores,
                        AdditionalInformation = exam.AdditionalInformation
                    };
                    applicantVM.Exams.Add(examVM);
                }

                Applicants.Add(applicantVM);
            }
        }
        void CreatePersonalFile(ObservableCollection<ApplicantVM> applicants) => 
            _tabControl.CreateTab<AddApplicantViewModel>("Добавление абитуриента", null, applicants);
        void ChangePersonalFile(ApplicantVM applicantVM)
        {
            if (applicantVM != null)
                _tabControl.CreateTab<ChangeApplicantViewModel>("Изменение личного дела", null, applicantVM);
        }
        async void DeletePersonalFile()
        {
            if(SelectedApplicant != null)
            {
                bool isDeleted = await _applicantRepository.Delete<Applicant>(SelectedApplicant.Id);
                if (isDeleted)
                {
                    SelectedApplicant.Dispose();
                    Applicants.Remove(SelectedApplicant);
                }
            }
        }
        void UpdatePersonalFile()
        {
            Applicants.Clear();
            GetApplicant();
        }
        void OpenWindowInsertPointExam(ExamVM examVM) =>
            _serviceView.Window<InsertPointExamViewModel>(null, examVM).Modal();

        void CloseTab() => _tabControl.RemoveTab();
    }
}