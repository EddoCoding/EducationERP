using System.Windows;
using System.Windows.Input;

namespace EducationERP.Modules.Login.View
{
    public partial class SettingBDWindow : Window
    {
        public SettingBDWindow()
        {
            InitializeComponent();
        }

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
