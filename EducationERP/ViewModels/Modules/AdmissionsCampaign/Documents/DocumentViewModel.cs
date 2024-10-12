using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.AdmissionsCampaign;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents
{
    public class DocumentViewModel : RaketaViewModel
    {
        ObservableCollection<DocumentBaseViewModel> _documents;

        public DocumentBaseViewModel[] Documents { get; set; } =
        {
            new PassportViewModel(),
            new SnilsViewModel(),
            new InnViewModel(),
            new ForeignPassportViewModel()
        }; // ДОКУМЕНТЫ

        DocumentBaseViewModel selectedDocument;
        public DocumentBaseViewModel SelectedDocument
        {
            get => selectedDocument;
            set => SetValue(ref selectedDocument, value);
        }

        public RaketaTCommand<DocumentBaseViewModel> AddDocumentCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        IApplicantRepository _applicantRepository;
        Guid _id;
        bool _useDataBase;
        public DocumentViewModel(IServiceView serviceView, IApplicantRepository applicantRepository, 
            ObservableCollection<DocumentBaseViewModel> documents, Guid id = default, bool useDataBase = false)
        {
            _serviceView = serviceView;
            _applicantRepository = applicantRepository;
            _documents = documents;
            _id = id;
            _useDataBase = useDataBase;

            AddDocumentCommand = RaketaTCommand<DocumentBaseViewModel>.Launch(AddDocument);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        async void AddDocument(DocumentBaseViewModel document)
        {
            var isValidated = document.Validation();
            if (isValidated)
            {
                _documents.Add(document);
                _documents = null;
                if (_useDataBase)
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
                            ApplicantId = _id
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
                            ApplicantId = _id
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
                            ApplicantId = _id
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
                            ApplicantId = _id
                        };
                        await _applicantRepository.Create<ForeignPassport>(foreignPassport);
                    }
                }
                _serviceView.Close<DocumentViewModel>();
            }
        }
        void CloseWindow() => _serviceView.Close<DocumentViewModel>();
    }
}