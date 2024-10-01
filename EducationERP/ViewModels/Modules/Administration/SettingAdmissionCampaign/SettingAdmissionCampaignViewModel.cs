using EducationERP.Common.Components.Repositories;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class SettingAdmissionCampaignViewModel : RaketaViewModel
    {
        public RaketaTCommand<ObservableCollection<SettingLevelVM>> OpenWindowAddLevelCommand { get; set; }
        public RaketaTCommand<SettingLevelVM> DeleteLevelCommand { get; set; }
        public RaketaTCommand<SettingLevelVM> OpenWindowAddDirectionCommand { get; set; }
        public RaketaTCommand<SettingDirectionVM> DeleteDirectionCommand { get; set; }
        public RaketaTCommand<SettingDirectionVM> OpenWindowAddProfileCommand { get; set; }
        public RaketaTCommand<SettingProfileVM> DeleteProfileCommand { get; set; }
        public RaketaTCommand<SettingProfileVM> OpenWindowAddFormCommand { get; set; }
        public RaketaTCommand<SettingFormVM> DeleteFormCommand { get; set; }

        public ObservableCollection<SettingLevelVM> Levels { get; set; } = new();

        IServiceView _serviceView;
        ILevelRepository _levelRepository;
        public SettingAdmissionCampaignViewModel(IServiceView serviceView, ILevelRepository levelRepository)
        {
            _serviceView = serviceView;
            _levelRepository = levelRepository;

            foreach(var level in levelRepository.ReadLevels())
            {
                var levelVM = new SettingLevelVM
                {
                    Id = level.Id,
                    NameLevel = level.NameLevel,
                    Directions = new()
                };
                foreach (var direction in level.Directions) 
                {
                    var directionVM = new SettingDirectionVM
                    {
                        Id = direction.Id,
                        CodeDirection = direction.CodeDirection,
                        NameDirection = direction.NameDirection,
                        Profiles = new()
                    };
                    foreach(var profile in direction.Profiles)
                    {
                        var profileVM = new SettingProfileVM
                        {
                            Id = profile.Id,
                            CodeProfile = profile.CodeProfile,
                            NameProfile = profile.NameProfile,
                            Forms = new()
                        };
                        foreach(var form in profile.Forms)
                        {
                            var formVM = new SettingFormVM
                            {
                                Id = form.Id,
                                NameForm = form.NameForm
                            };
                            profileVM.Forms.Add(formVM);
                        }
                        directionVM.Profiles.Add(profileVM);
                    }
                    levelVM.Directions.Add(directionVM);
                }
                Levels.Add(levelVM);
            }

            OpenWindowAddLevelCommand = RaketaTCommand<ObservableCollection<SettingLevelVM>>.Launch(OpenWindowAddLevel);
            DeleteLevelCommand = RaketaTCommand<SettingLevelVM>.Launch(DeleteLevel);
            OpenWindowAddDirectionCommand = RaketaTCommand<SettingLevelVM>.Launch(OpenWindowAddDirection);
            DeleteDirectionCommand = RaketaTCommand<SettingDirectionVM>.Launch(DeleteDirection);
            OpenWindowAddProfileCommand = RaketaTCommand<SettingDirectionVM>.Launch(OpenWindowAddProfile);
            DeleteProfileCommand = RaketaTCommand<SettingProfileVM>.Launch(DeleteProfile);
            OpenWindowAddFormCommand = RaketaTCommand<SettingProfileVM>.Launch(OpenWindowAddForm);
            DeleteFormCommand = RaketaTCommand<SettingFormVM>.Launch(DeleteForm);
        }

        void OpenWindowAddLevel(ObservableCollection<SettingLevelVM> levelVMs) => 
            _serviceView.Window<AddSettingLevelViewModel>(null, levelVMs).Modal();
        void DeleteLevel(SettingLevelVM levelVM)
        {
            bool isDeleted = _levelRepository.DeleteLevel(levelVM.Id);
            if (isDeleted) Levels.Remove(levelVM);
        }
        void OpenWindowAddDirection(SettingLevelVM levelVM) =>
            _serviceView.Window<AddSettingDirectionViewModel>(null, levelVM).Modal();
        void DeleteDirection(SettingDirectionVM directionVM)
        {
            bool isDeleted = _levelRepository.DeleteDirection(directionVM.Id);
            if (isDeleted)
            {
                foreach (var level in Levels)
                    foreach (var direction in level.Directions)
                        if (direction.Id == directionVM.Id)
                        {
                            level.Directions.Remove(directionVM);
                            return;
                        }
            }
        }
        void OpenWindowAddProfile(SettingDirectionVM directionVM) =>
            _serviceView.Window<AddSettingProfileViewModel>(null, directionVM).Modal();
        void DeleteProfile(SettingProfileVM profileVM)
        {
            bool isDeleted = _levelRepository.DeleteProfile(profileVM.Id);
            if (isDeleted)
            {
                foreach (var level in Levels)
                    foreach (var direction in level.Directions)
                        foreach (var profile in direction.Profiles)
                            if (profile.Id == profileVM.Id)
                            {
                                direction.Profiles.Remove(profileVM);
                                return;
                            }
            }
        }
        void OpenWindowAddForm(SettingProfileVM profileVM) =>
            _serviceView.Window<AddSettingFormViewModel>(null, profileVM).Modal();
        void DeleteForm(SettingFormVM formVM)
        {
            bool isDeleted = _levelRepository.DeleteForm(formVM.Id);
            if (isDeleted)
            {
                foreach (var level in Levels)
                    foreach (var direction in level.Directions)
                        foreach (var profile in direction.Profiles)
                            foreach (var form in profile.Forms)
                                if (form.Id == formVM.Id)
                                {
                                    profile.Forms.Remove(formVM);
                                    return;
                                }
            }
        }
    }
}