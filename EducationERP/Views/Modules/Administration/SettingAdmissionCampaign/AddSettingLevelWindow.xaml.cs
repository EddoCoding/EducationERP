using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Views.Modules.Administration.SettingAdmissionCampaign
{
    public partial class AddSettingLevelWindow : Window, IView
    {
        public AddSettingLevelWindow() => InitializeComponent();

        public void Exit() => this.Close();

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
