using EducationERP.Common.Components.Repositories;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class SettingAdmissionCampaignViewModel : RaketaViewModel
    {
        public RaketaTCommand<ObservableCollection<SettingLevelVM>> OpenWindowAddLevelCommand { get; set; }

        public ObservableCollection<SettingLevelVM> Levels { get; set; } = new();

        IServiceView _serviceView;
        ILevelRepository _levelRepository;
        public SettingAdmissionCampaignViewModel(IServiceView serviceView, ILevelRepository levelRepository)
        {
            _serviceView = serviceView;
            _levelRepository = levelRepository;

            foreach(var level in levelRepository.ReadLevels())
            {
                Levels.Add(new SettingLevelVM
                {
                    Id = level.Id,
                    NameLevel = level.NameLevel,
                    Directions = new()
                });
            }

            OpenWindowAddLevelCommand = RaketaTCommand<ObservableCollection<SettingLevelVM>>.Launch(OpenWindowAddLevel);
        }

        void OpenWindowAddLevel(ObservableCollection<SettingLevelVM> levelVMs) => 
            _serviceView.Window<AddSettingLevelViewModel>(null, levelVMs).Modal();
    }
}