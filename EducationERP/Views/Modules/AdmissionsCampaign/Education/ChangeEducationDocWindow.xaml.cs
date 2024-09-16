using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Views.Modules.AdmissionsCampaign.Education
{
    public partial class ChangeEducationDocWindow : Window, IView
    {
        public ChangeEducationDocWindow() => InitializeComponent();

        public void Exit() => this.Close();

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
