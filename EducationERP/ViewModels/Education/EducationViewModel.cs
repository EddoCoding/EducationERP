using EducationERP.Common.Components.Services;
using EducationERP.ViewModels.Education;
using Raketa;

namespace EducationERP.ViewModels
{
    public class EducationViewModel : RaketaViewModel
    {
        public VisualEducationViewModel Visual { get; set; } = new();
        public RaketaCommand OpenEducationMenuCommand { get; set; }
        public RaketaCommand AddCommand { get; set; }

        IServiceView _serviceView;
        public ITabControl TabControl { get; set; }
        public EducationViewModel(IServiceView serviceView, ITabControl tabControl)
        {
            _serviceView = serviceView;
            TabControl = tabControl;

            OpenEducationMenuCommand = RaketaCommand.Launch(CloseEducationWindow);

            AddCommand = RaketaCommand.Launch(() =>
            {
                tabControl.CreateTab<UCVM>("Вкладка");
            });
        }

        void CloseEducationWindow() => _serviceView.Close<EducationViewModel>();
    }
}