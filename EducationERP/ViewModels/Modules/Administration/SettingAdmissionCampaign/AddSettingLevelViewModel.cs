using EducationERP.Common.Components.Repositories;
using EducationERP.Models;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class AddSettingLevelViewModel : RaketaViewModel
    {
        public EducationalLevelPreparationVM Level { get; set; } = new();
        ObservableCollection<EducationalLevelPreparationVM> _levels;

        public RaketaTCommand<EducationalLevelPreparationVM> AddLevelCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ILevelRepository _repository;
        public AddSettingLevelViewModel(IServiceView serviceView, ILevelRepository repository, ObservableCollection<EducationalLevelPreparationVM> levels)
        {
            _serviceView = serviceView;
            _repository = repository;
            _levels = levels;

            AddLevelCommand = RaketaTCommand<EducationalLevelPreparationVM>.Launch(AddLevel);
            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        async Task AddLevel(EducationalLevelPreparationVM levelVM)
        {
            var isAdded = await _repository.Create(new EducationalLevelPreparation
            {
                Id = levelVM.Id,
                LevelName = levelVM.LevelName
            });

            if(isAdded)
            {
                _levels.Add(levelVM);
                _serviceView.Close<AddSettingLevelViewModel>();
            }
        }
        void ExitLogin() => _serviceView.Close<AddSettingLevelViewModel>();
    }
}