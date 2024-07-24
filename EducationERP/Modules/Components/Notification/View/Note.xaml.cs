using System.Windows;
using System.Windows.Input;

namespace EducationERP.Modules.Components.Notification.View
{
    public partial class Note : Window
    {
        public Note()
        {
            InitializeComponent();
        }

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
