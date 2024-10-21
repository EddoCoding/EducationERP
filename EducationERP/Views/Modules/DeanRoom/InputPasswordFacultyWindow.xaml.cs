using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Views.Modules.DeanRoom
{
    public partial class InputPasswordFacultyWindow : Window, IView
    {
        public InputPasswordFacultyWindow() => InitializeComponent();

        public void Exit() => this.Close();

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
