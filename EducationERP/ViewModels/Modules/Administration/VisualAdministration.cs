using EducationERP.Common.Components;
using EducationERP.Models.Modules.EducationalInstitution;

namespace EducationERP.ViewModels.Modules.Administration
{
    public class VisualAdministration
    {
        public bool StructVuz { get; set; } = false;
        public bool ControlUsers { get; set; } = false;
        public bool Department { get; set; } = false;
        public bool AdmissionCampaign { get; set; } = false;
        public bool DeanRoom { get; set; } = false;
        public bool SettingBD { get; set; } = false;

        public VisualAdministration(UserSystem userSystem) => GetAccess(userSystem);

        void GetAccess(UserSystem userSystem)
        {
            if (userSystem.CheckToGuest())
            {
                SettingBD = true;
                return;
            }

            if (userSystem.AdmissionsCampaign == true) AdmissionCampaign = true;
            if (userSystem.DeanRoom == true) DeanRoom = true;
            if(userSystem.Administration == true)
            {
                StructVuz = true;
                ControlUsers = true;
                SettingBD = true;
            }
        }
    }
}