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
        };

        DocumentBaseViewModel selectedDocument;
        public DocumentBaseViewModel SelectedDocument
        {
            get => selectedDocument;
            set => SetValue(ref selectedDocument, value);
        }

        public DocumentViewModel()
        {
            
        }
    }
}