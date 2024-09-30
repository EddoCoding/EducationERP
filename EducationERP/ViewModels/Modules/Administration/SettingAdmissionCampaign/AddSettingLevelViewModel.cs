using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class AddSettingLevelViewModel : RaketaViewModel
    {
        public SettingLevelVM LevelVM { get; set; } = new();

        public RaketaTCommand<string> SelectLevelCommand { get; set; }
        public RaketaTCommand<SettingLevelVM> AddLevelCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ILevelRepository _repository;
        ObservableCollection<SettingLevelVM> _levelVMs;
        public AddSettingLevelViewModel(IServiceView serviceView, ILevelRepository repository, ObservableCollection<SettingLevelVM> levelVMs)
        {
            _serviceView = serviceView;
            _repository = repository;
            _levelVMs = levelVMs;

            SelectLevelCommand = RaketaTCommand<string>.Launch(SelectLevel);
            AddLevelCommand = RaketaTCommand<SettingLevelVM>.Launch(AddLevel);
            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        void SelectLevel(string level) => LevelVM.NameLevel = level;
        void AddLevel(SettingLevelVM levelVM)
        {
            var level = new SettingLevel
            {
                Id = levelVM.Id,
                NameLevel = levelVM.NameLevel
            };
            _repository.CreateLevel(level);

            _levelVMs.Add(levelVM);
            _serviceView.Close<AddSettingLevelViewModel>();

            //var isAdded = await _repository.CreateLevel(new EducationalLevelPreparation
            //{
            //    Id = levelVM.Id,
            //    LevelName = levelVM.LevelName
            //});
            //
            //if(isAdded)
            //{
            //    _levels.Add(levelVM);
            //    _serviceView.Close<AddSettingLevelViewModel>();
            //}
        }
        void ExitLogin() => _serviceView.Close<AddSettingLevelViewModel>();
    }
}