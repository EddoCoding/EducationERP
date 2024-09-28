namespace EducationERP.Models
{
    public class EducationalLevelPreparation
    {
        public Guid Id { get; set; }
        public string LevelName { get; set; } = string.Empty;
        public ICollection<EducationalDirectionTraining> DirectionsTraining { get; set; }
    }
}