using EducationERP.Common.Components;
using EducationERP.Common.Components.Repositories;
using EducationERP.ViewModels.LoginSetting;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration
{
    public class AdministrationViewModel : RaketaViewModel
    {
        public VisualAdministration Visual { get; set; }
        public UserViewModel UserViewModel { get; set; }
        public SettingBDViewModel SettingBDViewModel { get; set; }

        public AdministrationViewModel(IServiceView serviceView, IConfig config, DataContext context, IUserRepository userRepository, 
            UserSystem userSystem)
        {
            Visual = new(userSystem);

            UserViewModel = new(serviceView, userRepository);
            SettingBDViewModel = new(serviceView, config, context);
        }
    }
}