using Raketa;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Education
{
    public class ChangeEducationDocViewModel : RaketaViewModel
    {
        public EducationBaseViewModel Education { get; set; }

        public RaketaTCommand<EducationBaseViewModel> SaveEducationCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        public ChangeEducationDocViewModel(IServiceView serviceView, EducationBaseViewModel education)
        {
            _serviceView = serviceView;

            Education = education;

            SaveEducationCommand = RaketaTCommand<EducationBaseViewModel>.Launch(SaveEducation);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        void SaveEducation(EducationBaseViewModel education)
        {
            var isValidated = education.Validation();
            if (isValidated) CloseWindow();
        }
        void CloseWindow() => _serviceView.Close<ChangeEducationDocViewModel>();
    }
}