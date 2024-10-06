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
        public DocumentViewModel(IServiceView serviceView, ObservableCollection<DocumentBaseViewModel> documents)
        {
            _serviceView = serviceView;
            _documents = documents;

            AddDocumentCommand = RaketaTCommand<DocumentBaseViewModel>.Launch(AddDocument);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        void AddDocument(DocumentBaseViewModel document)
        {
            var isValidated = document.Validation();
            if (isValidated)
            {
                _documents.Add(document);
                _documents = null;
                _serviceView.Close<DocumentViewModel>();
            }
        }
        void CloseWindow() => _serviceView.Close<DocumentViewModel>();
    }
}