using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Views.Modules.DeanRoom.DocumentsStudent
{
    public partial class AddDocumentStudentWindow : Window, IView
    {
        public AddDocumentStudentWindow() => InitializeComponent();

        public void Exit() => this.Close();

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
