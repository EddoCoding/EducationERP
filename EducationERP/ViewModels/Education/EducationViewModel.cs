using EducationERP.Common.Components.Services;
using EducationERP.Common.ToolsDev;
using EducationERP.ViewModels.Education;
using Raketa;

namespace EducationERP.ViewModels
{
    public class EducationViewModel : RaketaViewModel
    {
        public VisualEducationViewModel Visual { get; set; } = new();
        public RaketaCommand AddTabItemCommand1 { get; set; }
        public RaketaCommand AddTabItemCommand2 { get; set; }
        public RaketaCommand CommandMessage { get; set; }

        IServiceView _serviceView;
        public ITabControl TabControl { get; set; }
        public EducationViewModel(IServiceView serviceView, ITabControl tabControl)
        {
            _serviceView = serviceView;
            TabControl = tabControl;

            AddTabItemCommand1 = RaketaCommand.Launch(AddTabItem1);
            AddTabItemCommand2 = RaketaCommand.Launch(AddTabItem2);
            CommandMessage = RaketaCommand.Launch(() =>
            {
                Dev.NotReady();
            });
        }

        void AddTabItem1() => TabControl.AddItem<UserControlViewModel>("Вкладка1");
        void AddTabItem2() => TabControl.AddItem<Class1>("Вкладка2");
    }
}