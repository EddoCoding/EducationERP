using Raketa;

namespace EducationERP.Models
{
    public class User : RaketaViewModel
    {
        string identifier = string.Empty;
        string password = string.Empty;

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Identifier
        {
            get => identifier;
            set => SetValue(ref identifier, value);
        }
        public string Password
        {
            get => password;
            set => SetValue(ref password, value);
        }
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;

        public bool? ModuleAdministration { get; set; } = null;
    }
}