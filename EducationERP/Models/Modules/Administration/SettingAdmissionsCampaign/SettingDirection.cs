namespace EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign
{
    public class SettingDirection
    {
        public Guid Id { get; set; }
        public string CodeDirection { get; set; } = string.Empty;
        public string NameDirection { get; set; } = string.Empty;
        public string CodeProfile { get; set; } = string.Empty;
        public string NameProfile { get; set; } = string.Empty;
        public string NameFormEducation { get; set; } = string.Empty;
        public string NameFormPayment { get; set; } = string.Empty;

        public Guid SettingLevelId { get; set; }
        public SettingLevel SettingLevel { get; set; }
    }
}