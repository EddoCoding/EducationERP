namespace EducationERP.Models
{
    public class ForeignPassport : Document
    {
        public string IssuedBy { get; set; } = string.Empty;
        public DateOnly DateOfIssue { get; set; }
        public string SeriesNumber { get; set; } = string.Empty;

        public ForeignPassport() { TypeDocument = "Иностранный паспорт"; }
    }
}