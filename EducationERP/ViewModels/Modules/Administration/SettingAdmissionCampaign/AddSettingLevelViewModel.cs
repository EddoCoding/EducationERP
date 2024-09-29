using EducationERP.Common.Components;
using EducationERP.Common.Components.Repositories;
using EducationERP.Models;
using EducationERP.Models.Modules.Administration;
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
            //var isAdded = await _repository.Create(new EducationalLevelPreparation
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

            using(var db = new DataContext())
            {
                var level = new EducationalLevelPreparation
                {
                    Id = levelVM.Id,
                    LevelName = levelVM.LevelName
                };
                db.SettingLevels.Add(level);
                await db.SaveChangesAsync();
            
                var direction = new EducationalDirectionTraining
                {
                    Id = Guid.NewGuid(),
                    DirectionCode = "Код 2",
                    DirectionName = "Юриспруденция",
                    EducationalLevelPreparationId = level.Id,
                    EducationalLevelPreparation = level
                };
                db.SettingDirections.Add(direction);
                await db.SaveChangesAsync();
           
                var profile = new EducationalProfile
                {
                    Id = Guid.NewGuid(),
                    ProfileCode = "Код 3",
                    ProfileName = "Неэкономическая система",
                    EducationalDirectionTrainingId = direction.Id,
                    EducationalDirectionTraining = direction
                };
                db.SettingProfiles.AddRange(profile);
                await db.SaveChangesAsync();

                var form = new EducationalFormOfTraining
                {
                    Id = Guid.NewGuid(),
                    FormName = "Заочная",
                    EducationalProfileId = profile.Id,
                    EducationalProfile = profile
                };
                var form1 = new EducationalFormOfTraining
                {
                    Id = Guid.NewGuid(),
                    FormName = "Очно-Заочная",
                    EducationalProfileId = profile.Id,
                    EducationalProfile = profile
                };
                var form2 = new EducationalFormOfTraining
                {
                    Id = Guid.NewGuid(),
                    FormName = "Очная",
                    EducationalProfileId = profile.Id,
                    EducationalProfile = profile
                };
                db.SettingForms.AddRange(form, form1, form2);
                await db.SaveChangesAsync();

                _levels.Add(levelVM);
                _serviceView.Close<AddSettingLevelViewModel>();
            }
        }
        void ExitLogin() => _serviceView.Close<AddSettingLevelViewModel>();
    }
}