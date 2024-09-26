using System.Windows;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.DistinctiveFeatures
{
    public class DistinctiveFeatureVM
    {
        public string NameFeature { get; set; } = string.Empty;
        public int FeatureScore { get; set; }

        public bool Validation()
        {
            if (String.IsNullOrWhiteSpace(NameFeature) || String.IsNullOrWhiteSpace(FeatureScore.ToString()))
            {
                MessageBox.Show("Данные неполные!");
                return false;
            }
            if (FeatureScore < 0)
            {
                MessageBox.Show("Балл не может быть меньше нуля");
                return false;
            }
        
            return true;
        }
    }
}