using EducationERP.Common.Components.Services.TabControl;
using Raketa;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace EducationERP.Common.Components.Services
{
    public class MainTabControl : ITabControl
    {
        public ObservableCollection<TabItemViewModel> TabItems { get; set; } = new();

        IServiceView _serviceView;
        public MainTabControl(IServiceView serviceView)
        {
            _serviceView = serviceView;

            TabItems.CollectionChanged += OnTabsChanged;
        }
        
        public void AddItem(object viewModel, string title)
        {
            if (viewModel != null)
                TabItems.Add(new TabItemViewModel(title, viewModel));
        }
        public void AddItem<ViewModel>(string title)
        {
            var uc = _serviceView.UserControl<ViewModel>();
            if (uc != null) TabItems.Add(new TabItemViewModel(title, uc));
        }

        void OnTabsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (TabItemViewModel item in e.OldItems)
                    item.OnClose -= CloseTab;
            }
            if (e.NewItems != null)
            {
                foreach (TabItemViewModel item in e.NewItems)
                    item.OnClose += CloseTab;
            }
        }

        public void CloseTab(TabItemViewModel tab) => TabItems.Remove(tab);
    }
}