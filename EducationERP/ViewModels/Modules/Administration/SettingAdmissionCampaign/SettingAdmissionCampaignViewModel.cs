using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.Administration;
using EducationERP.Models;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class SettingAdmissionCampaignViewModel : RaketaViewModel
    {
        public ObservableCollection<EducationalLevelPreparationVM> Levels { get; set; } = new();

        public RaketaTCommand<EducationalLevelPreparationVM> DeleteLevelCommand { get; set; }

        ILevelRepository _levelRepository;
        public SettingAdmissionCampaignViewModel(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;

            var levels = levelRepository.Read();

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
        }

        void DeleteLevel(EducationalLevelPreparationVM levelVM)
        {
            _levelRepository.Delete(levelVM.Id);

            Levels.Remove(levelVM);
            levelVM = null;
        }
    }
}