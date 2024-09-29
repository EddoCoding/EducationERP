using EducationERP.Common.Components.Repositories;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class AddSettingDirectionViewModel : RaketaViewModel
    {
        public EducationalDirectionTrainingVM Direction { get; set; } = new();

        public RaketaTCommand<EducationalDirectionTrainingVM> AddDirectionCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ILevelRepository _levelRepository;
        EducationalLevelPreparationVM _level;
        public AddSettingDirectionViewModel(IServiceView serviceView, ILevelRepository levelRepository, EducationalLevelPreparationVM level)
        {
            _serviceView = serviceView;
            _levelRepository = levelRepository;
            _level = level;

            AddDirectionCommand = RaketaTCommand<EducationalDirectionTrainingVM>.Launch(AddDirection);
            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        async Task AddDirection(EducationalDirectionTrainingVM direction)
        {
            

            //var isAdded = await _repository.Create(new EducationalLevelPreparation
            //{
            //    Id = levelVM.Id,
            //    LevelName = levelVM.LevelName
            //});
            //
            //if (isAdded)
            //{
            //    _levels.Add(levelVM);
            //    _serviceView.Close<AddSettingLevelViewModel>();
            //}
        }
        void ExitLogin() => _serviceView.Close<AddSettingDirectionViewModel>();
    }
}