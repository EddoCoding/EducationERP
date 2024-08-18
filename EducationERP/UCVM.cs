using EducationERP.Common.Components.Services;
using Raketa;

namespace EducationERP
{
    public class UCVM
    {
        public string Text { get; set; } = string.Empty;

        public RaketaCommand Command { get; set; }

        ITabControl _tabControl;
        public UCVM(ITabControl tabControl)
        {
            _tabControl = tabControl;
            Text = new Random().Next(1, 100).ToString();
            Command = RaketaCommand.Launch(CloseTab);
        }

        void CloseTab() => _tabControl.RemoveTab();
    }
}
