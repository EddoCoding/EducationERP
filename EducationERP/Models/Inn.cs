namespace EducationERP.Models
{
    public class Inn : Document
    {
        public string NumberINN { get; set; } = string.Empty;
        public DateOnly DateAssigned { get; set; }
        public string SeriesNumber { get; set; } = string.Empty;

        public Inn() { TypeDocument = "Инн"; }
    }
}