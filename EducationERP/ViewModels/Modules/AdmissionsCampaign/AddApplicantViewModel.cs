using EducationERP.Common.Components.Services;
using EducationERP.Models;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign
{
    public  class AddApplicantViewModel : RaketaViewModel
    {
        public Applicant Applicant { get; set; } = new();
        public ApplicantVM ApplicantVM { get; set; } = new();
        public VisualAddApplicant Visual { get; set; } = new();

        public ObservableCollection<Document> Documents { get; set; } = new(); 


        public RaketaCommand ExitCommand { get; set; }
        public RaketaCommand CitizenshipCommand { get; set; }
        public RaketaCommand CreatePersonalFileCommand { get; set; }
        public RaketaCommand AddDocumentCommand { get; set; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        public AddApplicantViewModel(IServiceView serviceView, ITabControl tabControl)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;

            Documents.Add(new Passport());
            Documents.Add(new ForeignPassport());
            Documents.Add(new Snils());
            Documents.Add(new Inn());


            ExitCommand = RaketaCommand.Launch(CloseTab);
            CitizenshipCommand = RaketaCommand.Launch(Citizenship);
            CreatePersonalFileCommand = RaketaCommand.Launch(CreatePersonalFile);

            AddDocumentCommand = RaketaCommand.Launch(AddDocument);
        }

        void CloseTab() => _tabControl.RemoveTab();
        void Citizenship()
        {
            if(ApplicantVM.IsCitizenRus == true)
            {
                ApplicantVM.Citizenship = string.Empty;
                Visual.IsEnabledTextBox = false;
            }
            if(ApplicantVM.NotCitizen == true)
            {
                ApplicantVM.Citizenship = string.Empty;
                Visual.IsEnabledTextBox = false;
            }
            if(ApplicantVM.IsForeign == true)
            {
                ApplicantVM.Citizenship = string.Empty;
                Visual.IsEnabledTextBox = true;
            }
        }
        void CreatePersonalFile() { }
        void AddDocument() => _serviceView.Window<DocumentViewModel>().NonModal();
    }
}