using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;

namespace EducationERP.Models.Modules.EducationalInstitution
{
    public class StructEducationalInstitution
    {
        public Guid Id { get; set; }
        public string NameVUZ { get; set; } = string.Empty;
        public string ShortNameVUZ { get; set; } = string.Empty;
        public ICollection<Faculty> Faculties { get; set; }
        public ICollection<SettingFaculty> ACFaculties { get; set; }
    }
}