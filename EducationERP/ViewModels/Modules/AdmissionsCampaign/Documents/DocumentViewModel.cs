using EducationERP.ViewModels.Login;
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

        public RaketaCommand AddDocumentCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        public DocumentViewModel(IServiceView serviceView)
        {
            _serviceView = serviceView;

            AddDocumentCommand = RaketaCommand.Launch(AddDocuments);
            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        void AddDocuments() { }
        void ExitLogin() => _serviceView.Close<DocumentViewModel>();
    }
}