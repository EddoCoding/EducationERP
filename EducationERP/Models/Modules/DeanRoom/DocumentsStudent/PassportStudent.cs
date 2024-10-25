namespace EducationERP.Models.Modules.DeanRoom.DocumentsStudent
{
    public class PassportStudent : DocumentStudentBase
    {
        public string IssuedBy { get; set; } = string.Empty;
        public DateOnly DateOfIssue { get; set; }
        public string DepartmentCode { get; set; } = string.Empty;
        public string SeriesNumber { get; set; } = string.Empty;
    }
}