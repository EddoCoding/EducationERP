using EducationERP.Common.Components;
using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Models;
using EducationERP.ViewModels.LoginSetting;
using EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration
{
    public class AdministrationViewModel : RaketaViewModel
    {
        public VisualAdministration Visual { get; set; }
        public UserViewModel UserViewModel { get; set; }
        public SettingAdmissionCampaignViewModel SettingAdmissionCampaignViewModel { get; set; }
        public SettingBDViewModel SettingBDViewModel { get; set; }

        public RaketaTCommand<ObservableCollection<EducationalLevelPreparationVM>> OpenWindowAddLevelCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        public AdministrationViewModel(IServiceView serviceView, IConfig config, ITabControl tabControl, DataContext context, 
            IUserRepository userRepository, ILevelRepository levelRepository, UserSystem userSystem)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;

            Visual = new(userSystem);
            UserViewModel = new(serviceView, userRepository);
            SettingAdmissionCampaignViewModel = new(levelRepository);
            SettingBDViewModel = new(serviceView, config, context);

            OpenWindowAddLevelCommand = RaketaTCommand<ObservableCollection<EducationalLevelPreparationVM>>.Launch(OpenWindowAddLevel);
            ExitCommand = RaketaCommand.Launch(CloseTab);
        }

        void OpenWindowAddLevel(ObservableCollection<EducationalLevelPreparationVM> levels) => 
            _serviceView.Window<AddSettingLevelViewModel>(null, levels).NonModal();

        void CloseTab() => _tabControl.RemoveTab();
    }
}