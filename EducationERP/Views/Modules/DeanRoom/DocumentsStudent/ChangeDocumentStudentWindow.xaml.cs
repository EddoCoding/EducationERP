using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Views.Modules.DeanRoom.DocumentsStudent
{
    public partial class ChangeDocumentStudentWindow : Window, IView
    {
        public ChangeDocumentStudentWindow() => InitializeComponent();

        public void Exit() => this.Close();

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
