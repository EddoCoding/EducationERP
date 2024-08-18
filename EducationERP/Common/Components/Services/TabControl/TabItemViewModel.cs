using Raketa;

namespace EducationERP.Common.Components.Services.TabControl
{
    public class TabItemViewModel
    {
        public string TitleTab { get; set; }
        public object ContentTab { get; set; }

        public RaketaCommand CloseCommand { get; set; }

        public TabItemViewModel(string titleTab, object contentTab)
        {
            (TitleTab, ContentTab) = (titleTab, contentTab);
            CloseCommand = RaketaCommand.Launch(CloseTab);
        }
            
        public event Action<TabItemViewModel> OnClose;
        void CloseTab() => OnClose?.Invoke(this);
    }
}