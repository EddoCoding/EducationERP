using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class AddSettingDirectionViewModel : RaketaViewModel
    {
        public SettingDirectionVM DirectionVM { get; set; } = new();

        public RaketaTCommand<string> SelectFormEducationCommand { get; set; }
        public RaketaTCommand<string> SelectFormPaymentCommand { get; set; }
        public RaketaTCommand<SettingDirectionVM> AddDirectionCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ISettingFacultyRepository _facultyRepository;
        SettingLevelVM _levelVM;
        public AddSettingDirectionViewModel(IServiceView serviceView, ISettingFacultyRepository facultyRepository, 
            SettingLevelVM levelVM)
        {
            _serviceView = serviceView;
            _facultyRepository = facultyRepository;
            _levelVM = levelVM;

            SelectFormEducationCommand = RaketaTCommand<string>.Launch(SelectFormEducation);
            SelectFormPaymentCommand = RaketaTCommand<string>.Launch(SelectFormPayment);
            AddDirectionCommand = RaketaTCommand<SettingDirectionVM>.Launch(AddDirection);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        void SelectFormEducation(string nameFormEducation) => DirectionVM.NameFormEducation = nameFormEducation;
        void SelectFormPayment(string nameFormPayment) => DirectionVM.NameFormPayment = nameFormPayment;
        void AddDirection(SettingDirectionVM directionVM)
        {
            var isValidated = directionVM.Validation();
            if (isValidated)
            {
                bool isAdded = _facultyRepository.Create<SettingDirection>(new SettingDirection
                {
                    Id = directionVM.Id,
                    CodeDirection = directionVM.CodeDirection,
                    NameDirection = directionVM.NameDirection,
                    CodeProfile = directionVM.CodeProfile,
                    NameProfile = directionVM.NameProfile,
                    NameFormEducation = directionVM.NameFormEducation,
                    NameFormPayment = directionVM.NameFormPayment,
                    SettingLevelId = _levelVM.Id
                });
                if (isAdded)
                {
                    _levelVM.Directions.Add(directionVM);
                    _levelVM = null;
                    _serviceView.Close<AddSettingDirectionViewModel>();
                }
            }
        }
        void CloseWindow() => _serviceView.Close<AddSettingDirectionViewModel>();
    }
}