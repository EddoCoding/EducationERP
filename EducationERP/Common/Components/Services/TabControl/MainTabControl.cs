using EducationERP.Common.Components.Services.TabControl;
using Raketa;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace EducationERP.Common.Components.Services
{
    public class MainTabControl : RaketaViewModel, ITabControl
    {
        public ObservableCollection<TabItemViewModel> Tabs { get; set; } = new();
        TabItemViewModel seletedTab;
        public TabItemViewModel SeletedTab
        {
            get => seletedTab;
            set => SetValue(ref seletedTab, value);
        }

        IServiceView _serviceView;
        public MainTabControl(IServiceView serviceView)
        {
            _serviceView = serviceView;
            Tabs.CollectionChanged += OnTabsChanged;
        }
        public void CreateTab<ViewModel>(string title, string[] identifier = null, params object[] args)
        {
            var uc = _serviceView.UserControl<ViewModel>(identifier, args);
            var tab = new TabItemViewModel(title, uc);
            Tabs.Add(tab);
            SeletedTab = tab;
        }
        public void RemoveTab(TabItemViewModel tab) => Tabs.Remove(tab);
        public void RemoveTab() => Tabs.Remove(SeletedTab);

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