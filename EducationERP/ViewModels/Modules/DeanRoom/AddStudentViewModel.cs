using EducationERP.Common.Components.Services;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using Raketa;

namespace EducationERP.ViewModels.Modules.DeanRoom
{
    public class AddStudentViewModel : RaketaViewModel
    {
        public StudentVM StudentVM { get; set; } = new();

        public RaketaCommand ExitCommand { get; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        EducationGroupVM _educationGroupVM;
        public AddStudentViewModel(IServiceView serviceView, ITabControl tabControl, EducationGroupVM educationGroupVM)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;
            _educationGroupVM = educationGroupVM;

            ExitCommand = RaketaCommand.Launch(CloseTab);
        }

        void CloseTab() => _tabControl.RemoveTab();
    }
}