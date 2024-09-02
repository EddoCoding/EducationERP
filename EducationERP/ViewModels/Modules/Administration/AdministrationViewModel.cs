using EducationERP.Common.Components;
using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.ViewModels.LoginSetting;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration
{
    public class AdministrationViewModel : RaketaViewModel
    {
        public VisualAdministration Visual { get; set; }
        public UserViewModel UserViewModel { get; set; }
        public SettingBDViewModel SettingBDViewModel { get; set; }

        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        public AdministrationViewModel(IServiceView serviceView, IConfig config, ITabControl tabControl, DataContext context, 
            IUserRepository userRepository, UserSystem userSystem)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;

            Visual = new(userSystem);
            UserViewModel = new(serviceView, userRepository);
            SettingBDViewModel = new(serviceView, config, context);

            ExitCommand = RaketaCommand.Launch(CloseTab);
        }
        void CloseTab() => _tabControl.RemoveTab();
    }
}