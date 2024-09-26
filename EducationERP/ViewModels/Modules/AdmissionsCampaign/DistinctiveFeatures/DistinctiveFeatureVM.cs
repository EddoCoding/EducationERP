﻿namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.DistinctiveFeatures
{
    public class DistinctiveFeatureVM
    {
        public string NameFeature { get; set; } = string.Empty;
        public int FeatureScore { get; set; }

        public bool Validation()
        {
            if (String.IsNullOrWhiteSpace(NameFeature)) return false;
            if (FeatureScore < 0) return false;
        
            return true;
        }
    }
}