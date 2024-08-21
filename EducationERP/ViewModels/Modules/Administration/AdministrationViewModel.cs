using EducationERP.Common.Components;
using EducationERP.ViewModels.LoginSetting;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration
{
    public class AdministrationViewModel : RaketaViewModel
    {
        public SettingBDViewModel SettingBDViewModel { get; set; }

        public AdministrationViewModel(IServiceView serviceView, IConfig config)
        {
            SettingBDViewModel = new(serviceView, config);
        }
    }
}