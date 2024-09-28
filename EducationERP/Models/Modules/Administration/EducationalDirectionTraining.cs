namespace EducationERP.Models
{
    public class EducationalDirectionTraining
    {
        public Guid Id { get; set; }
        public string DirectionCode { get; set; } = string.Empty;
        public string DirectionName { get; set; } = string.Empty;

        public Guid EducationalLevelPreparationId { get; set; }
        public EducationalLevelPreparation EducationalLevelPreparation { get; set; }
    }
}