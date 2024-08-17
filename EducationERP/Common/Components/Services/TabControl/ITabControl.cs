using EducationERP.Common.Components.Services.TabControl;
using System.Collections.ObjectModel;

namespace EducationERP.Common.Components.Services
{
    public interface ITabControl
    {
        ObservableCollection<TabItemViewModel> TabItems { get; set; }

        void AddItem(object viewModel, string title);
        void AddItem<ViewModel>(string title);
        void CloseTab(TabItemViewModel tab);
    }
}