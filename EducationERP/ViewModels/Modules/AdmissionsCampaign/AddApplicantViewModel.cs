using EducationERP.Common.Components.Services;
using EducationERP.Models;
using Raketa;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign
{
    public  class AddApplicantViewModel : RaketaViewModel
    {
        public Applicant Applicant { get; set; } = new();

        public RaketaCommand ExitCommand { get; set; }

        ITabControl _tabControl;
        public AddApplicantViewModel(ITabControl tabControl)
        {
            _tabControl = tabControl;

            ExitCommand = RaketaCommand.Launch(CloseTab);
        }

        void CloseTab() => _tabControl.RemoveTab();
    }
}