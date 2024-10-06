using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Views.Modules.Administration.SettingAdmissionCampaign
{
    public partial class AddSettingFacultyWindow : Window, IView
    {
        public AddSettingFacultyWindow() => InitializeComponent();

        public void Exit() => this.Close();

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}