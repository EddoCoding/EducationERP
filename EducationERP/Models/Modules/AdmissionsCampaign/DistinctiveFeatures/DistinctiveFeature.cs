namespace EducationERP.Models.Modules.AdmissionsCampaign.DistinctiveFeatures
{
    public class DistinctiveFeature
    {
        public Guid Id { get; set; }
        public string NameFeature { get; set; } = string.Empty;
        public int FeatureScore { get; set; }

        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}