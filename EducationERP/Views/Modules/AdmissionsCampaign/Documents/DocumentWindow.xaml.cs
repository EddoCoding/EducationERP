using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Views.Modules.AdmissionsCampaign
{
    public partial class DocumentWindow : Window, IView
    {
        public DocumentWindow() => InitializeComponent();

        public void Exit() => this.Close();

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
