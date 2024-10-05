using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class SettingAdmissionCampaignViewModel : RaketaViewModel
    {
        IServiceView _serviceView;
        public SettingAdmissionCampaignViewModel(IServiceView serviceView)
        {
            _serviceView = serviceView;
        }
    }
}