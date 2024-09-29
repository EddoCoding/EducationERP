namespace EducationERP.Models.Modules.Administration
{
    public class EducationalFormOfTraining
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FormName { get; set; } = string.Empty;

        public Guid EducationalProfileId { get; set; }
        public EducationalProfile EducationalProfile { get; set; }
    }
}