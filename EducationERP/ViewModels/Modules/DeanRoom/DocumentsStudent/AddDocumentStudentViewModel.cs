using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.DeanRoom.DocumentsStudent
{
    public class AddDocumentStudentViewModel : RaketaViewModel
    {
        public DocumentStudentBaseVM[] Documents { get; set; } =
        {
            new PassportStudentVM(),
            new SnilsStudentVM(),
            new InnStudentVM(),
            new ForeignPassportStudentVM()
        };

        DocumentStudentBaseVM selectedDocument;
        public DocumentStudentBaseVM SelectedDocument
        {
            get => selectedDocument;
            set => SetValue(ref selectedDocument, value);
        }

        public RaketaTCommand<DocumentStudentBaseVM> AddDocumentCommand { get; }
        public RaketaCommand ExitCommand { get; }

        IServiceView _serviceView;
        ObservableCollection<DocumentStudentBaseVM> _documents;
        public AddDocumentStudentViewModel(IServiceView serviceView, ObservableCollection<DocumentStudentBaseVM> documents)
        {
            _serviceView = serviceView;
            _documents = documents;

            AddDocumentCommand = RaketaTCommand<DocumentStudentBaseVM>.Launch(AddDocument);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        void AddDocument(DocumentStudentBaseVM document)
        {
            _documents.Add(document);
            CloseWindow();
        }
        void CloseWindow() => _serviceView.Close<AddDocumentStudentViewModel>();
    }
}