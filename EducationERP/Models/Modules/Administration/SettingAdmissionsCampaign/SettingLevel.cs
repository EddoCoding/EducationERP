using System.Collections.ObjectModel;

namespace EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign
{
    public class SettingLevel
    {
        public Guid Id { get; set; }
        public string NameLevel { get; set; } = string.Empty;
        public ICollection<SettingDirection> Directions { get; set; }
    }
}