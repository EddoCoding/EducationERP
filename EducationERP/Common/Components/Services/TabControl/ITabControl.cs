using EducationERP.Common.Components.Services.TabControl;
using System.Collections.ObjectModel;

namespace EducationERP.Common.Components.Services
{
    public interface ITabControl
    {
        ObservableCollection<TabItemViewModel> Tabs { get; set; }

        void CreateTab<ViewModel>(string title);
        void RemoveTab(TabItemViewModel tab);
        void RemoveTab();
    }
}