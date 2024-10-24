using EducationERP.Common.Components.Repositories;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using Raketa;
using static EducationERP.ViewModels.Modules.DeanRoom.AddEducationGroupViewModel;

namespace EducationERP.ViewModels.Modules.DeanRoom
{
    public class ChangeEducationGroupViewModel : RaketaViewModel
    {
        public GroupTypes[] EnumGroupTypes { get; set; } = (GroupTypes[])Enum.GetValues(typeof(GroupTypes));

        public RaketaTCommand<EducationGroupVM> SaveEducationGroupCommand { get; set; }
        public RaketaCommand ExitCommand { get; }

        IServiceView _serviceView;
        IFacultyRepository _facultyRepository;
        public EducationGroupVM EducationGroupVM { get; set; }
        public ChangeEducationGroupViewModel(IServiceView serviceView, IFacultyRepository facultyRepository, EducationGroupVM educationGroupVM)
        {
            _serviceView = serviceView;
            _facultyRepository = facultyRepository;
            EducationGroupVM = educationGroupVM;

            SaveEducationGroupCommand = RaketaTCommand<EducationGroupVM>.Launch(SaveEducationGroup);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        async void SaveEducationGroup(EducationGroupVM educationGroupVM)
        {
            bool isUpdated = await _facultyRepository.UpdateEducationGroup(educationGroupVM);
            if(isUpdated) CloseWindow();
        }
        void CloseWindow() => _serviceView.Close<ChangeEducationGroupViewModel>();
    }
}