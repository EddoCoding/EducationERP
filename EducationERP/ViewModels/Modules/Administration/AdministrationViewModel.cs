using EducationERP.Common.Components;
using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.ViewModels.LoginSetting;
using EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration
{
    public class AdministrationViewModel : RaketaViewModel
    {
        public VisualAdministration Visual { get; set; }

        public SettingStructEducationalViewModel SettingStructEducationalViewModel { get; set;} //Настройка структуры учебного заведения
        public UserViewModel UserViewModel { get; set; } //Настройка пользователей
        public SettingAdmissionCampaignViewModel SettingAdmissionCampaignViewModel { get; set; } //Настройка приёмной кампании
        public SettingBDViewModel SettingBDViewModel { get; set; } //Настройка базы данных

        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        public AdministrationViewModel(IServiceView serviceView, IConfig config, ITabControl tabControl, DataContext context, 
            UserSystem userSystem, IUserRepository userRepository, ISettingFacultyRepository facultyRepository, IStructEducationRepository structEducationRepository)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;

            Visual = new(userSystem);

            SettingStructEducationalViewModel = new(serviceView, structEducationRepository);
            UserViewModel = new(serviceView, userRepository);
            SettingAdmissionCampaignViewModel = new(serviceView, facultyRepository);
            SettingBDViewModel = new(serviceView, config, context);

            ExitCommand = RaketaCommand.Launch(CloseTab);
        }
        void CloseTab() => _tabControl.RemoveTab();
    }
}