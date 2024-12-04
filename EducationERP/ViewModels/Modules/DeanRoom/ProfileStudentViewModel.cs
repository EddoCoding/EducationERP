using EducationERP.Common.Components;
using EducationERP.Common.Components.Services;
using Raketa;

namespace EducationERP.ViewModels.Modules.DeanRoom
{
    public class ProfileStudentViewModel : RaketaViewModel
    {

        public RaketaCommand ExitCommand { get; }


        ITabControl _tabControl;
        public StudentVM StudentVM { get; set; }
        public UserSystem UserSystem { get; set; }
        public ProfileStudentViewModel(ITabControl tabControl, StudentVM studentVM, UserSystem userSystem)
        {
            _tabControl = tabControl;
            StudentVM = studentVM;
            UserSystem = userSystem;

            ExitCommand = RaketaCommand.Launch(CloseTab);
        }

        void CloseTab() => _tabControl.RemoveTab();
    }
}