using Raketa;
using System.Windows;

namespace EducationERP.ViewModels.Modules.Administration.ControlUsers
{
    public class VisualAddUser : RaketaViewModel
    {
        Visibility administrationVisibility = Visibility.Collapsed;
        public Visibility AdministrationVisibility
        {
            get => administrationVisibility;
            set => SetValue(ref administrationVisibility, value);
        } 
    }
}