using EducationERP.Common.Components;
using EducationERP.Common.Components.Services;
using EducationERP.ViewModels.Education;
using EducationERP.ViewModels.Modules.Administration;
using Raketa;

namespace EducationERP.ViewModels
{
    public class EducationViewModel : RaketaViewModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public VisualEducation Visual { get; set; } = new();
        public RaketaCommand OpenEducationMenuCommand { get; set; }
        public RaketaCommand AdministrationCommand { get; set; }

        IServiceView _serviceView;
        public ITabControl TabControl { get; set; }
        public EducationViewModel(IServiceView serviceView, ITabControl tabControl, UserSystem userSystem)
        {
            FullName = userSystem.FullName;

            _serviceView = serviceView;
            TabControl = tabControl;

            OpenEducationMenuCommand = RaketaCommand.Launch(CloseEducationWindow);
            AdministrationCommand = RaketaCommand.Launch(OpenAdministration);
        }

        void CloseEducationWindow() => _serviceView.Close<EducationViewModel>();
        void OpenAdministration() => TabControl.CreateTab<AdministrationViewModel>("Администрирование");
    }
}