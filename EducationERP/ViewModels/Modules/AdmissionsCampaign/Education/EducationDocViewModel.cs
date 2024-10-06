using EducationERP.Common.Components.Repositories;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Education
{
    public class EducationDocViewModel : RaketaViewModel
    {
        ObservableCollection<EducationBaseViewModel> _educations;

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
        public EducationDocViewModel(IServiceView serviceView, ObservableCollection<EducationBaseViewModel> educations)
        {
            _serviceView = serviceView;
            _educations = educations;

            AddEducationCommand = RaketaTCommand<EducationBaseViewModel>.Launch(AddEducation);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        void AddEducation(EducationBaseViewModel education)
        {
            var isValidated = education.Validation();
            if (isValidated)
            {
                _educations.Add(education);
                _educations = null;
                _serviceView.Close<EducationDocViewModel>();
            }
        }
        void CloseWindow() => _serviceView.Close<EducationDocViewModel>();
    }
}