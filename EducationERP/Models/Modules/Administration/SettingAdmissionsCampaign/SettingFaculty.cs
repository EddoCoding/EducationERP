namespace EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign
{
    public class SettingFaculty
    {
        public Guid Id { get; set; }
        public string NameFaculty { get; set; } = string.Empty;
        public ICollection<SettingLevel> Levels { get; set; }
    }
}