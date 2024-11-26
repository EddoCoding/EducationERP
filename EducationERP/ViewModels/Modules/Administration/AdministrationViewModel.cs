using EducationERP.Common.Components;
using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Common.ToolsDev;
using EducationERP.ViewModels.LoginSetting;
using EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration
{
    public class AdministrationViewModel : RaketaViewModel
    {
        public VisualAdministration Visual { get; set; }

        public RaketaCommand ExitCommand { get; set; }

        public RaketaCommand SettingStructCommand { get; }
        public RaketaCommand SettingUsersCommand { get; }
        public RaketaCommand SettingDepartmentCommand { get; }
        public RaketaCommand SettingAdmissionCampaignCommand { get; }
        public RaketaCommand SettingDeanRoomCommand { get; }
        public RaketaCommand SettingBDCommand { get; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        public AdministrationViewModel(IServiceView serviceView, IConfig config, ITabControl tabControl, DataContext context, 
            UserSystem userSystem, IUserRepository userRepository, ISettingFacultyRepository facultyRepository, IStructEducationRepository structEducationRepository)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;

            Visual = new(userSystem);

            ExitCommand = RaketaCommand.Launch(CloseTab);

            SettingStructCommand = RaketaCommand.Launch(SettingStruct);
            SettingUsersCommand = RaketaCommand.Launch(SettingUsers);
            SettingDepartmentCommand = RaketaCommand.Launch(SettingDepartment);
            SettingAdmissionCampaignCommand = RaketaCommand.Launch(SettingAdmissionCampaign);
            SettingDeanRoomCommand = RaketaCommand.Launch(SettingDeanRoom);
            SettingBDCommand = RaketaCommand.Launch(SettingBD);
        }
        void CloseTab() => _tabControl.RemoveTab();
        void SettingStruct() => _tabControl.CreateTab<SettingStructEducationalViewModel>("Структура учебного заведения");
        void SettingUsers() => _tabControl.CreateTab<UserViewModel>("Управление пользователями");
        void SettingDepartment() => Dev.NotReady();
        void SettingAdmissionCampaign() => _tabControl.CreateTab<SettingAdmissionCampaignViewModel>("Настройка приёмной кампании");
        void SettingDeanRoom() => Dev.NotReady();
        void SettingBD() => _tabControl.CreateTab<SettingBDViewModel>("Настройка базы данных");
    }
}