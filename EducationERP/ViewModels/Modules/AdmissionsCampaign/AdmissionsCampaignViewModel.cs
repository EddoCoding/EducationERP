using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Common.ToolsDev;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign
{
    public class AdmissionsCampaignViewModel : RaketaViewModel
    {
        public ObservableCollection<ApplicantVM> Applicants { get; set; } = new();
        public ApplicantVM SelectedApplicant { get; set; }

        public RaketaCommand ExitCommand { get; set; }
        public RaketaCommand OpenTabPersonalFileCommand { get; set; }
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
            OpenTabPersonalFileCommand = RaketaCommand.Launch(CreatePersonalFile);
            ChangePersonalFileCommand = RaketaCommand.Launch(ChangePersonalFile);
            DeletePersonalFileCommand = RaketaCommand.Launch(DeletePersonalFile);
            UpdatePersonalFileCommand = RaketaCommand.Launch(UpdatePersonalFile);
        }

        void CloseTab() => _tabControl.RemoveTab();
        void CreatePersonalFile() => _tabControl.CreateTab<AddApplicantViewModel>("Добавление абитуриента");
        void ChangePersonalFile() => Dev.NotReady("Изменение личного дела");
        void DeletePersonalFile() => Dev.NotReady("Удаление личного дела");
        void UpdatePersonalFile() => Dev.NotReady("Обновление личных дел");
    }
}