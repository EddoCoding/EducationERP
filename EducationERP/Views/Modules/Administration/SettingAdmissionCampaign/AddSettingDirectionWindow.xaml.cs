using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Views.Modules.Administration.SettingAdmissionCampaign
{
    public partial class AddSettingDirectionWindow : Window, IView
    {
        public AddSettingDirectionWindow() => InitializeComponent();

        public void Exit() => this.Close();

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
