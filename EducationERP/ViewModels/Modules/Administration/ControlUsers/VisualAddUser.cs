using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.ControlUsers
{
    public class VisualAddUser : RaketaViewModel
    {
        string roleAdministration = "Без доступа";
        public string RoleAdministration
        {
            get => roleAdministration;
            set => SetValue(ref roleAdministration, value);
        }
    }
}