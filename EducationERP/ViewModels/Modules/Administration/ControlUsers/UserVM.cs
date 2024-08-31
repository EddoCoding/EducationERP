using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.ControlUsers
{
    public class UserVM : RaketaViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public bool? ModuleAdministration { get; set; } = null;
    }
}