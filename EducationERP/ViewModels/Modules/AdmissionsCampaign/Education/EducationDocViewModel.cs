using EducationERP.Common.Components.Repositories;
using Raketa;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Education
{
    public class EducationDocViewModel : RaketaViewModel
    {
        public EducationBaseViewModel[] Educations { get; set; } =
        {
            new EducationNineViewModel(),
            new EducationElevenViewModel(),
            new EducationSpoViewModel(),
            new EducationBakViewModel(),
            new EducationMagViewModel(),
            new EducationAspViewModel()
        }; // ОБРАЗОВАНИЕ

        EducationBaseViewModel selectedEducation;
        public EducationBaseViewModel SelectedEducation
        {
            get => selectedEducation;
            set => SetValue(ref selectedEducation, value);
        }

        public RaketaTCommand<EducationBaseViewModel> AddEducationCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        IApplicantRepository _applicantRepository;
        public EducationDocViewModel(IServiceView serviceView, IApplicantRepository applicantRepository)
        {
            _serviceView = serviceView;
            _applicantRepository = applicantRepository;

            AddEducationCommand = RaketaTCommand<EducationBaseViewModel>.Launch(AddEducation);
            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        void AddEducation(EducationBaseViewModel education)
        {
            //var isValidated = document.Validation();
            //if (isValidated)
            //{
            //    _applicantRepository.AddDocument(document);
            //    _serviceView.Close<DocumentViewModel>();
            //}
        }
        void ExitLogin() => _serviceView.Close<EducationDocViewModel>();
    }
}