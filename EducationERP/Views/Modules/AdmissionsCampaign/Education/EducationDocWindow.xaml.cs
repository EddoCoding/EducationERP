using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Views.Modules.AdmissionsCampaign.Education
{
    public partial class EducationDocWindow : Window, IView
    {
        public EducationDocWindow() => InitializeComponent();

        public void Exit() => this.Close();

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
