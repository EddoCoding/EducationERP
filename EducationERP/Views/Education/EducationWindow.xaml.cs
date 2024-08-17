using Raketa;
using System.Windows;

namespace EducationERP.Views
{
    public partial class EducationWindow : Window, IView
    {
        public EducationWindow()
        {
            InitializeComponent();
        }

        public void Exit() => this.Close();
    }
}
