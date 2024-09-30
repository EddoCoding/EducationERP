namespace EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign
{
    public class SettingForm
    {
        public Guid Id { get; set; }
        public string NameForm { get; set; } = string.Empty;

        public Guid SettingProfileId { get; set; }
        public SettingProfile SettingProfile { get; set; }
    }
}