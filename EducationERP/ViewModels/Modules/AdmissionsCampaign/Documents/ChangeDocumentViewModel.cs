using Raketa;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents
{
    public class ChangeDocumentViewModel : RaketaViewModel
    {
        public DocumentBaseViewModel Document { get; set; }

        public RaketaTCommand<DocumentBaseViewModel> SaveDocumentCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        public ChangeDocumentViewModel(IServiceView serviceView, DocumentBaseViewModel document)
        {
            _serviceView = serviceView;

            Document = document;

            SaveDocumentCommand = RaketaTCommand<DocumentBaseViewModel>.Launch(SaveDocument);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        void SaveDocument(DocumentBaseViewModel document)
        {
            var isValidated = document.Validation();
            if (isValidated) CloseWindow();
        }
        void CloseWindow() => _serviceView.Close<ChangeDocumentViewModel>();
    }
}