using Raketa;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace EducationERP.Common.Components.Services
{
    public class MainTabControl(IServiceView serviceView) : ITabControl
    {
        public ObservableCollection<TabItem> TabItems { get; set; } = new();

        public void AddItem(object viewModel)
        {
            if(viewModel != null) 
                TabItems.Add(new TabItem()
                {
                    Content = viewModel
                });
        }
        public void AddItem<ViewModel>()
        {
            var uc = serviceView.UserControl<ViewModel>();
            if (uc != null) TabItems.Add(new TabItem()
            {
                Content = uc
            });
        }

        public void RemoveItem()
        {
            throw new NotImplementedException();
        }
    }
}