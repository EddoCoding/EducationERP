using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Views.Modules.DeanRoom
{
    public partial class AddEducationGroupWindow : Window, IView
    {
        public AddEducationGroupWindow() => InitializeComponent();

        public void Exit() => this.Close();

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
