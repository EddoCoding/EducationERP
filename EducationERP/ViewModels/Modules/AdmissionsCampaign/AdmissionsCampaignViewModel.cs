using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Common.ToolsDev;
using EducationERP.Models.Modules.AdmissionsCampaign;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign
{
    public class AdmissionsCampaignViewModel : RaketaViewModel
    {
        public ObservableCollection<ApplicantVM> Applicants { get; set; } = new();
        public ApplicantVM SelectedApplicant { get; set; } = new();

        public RaketaCommand ExitCommand { get; set; }
        public RaketaTCommand<ObservableCollection<ApplicantVM>> OpenTabPersonalFileCommand { get; set; }
        public RaketaCommand ChangePersonalFileCommand { get; set; }
        public RaketaCommand DeletePersonalFileCommand { get; set; }
        public RaketaCommand UpdatePersonalFileCommand { get; set; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        IApplicantRepository _applicantRepository;
        public AdmissionsCampaignViewModel(IServiceView serviceView, ITabControl tabControl, IApplicantRepository applicantRepository)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;
            _applicantRepository = applicantRepository;

            //ПОЛУЧЕНИЕ АБИТУРИЕНТОВ - ПРОВЕРКА
            #region Типа работает
            //using(var db = new DataContext())
            //{
            //    var applicants = db.Applicants
            //        .Include(x => x.Documents)
            //        .ToArray();
            //
            //    foreach(var applicant in applicants)
            //    {
            //        var applicantVM = new ApplicantVM
            //        {
            //            Id = applicant.Id,
            //            SurName = applicant.SurName,
            //            Name = applicant.Name,
            //            MiddleName = applicant.MiddleName,
            //            DateOfBirth = applicant.DateOfBirth,
            //            Gender = applicant.Gender,
            //            PlaceOfBirth = applicant.PlaceOfBirth,
            //            IsCitizenRus = applicant.IsCitizenRus,
            //            NotCitizen = applicant.NotCitizen,
            //            IsForeign = applicant.IsForeign,
            //            Citizenship = applicant.Citizenship,
            //            CitizenshipValidFrom = applicant.CitizenshipValidFrom,
            //
            //            ResidentialAddress = applicant.ResidentialAddress,
            //            AddressOfRegistration = applicant.AddressOfRegistration,
            //            HomePhone = applicant.HomePhone,
            //            MobilePhone = applicant.MobilePhone,
            //            Mail = applicant.Mail,
            //            AdditionalInformation = applicant.AdditionalInformation,
            //            Documents = new()
            //        };
            //        foreach(var document in applicant.Documents)
            //        {
            //            if(document is Passport passport)
            //            {
            //                var passportVM = new PassportViewModel
            //                {
            //                    Id = passport.Id,
            //                    TypeDocument = passport.TypeDocument,
            //                    SurName = passport.SurName,
            //                    Name = passport.Name,
            //                    MiddleName = passport.MiddleName,
            //                    DateOfBirth = passport.DateOfBirth,
            //                    Gender = passport.Gender,
            //                    PlaceOfBirth = passport.PlaceOfBirth,
            //                    IssuedBy = passport.IssuedBy,
            //                    DateOfIssue = passport.DateOfIssue,
            //                    DepartmentCode = passport.DepartmentCode,
            //                    SeriesNumber = passport.SeriesNumber,
            //                    AdditionalInformation = passport.AdditionalInformation
            //                };
            //                applicantVM.Documents.Add(passportVM);
            //            }
            //        }
            //        Applicants.Add(applicantVM);
            //    }
            //}

            #endregion

            ExitCommand = RaketaCommand.Launch(CloseTab);
            OpenTabPersonalFileCommand = RaketaTCommand<ObservableCollection<ApplicantVM>>.Launch(CreatePersonalFile);
            ChangePersonalFileCommand = RaketaCommand.Launch(ChangePersonalFile);
            DeletePersonalFileCommand = RaketaCommand.Launch(DeletePersonalFile);
            UpdatePersonalFileCommand = RaketaCommand.Launch(UpdatePersonalFile);
        }

        void CreatePersonalFile(ObservableCollection<ApplicantVM> applicants) => 
            _tabControl.CreateTab<AddApplicantViewModel>("Добавление абитуриента", null, applicants);
        void ChangePersonalFile() => Dev.NotReady("Изменение личного дела");
        async void DeletePersonalFile()
        {
            bool isDeleted = await _applicantRepository.Delete<Applicant>(SelectedApplicant.Id);
            if (isDeleted) Applicants.Remove(SelectedApplicant);
        }
        void UpdatePersonalFile() => Dev.NotReady("Обновление личных дел");

        void CloseTab() => _tabControl.RemoveTab();
    }
}