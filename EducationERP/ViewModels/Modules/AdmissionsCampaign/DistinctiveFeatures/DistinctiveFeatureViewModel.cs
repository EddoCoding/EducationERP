using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.AdmissionsCampaign.DistinctiveFeatures;
using EducationERP.Models.Modules.AdmissionsCampaign.Exams;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Exams;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.DistinctiveFeatures
{
    public class DistinctiveFeatureViewModel : RaketaViewModel
    {
        public DistinctiveFeatureVM DistinctiveFeature { get; set; } = new();

        ObservableCollection<DistinctiveFeatureVM> _distinctiveFeatures;

        public RaketaTCommand<DistinctiveFeatureVM> AddDistinctiveFeatureCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        IApplicantRepository _applicantRepository;
        Guid _id;
        bool _useDataBase;
        public DistinctiveFeatureViewModel(IServiceView serviceView, IApplicantRepository applicantRepository, 
            ObservableCollection<DistinctiveFeatureVM> distinctiveFeatures, Guid id = default, bool useDataBase = false)
        {
            _serviceView = serviceView;
            _applicantRepository = applicantRepository;
            _distinctiveFeatures = distinctiveFeatures;
            _id = id;
            _useDataBase = useDataBase;

            AddDistinctiveFeatureCommand = RaketaTCommand<DistinctiveFeatureVM>.Launch(AddDistinctiveFeature);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        void AddDistinctiveFeature(DistinctiveFeatureVM DistinctiveFeature)
        {
            var isValidated = DistinctiveFeature.Validation();
            if (isValidated)
            {
                _distinctiveFeatures.Add(DistinctiveFeature);
                _distinctiveFeatures = null;
                if (_useDataBase)
                {
                    var distinctiveFeature = new DistinctiveFeature
                    {
                        Id = DistinctiveFeature.Id,
                        NameFeature = DistinctiveFeature.NameFeature,
                        FeatureScore = DistinctiveFeature.FeatureScore,
                        ApplicantId = _id
                    };
                    _applicantRepository.Create<DistinctiveFeature>(distinctiveFeature);
                }
                _serviceView.Close<DistinctiveFeatureViewModel>();
            }
        }
        void CloseWindow() => _serviceView.Close<DistinctiveFeatureViewModel>();
    }
}