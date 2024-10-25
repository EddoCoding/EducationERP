namespace EducationERP.Models.Modules.DeanRoom.DocumentsStudent
{
    public class InnStudent : DocumentStudentBase
    {
        public string NumberINN { get; set; } = string.Empty;
        public DateOnly DateAssigned { get; set; }
        public string SeriesNumber { get; set; } = string.Empty;
    }
}