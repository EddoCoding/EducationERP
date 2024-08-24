namespace EducationERP.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Identifier { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Role { get ; set; } = string.Empty;
    }
}