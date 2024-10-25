using Raketa;

namespace EducationERP.ViewModels.Modules.DeanRoom.DocumentsStudent
{
    public class ChangeDocumentStudentViewModel : RaketaViewModel
    {
        public DocumentStudentBaseVM[] Documents { get; set; } =
        {
            new PassportStudentVM(),
            new SnilsStudentVM(),
            new InnStudentVM(),
            new ForeignPassportStudentVM()
        };

        public RaketaTCommand<DocumentStudentBaseVM> SaveDocumentCommand { get; }
        public RaketaCommand ExitCommand { get; }

        IServiceView _serviceView;
        public DocumentStudentBaseVM Document { get; set; }
        public ChangeDocumentStudentViewModel(IServiceView serviceView, DocumentStudentBaseVM document)
        {
            _serviceView = serviceView;
            Document = document;

            SaveDocumentCommand = RaketaTCommand<DocumentStudentBaseVM>.Launch(SaveDocument);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        void SaveDocument(DocumentStudentBaseVM document)
        {
            var isValidated = document.Validation();
            if (isValidated) CloseWindow();
        }
        void CloseWindow() => _serviceView.Close<ChangeDocumentStudentViewModel>();
    }
}