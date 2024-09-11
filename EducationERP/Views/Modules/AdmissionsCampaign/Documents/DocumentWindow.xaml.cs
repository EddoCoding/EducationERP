using Raketa;
using System.Windows;

namespace EducationERP.Views.Modules.AdmissionsCampaign
{
    public partial class DocumentWindow : Window, IView
    {
        public DocumentWindow() => InitializeComponent();

        public void Exit() => this.Close();
    }
}
