namespace EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign
{
    public class SettingDirection
    {
        public Guid Id { get; set; }
        public string CodeDirection { get; set; } = string.Empty;
        public string NameDirection { get; set; } = string.Empty;
        public ICollection<SettingProfile> Profiles { get; set; }

        public Guid SettingLevelId { get; set; }
        public SettingLevel SettingLevel { get; set; }
    }
}