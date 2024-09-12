using Raketa;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents
{
    public class ChangeDocumentViewModel : RaketaViewModel
    {
        public DocumentBaseViewModel Document { get; set; } = new();

        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        public ChangeDocumentViewModel(IServiceView serviceView, DocumentBaseViewModel document)
        {
            _serviceView = serviceView;

            Document = document;

            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        void ExitLogin() => _serviceView.Close<ChangeDocumentViewModel>();
    }
}