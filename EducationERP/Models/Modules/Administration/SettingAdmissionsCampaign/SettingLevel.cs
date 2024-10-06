namespace EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign
{
    public class SettingLevel
    {
        public Guid Id { get; set; }
        public string NameLevel { get; set; } = string.Empty;
        public ICollection<SettingDirection> Directions { get; set; }

        public Guid SettingFacultyId { get; set; }
        public SettingFaculty SettingFaculty { get; set; }
    }
}