using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.ControlUsers
{
    public class UserVM : RaketaViewModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}