using EducationERP.Common.Components.Repositories;
using Raketa;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents
{
    public class DocumentViewModel : RaketaViewModel
    {
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
        public DocumentViewModel(IServiceView serviceView, IApplicantRepository applicantRepository)
        {
            _serviceView = serviceView;
            _applicantRepository = applicantRepository;

            AddDocumentCommand = RaketaTCommand<DocumentBaseViewModel>.Launch(AddDocuments);
            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        void AddDocuments(DocumentBaseViewModel document)
        {
            _applicantRepository.AddDocument(document);
            _serviceView.Close<DocumentViewModel>();
        }
        void ExitLogin() => _serviceView.Close<DocumentViewModel>();
    }
}