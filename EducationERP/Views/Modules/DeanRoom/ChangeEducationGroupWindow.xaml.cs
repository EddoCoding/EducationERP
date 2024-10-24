using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Views.Modules.DeanRoom
{
    public partial class ChangeEducationGroupWindow : Window, IView
    {
        public ChangeEducationGroupWindow() => InitializeComponent();

        public void Exit() => this.Close();

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
