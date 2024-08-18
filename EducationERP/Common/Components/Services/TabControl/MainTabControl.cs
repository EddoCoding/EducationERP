using EducationERP.Common.Components.Services.TabControl;
using Raketa;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace EducationERP.Common.Components.Services
{
    public class MainTabControl : ITabControl
    {
        public ObservableCollection<TabItemViewModel> Tabs { get; set; } = new();

        IServiceView _serviceView;
        public MainTabControl(IServiceView serviceView)
        {
            _serviceView = serviceView;
            Tabs.CollectionChanged += OnTabsChanged;
        }
        public void CreateTab<ViewModel>(string title)
        {
            var uc = _serviceView.UserControl<ViewModel>();
            if (uc != null) Tabs.Add(new TabItemViewModel(title, uc));
        }
        public void RemoveTab(TabItemViewModel tab) => Tabs.Remove(tab);

        void OnTabsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (TabItemViewModel item in e.OldItems) item.OnClose -= RemoveTab;
            }
            if (e.NewItems != null)
            {
                foreach (TabItemViewModel item in e.NewItems) item.OnClose += RemoveTab;
            }
        }
    }
}