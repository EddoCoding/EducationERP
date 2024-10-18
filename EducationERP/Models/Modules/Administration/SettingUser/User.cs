using Raketa;

namespace EducationERP.Models.Modules.Administration.SettingUser
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Identifier { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;

        public bool? ModuleAdmissionsCampaign { get; set; } = null;
        public bool? ModuleAdministration { get; set; } = null;
        public bool? ModuleDeanRoom { get; set; } = null;
    }
}