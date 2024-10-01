using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class AddSettingDirectionViewModel : RaketaViewModel
    {
        public SettingDirectionVM DirectionVM { get; set; } = new();

        public RaketaTCommand<SettingDirectionVM> AddDirectionCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ILevelRepository _levelRepository;
        SettingLevelVM _levelVM;
        public AddSettingDirectionViewModel(IServiceView serviceView, ILevelRepository levelRepository, SettingLevelVM levelVM)
        {
            _serviceView = serviceView;
            _levelRepository = levelRepository;
            _levelVM = levelVM;

            AddDirectionCommand = RaketaTCommand<SettingDirectionVM>.Launch(AddDirection);
            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        void AddDirection(SettingDirectionVM directionVM)
        {
            var direction = new SettingDirection
            {
                Id = directionVM.Id,
                CodeDirection = directionVM.CodeDirection,
                NameDirection = directionVM.NameDirection,
                SettingLevelId = _levelVM.Id
            };
            bool isAdded = _levelRepository.CreateDirection(direction);
            if(isAdded)
            {
                _levelVM.Directions.Add(directionVM);
                _serviceView.Close<AddSettingDirectionViewModel>();
            }
        }
        void ExitLogin() => _serviceView.Close<AddSettingDirectionViewModel>();
    }
}