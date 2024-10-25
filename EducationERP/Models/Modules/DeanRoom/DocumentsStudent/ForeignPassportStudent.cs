namespace EducationERP.Models.Modules.DeanRoom.DocumentsStudent
{
    public class ForeignPassportStudent : DocumentStudentBase
    {
        public string IssuedBy { get; set; } = string.Empty;
        public DateOnly DateOfIssue { get; set; }
        public string SeriesNumber { get; set; } = string.Empty;
    }
}