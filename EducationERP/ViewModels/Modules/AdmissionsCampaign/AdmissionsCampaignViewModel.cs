using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign
{
    public class AdmissionsCampaignViewModel : RaketaViewModel
    {
        public ObservableCollection<ApplicantVM> Applicants { get; set; } = new();
        public ApplicantVM SelectedApplicant { get; set; }

        public RaketaCommand ExitCommand { get; set; }
        public RaketaCommand CreatePersonalFileCommand { get; set; }
        public RaketaCommand ChangePersonalFileCommand { get; set; }
        public RaketaCommand DeletePersonalFileCommand { get; set; }
        public RaketaCommand UpdatePersonalFileCommand { get; set; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        IApplicantRepository _applicantRepository;
        public AdmissionsCampaignViewModel(IServiceView serviceView, ITabControl tabControl, IApplicantRepository applicantRepository)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;
            _applicantRepository = applicantRepository;

            ExitCommand = RaketaCommand.Launch(CloseTab);
            CreatePersonalFileCommand = RaketaCommand.Launch(CreatePersonalFile);
            ChangePersonalFileCommand = RaketaCommand.Launch(ChangePersonalFile);
            DeletePersonalFileCommand = RaketaCommand.Launch(DeletePersonalFile);
            UpdatePersonalFileCommand = RaketaCommand.Launch(UpdatePersonalFile);
        }

        void CloseTab() => _tabControl.RemoveTab();
        void CreatePersonalFile() => _applicantRepository.CreatePersonalFile();
        void ChangePersonalFile() => _applicantRepository.ChangePersonalFile();
        void DeletePersonalFile() => _applicantRepository.DeletePersonalFile();
        void UpdatePersonalFile() => _applicantRepository.UpdatePersonalFiles();
    }
}