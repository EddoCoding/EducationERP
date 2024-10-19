using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Views.Modules.Administration.SettingEducationalInstitution
{
    public partial class AddMainFacultyWindow : Window, IView
    {
        public AddMainFacultyWindow() => InitializeComponent();

        public void Exit() => this.Close();

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
