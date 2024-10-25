namespace EducationERP.Models.Modules.DeanRoom.DocumentsStudent
{
    public class SnilsStudent : DocumentStudentBase
    {
        public string Number { get; set; } = string.Empty;
        public DateOnly RegistrationDate { get; set; }
    }
}