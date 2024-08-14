using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Modules.Login.View
{
    public partial class SettingBDWindow : Window, IView
    {
        public SettingBDWindow()
        {
            InitializeComponent();
        }

        public void Exit() => this.Close();

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
