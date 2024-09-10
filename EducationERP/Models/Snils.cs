namespace EducationERP.Models
{
    public class Snils : Document
    {
        public string Number { get; set; } = string.Empty;
        public DateOnly RegistrationDate { get; set; }

        public Snils() { TypeDocument = "Снилс"; }
    }
}