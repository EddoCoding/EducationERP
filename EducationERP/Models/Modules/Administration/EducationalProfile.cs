namespace EducationERP.Models.Modules.Administration
{
    public class EducationalProfile
    {
        public Guid Id { get; set; }
        public string ProfileCode { get; set; } = string.Empty;
        public string ProfileName { get; set; } = string.Empty;

        public Guid EducationalDirectionTrainingId { get; set; }
        public EducationalDirectionTraining EducationalDirectionTraining { get; set; }
    }
}