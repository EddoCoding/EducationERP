using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace EducationERP.Common.Components.Services
{
    public interface ITabControl
    {
        ObservableCollection<TabItem> TabItems { get; set; }

        void AddItem(object viewModel);
        void AddItem<ViewModel>();
        void RemoveItem();
    }
}