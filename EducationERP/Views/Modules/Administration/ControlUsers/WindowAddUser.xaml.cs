using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Views.Modules.Administration.ControlUsers
{
    public partial class WindowAddUser : Window, IView
    {
        public WindowAddUser()
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
