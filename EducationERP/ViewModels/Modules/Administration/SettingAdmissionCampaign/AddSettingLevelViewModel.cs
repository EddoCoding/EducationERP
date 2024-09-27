using EducationERP.Common.Components;
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
        DataContext _dataContext;
        public AddSettingLevelViewModel(IServiceView serviceView, DataContext dataContext, ObservableCollection<EducationalLevelPreparationVM> levels)
        {
            _serviceView = serviceView;
            _dataContext = dataContext;
            _levels = levels;

            AddLevelCommand = RaketaTCommand<EducationalLevelPreparationVM>.Launch(AddLevel);
            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        void AddLevel(EducationalLevelPreparationVM level)
        {
            var levelModel = new EducationalLevelPreparation
            {
                Id = level.Id,
                LevelName = level.LevelName
            };
            _dataContext.SettingLevels.Add(levelModel);
            _dataContext.SaveChanges();

            _levels.Add(level);
            _serviceView.Close<AddSettingLevelViewModel>();
        }
        void ExitLogin() => _serviceView.Close<AddSettingLevelViewModel>();
    }
}