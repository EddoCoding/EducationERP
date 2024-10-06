using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class AddSettingLevelViewModel : RaketaViewModel
    {
        public SettingLevelVM LevelVM { get; set; } = new();

        public RaketaTCommand<SettingLevelVM> AddLevelCommand { get; set; }
        public RaketaTCommand<string> SelectLevelCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ISettingFacultyRepository _facultyRepository;
        SettingFacultyVM _facultyVM;
        public AddSettingLevelViewModel(IServiceView serviceView, ISettingFacultyRepository facultyRepository, SettingFacultyVM facultyVM)
        {
            _serviceView = serviceView;
            _facultyRepository = facultyRepository;
            _facultyVM = facultyVM;

            AddLevelCommand = RaketaTCommand<SettingLevelVM>.Launch(AddLevel);
            SelectLevelCommand = RaketaTCommand<string>.Launch(SelectLevel);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        void AddLevel(SettingLevelVM levelVM)
        {
            var isValidated = levelVM.Validation();
            if (isValidated)
            {
                bool isAdded = _facultyRepository.Create<SettingLevel>(new SettingLevel
                {
                    Id = levelVM.Id,
                    NameLevel = levelVM.NameLevel,
                    SettingFacultyId = _facultyVM.Id
                });
                if (isAdded)
                {
                    _facultyVM.Levels.Add(levelVM);
                    _facultyVM = null;
                    _serviceView.Close<AddSettingLevelViewModel>();
                }
            }
        }
        void SelectLevel(string nameLevel) => LevelVM.NameLevel = nameLevel;

        void CloseWindow() => _serviceView.Close<AddSettingLevelViewModel>();
    }
}