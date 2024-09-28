using EducationERP.Common.Components.Repositories;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class SettingAdmissionCampaignViewModel : RaketaViewModel
    {
        public ObservableCollection<EducationalLevelPreparationVM> Levels { get; set; } = new();

        //public SettingAdmissionCampaignViewModel(ILevelRepository levelRepository)
        //{
        //    Levels.Add(new EducationalLevelPreparationVM()
        //    {
        //        Id = Guid.NewGuid(),
        //        LevelName = "Бакалавриат",
        //        DirectionsTraining = new ObservableCollection<EducationalDirectionTrainingVM>()
        //        {
        //            new EducationalDirectionTrainingVM()
        //            {
        //                Id = Guid.NewGuid(),
        //                DirectionCode = "Код 1",
        //                DirectionName = "Прикладаная информатика",
        //                EducationalProfiles = new ObservableCollection<EducationalProfileVM>()
        //                {
        //                    new EducationalProfileVM()
        //                    {
        //                        Id = Guid.NewGuid(),
        //                        ProfileCode = "Код 2",
        //                        ProfileName = "Экономические системы"
        //                    },
        //                    new EducationalProfileVM()
        //                    {
        //                        Id = Guid.NewGuid(),
        //                        ProfileCode = "Код 2",
        //                        ProfileName = "Неэкономические системы"
        //                    }
        //                }
        //            }
        //        }
        //    });
        //}

        public SettingAdmissionCampaignViewModel(ILevelRepository levelRepository)
        {
            var levels = levelRepository.Read();
        
            foreach (var level in levels)
                Levels.Add(level);
        }
    }
}