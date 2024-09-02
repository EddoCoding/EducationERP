using EducationERP.Common.Components.Services;
using EducationERP.Common.Components;
using Raketa;
using System.Collections.ObjectModel;
using EducationERP.Models;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign
{
    public class AdmissionsCampaignViewModel : RaketaViewModel
    {
        public ObservableCollection<Applicant> Applicants { get; set; } = new();

        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        public AdmissionsCampaignViewModel(IServiceView serviceView, ITabControl tabControl)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;

            ExitCommand = RaketaCommand.Launch(CloseTab);
        }
        void CloseTab() => _tabControl.RemoveTab();
    }
}