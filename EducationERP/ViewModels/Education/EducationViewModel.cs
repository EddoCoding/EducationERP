﻿using EducationERP.Common.Components;
using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.ViewModels.Education;
using EducationERP.ViewModels.Modules.Administration;
using EducationERP.ViewModels.Modules.AdmissionsCampaign;
using EducationERP.ViewModels.Modules.DeanRoom;
using Raketa;

namespace EducationERP.ViewModels
{
    public class EducationViewModel : RaketaViewModel
    {
        public string FullName { get; set; } = string.Empty;

        public VisualEducation Visual { get; set; }
        public RaketaCommand ExitCommand { get; set; }
        public RaketaTCommand<string> ModuleCommand { get; set; }

        IServiceView _serviceView;
        public ITabControl TabControl { get; set; }
        public EducationViewModel(IServiceView serviceView, ITabControl tabControl, UserSystem userSystem)
        {
            FullName = userSystem.FullName;

            Visual = new(userSystem);
            _serviceView = serviceView;
            TabControl = tabControl;

            ExitCommand = RaketaCommand.Launch(CloseWindow);
            ModuleCommand = RaketaTCommand<string>.Launch(OpenModule);
        }

        void CloseWindow() => _serviceView.Close<EducationViewModel>();
        void OpenModule(string module)
        {
            switch(module)
            {
                case "Приёмная кампания":
                    TabControl.CreateTab<AdmissionsCampaignViewModel>(module);
                    break;
                case "Деканат":
                    _serviceView.Window<InputPasswordFacultyViewModel>().Modal();
                    break;
                case "Администрирование":
                    TabControl.CreateTab<AdministrationViewModel>(module);
                    break;
            }
        }
    }
}