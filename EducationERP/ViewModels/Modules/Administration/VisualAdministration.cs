using EducationERP.Common.Components;

namespace EducationERP.ViewModels.Modules.Administration
{
    public class VisualAdministration
    {
        public bool ControlUsers { get; set; } = false;
        public bool SettingBD { get; set; } = false;

        public VisualAdministration(UserSystem userSystem) => GetAccess(userSystem);

        void GetAccess(UserSystem userSystem) 
        {
            if (userSystem.Administration == true) 
            {
                ControlUsers = true;
                SettingBD = true;
            }
            else
            {
                ControlUsers = true;
                SettingBD = false;
            }
        }
    }
}