using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Views.Modules.AdmissionsCampaign.Exams
{
    public partial class AddExamWindow : Window, IView
    {
        public AddExamWindow() => InitializeComponent();

        public void Exit() => this.Close();

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
