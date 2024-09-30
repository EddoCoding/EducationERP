namespace EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign
{
    public class SettingProfile
    {
        public Guid Id { get; set; }
        public string CodeProfile { get; set; } = string.Empty;
        public string NameProfile { get; set; } = string.Empty;
        public ICollection<SettingForm> Forms { get; set; }

        public Guid SettingDirectionId { get; set; }
        public SettingDirection SettingDirection { get; set; }
    }
}