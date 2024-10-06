namespace EducationERP.Models.Modules.AdmissionsCampaign
{
    public class Passport : Document
    {
        public string IssuedBy { get; set; } = string.Empty;
        public DateOnly DateOfIssue { get; set; }
        public string DepartmentCode { get; set; } = string.Empty;
        public string SeriesNumber { get; set; } = string.Empty;

        public Passport() { TypeDocument = "Паспорт"; }
    }
}