namespace EducationERP.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Identifier { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;

        public bool? ModuleAdministration { get; set; } = null;
    }
}