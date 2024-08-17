using Raketa;

namespace EducationERP.Common.Components.Services.TabControl
{
    public class TabItemViewModel
    {
        public string Title { get; set; }
        public object Content { get; set; }

        public RaketaCommand CloseCommand { get; set; }

        public TabItemViewModel(string title, object content)
        {
            (Title, Content) = (title, content);

            CloseCommand = RaketaCommand.Launch(Close);
        }
            
        public event Action<TabItemViewModel> OnClose;
        void Close() => OnClose?.Invoke(this);
    }
}