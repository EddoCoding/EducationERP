using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class AddSettingProfileViewModel : RaketaViewModel
    {
        public SettingProfileVM ProfileVM { get; set; } = new();

        public RaketaTCommand<SettingProfileVM> AddProfileCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ILevelRepository _levelRepository;
        SettingDirectionVM _directionVM;
        public AddSettingProfileViewModel(IServiceView serviceView, ILevelRepository levelRepository, SettingDirectionVM directionVM)
        {
            _serviceView = serviceView;
            _levelRepository = levelRepository;
            _directionVM = directionVM;

            AddProfileCommand = RaketaTCommand<SettingProfileVM>.Launch(AddProfile);
            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        void AddProfile(SettingProfileVM profileVM)
        {
            var profile = new SettingProfile
            {
                Id = profileVM.Id,
                CodeProfile = profileVM.CodeProfile,
                NameProfile = profileVM.NameProfile,
                SettingDirectionId = _directionVM.Id
            };
            bool isAdded = _levelRepository.CreateProfile(profile);
            if (isAdded)
            {
                _directionVM.Profiles.Add(profileVM);
                _serviceView.Close<AddSettingProfileViewModel>();
            }
        }
        void ExitLogin() => _serviceView.Close<AddSettingProfileViewModel>();
    }
}