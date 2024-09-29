using EducationERP.Common.Components.Repositories;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class SettingAdmissionCampaignViewModel : RaketaViewModel
    {
        public ObservableCollection<EducationalLevelPreparationVM> Levels { get; set; } = new();

        public RaketaTCommand<EducationalLevelPreparationVM> DeleteLevelCommand { get; set; }
        public RaketaTCommand<EducationalLevelPreparationVM> OpenWindowAddDirectionCommand { get; set; }

        IServiceView _serviceView;
        ILevelRepository _levelRepository;
        public SettingAdmissionCampaignViewModel(IServiceView serviceView, ILevelRepository levelRepository)
        {
            _serviceView = serviceView;
            _levelRepository = levelRepository;

            var levels = levelRepository.ReadLevels();
            var levelVMs = levels.Select(levelVM => new EducationalLevelPreparationVM
            {
                Id = levelVM.Id,
                LevelName = levelVM.LevelName,
                DirectionsTraining = levelVM.DirectionsTraining.Select(directionVM => new EducationalDirectionTrainingVM
                {
                    Id = directionVM.Id,
                    DirectionCode = directionVM.DirectionCode,
                    DirectionName = directionVM.DirectionName,
                    EducationalProfiles = directionVM.EducationalProfiles.Select(profileVM => new EducationalProfileVM
                    {
                        Id = profileVM.Id,
                        ProfileCode = profileVM.ProfileCode,
                        ProfileName = profileVM.ProfileName,
                        FormsOfTraining = profileVM.FormsOfTraining.Select(formVM => new EducationalFormOfTrainingVM
                        {
                            Id = formVM.Id,
                            FormName = formVM.FormName
                        }).ToList()
                    }).ToList()
                }).ToList()
            }).ToList();

            foreach (var level in levelVMs)
                Levels.Add(level);

            DeleteLevelCommand = RaketaTCommand<EducationalLevelPreparationVM>.Launch(DeleteLevel);
            OpenWindowAddDirectionCommand = RaketaTCommand<EducationalLevelPreparationVM>.Launch(OpenWindowAddDirection);
        }

        void DeleteLevel(EducationalLevelPreparationVM levelVM)
        {
            _levelRepository.DeleteLevel(levelVM.Id);

            Levels.Remove(levelVM);
            levelVM = null;
        }
        void OpenWindowAddDirection(EducationalLevelPreparationVM level) => 
            _serviceView.Window<AddSettingDirectionViewModel>(null, level).NonModal();
    }
}