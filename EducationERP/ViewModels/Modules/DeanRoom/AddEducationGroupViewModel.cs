using EducationERP.Common.Components;
using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.EducationalInstitution;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using Raketa;

namespace EducationERP.ViewModels.Modules.DeanRoom
{
    public class AddEducationGroupViewModel : RaketaViewModel
    {
        public EducationGroupVM EducationGroupVM { get; set; } = new();
        public GroupTypes[] EnumGroupTypes { get; set; } = (GroupTypes[])Enum.GetValues(typeof(GroupTypes));

        public RaketaTCommand<EducationGroupVM> FormEducationGroupCommand { get; }
        public RaketaCommand ExitCommand { get; }

        IServiceView _serviceView;
        IFacultyRepository _facultyRepository;
        FacultyVM _facultyVM;
        public AddEducationGroupViewModel(IServiceView serviceView, IFacultyRepository facultyRepository, UserSystem userSystem,
            FacultyVM facultyVM)
        {
            _serviceView = serviceView;
            _facultyRepository = facultyRepository;
            EducationGroupVM.Formed = userSystem.FullName;
            _facultyVM = facultyVM;

            FormEducationGroupCommand = RaketaTCommand<EducationGroupVM>.Launch(FormEducationGroup);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        async void FormEducationGroup(EducationGroupVM educationGroupVM)
        {
            bool isValidated = educationGroupVM.Validation();
            if (!isValidated) return;

            var educationGroup = new EducationGroup
            {
                Id = educationGroupVM.Id,
                CodeEducationGroup = educationGroupVM.CodeEducationGroup,
                NameEducationGroup = educationGroupVM.NameEducationGroup,
                LevelGroup = educationGroupVM.LevelGroup,
                FormGroup = educationGroupVM.FormGroup,
                TypeGroup = educationGroupVM.TypeGroup,
                Course = educationGroupVM.Course,
                MaxNumberStudents = educationGroupVM.MaxNumberStudents,
                CodeDirection = educationGroupVM.CodeDirection,
                NameDirection = educationGroupVM.NameDirection,
                CodeProfile = educationGroupVM.CodeProfile,
                NameProfile = educationGroupVM.NameProfile,
                NameCuratorGroup = educationGroupVM.NameCuratorGroup,
                NameHeadmanGroup = educationGroupVM.NameHeadmanGroup,
                Formed = educationGroupVM.Formed,
                DateOfFormed = educationGroupVM.DateOfFormed,
                FacultyId = _facultyVM.Id
            };

            bool isAdded = await _facultyRepository.CreateEducationGroup(educationGroup);
            if (isAdded)
            {
                _facultyVM.EducationGroups.Add(educationGroupVM);
                CloseWindow();
            }
        }
        void CloseWindow() => _serviceView.Close<AddEducationGroupViewModel>();

        public enum GroupTypes
        {
            Общая,
            Бюджетная,
            Платная
        }
    }
}