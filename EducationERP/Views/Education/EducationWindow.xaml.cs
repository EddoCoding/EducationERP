using Raketa;
using System.Windows;
using System.Windows.Input;

namespace EducationERP.Views
{
    public partial class EducationWindow : Window, IView
    {
        public EducationWindow()
        {
            InitializeComponent();
        }

        public void Exit() => this.Close();

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
