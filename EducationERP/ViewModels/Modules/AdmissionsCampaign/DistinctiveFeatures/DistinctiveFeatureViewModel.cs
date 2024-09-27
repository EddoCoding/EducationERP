using EducationERP.ViewModels.Modules.AdmissionsCampaign.Exams;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.DistinctiveFeatures
{
    public class DistinctiveFeatureViewModel : RaketaViewModel
    {
        public DistinctiveFeatureVM DistinctiveFeature { get; set; } = new();

        ObservableCollection<DistinctiveFeatureVM> distinctiveFeatures;

        public RaketaTCommand<DistinctiveFeatureVM> AddDistinctiveFeatureCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        public DistinctiveFeatureViewModel(IServiceView serviceView, ObservableCollection<DistinctiveFeatureVM> distinctiveFeatures)
        {
            _serviceView = serviceView;
            this.distinctiveFeatures = distinctiveFeatures;

            AddDistinctiveFeatureCommand = RaketaTCommand<DistinctiveFeatureVM>.Launch(AddDistinctiveFeature);
            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        void AddDistinctiveFeature(DistinctiveFeatureVM distinctiveFeature)
        {
            var isValidated = distinctiveFeature.Validation();
            if (isValidated)
            {
                distinctiveFeatures.Add(distinctiveFeature);
                distinctiveFeatures = null;
                _serviceView.Close<DistinctiveFeatureViewModel>();
            }
        }
        void ExitLogin() => _serviceView.Close<DistinctiveFeatureViewModel>();
    }
}