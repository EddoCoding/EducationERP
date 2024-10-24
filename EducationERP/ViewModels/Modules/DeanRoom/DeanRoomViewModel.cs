using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using Raketa;

namespace EducationERP.ViewModels.Modules.DeanRoom
{
    public class DeanRoomViewModel : RaketaViewModel
    {
        FacultyVM _facultyVM;
        EducationGroupVM _selectedEducationGroup;

        public FacultyVM FacultyVM
        {
            get => _facultyVM;
            set => SetValue(ref _facultyVM, value);
        }
        public EducationGroupVM SelectedEducationGroup
        {
            get => _selectedEducationGroup;
            set => SetValue(ref _selectedEducationGroup, value);
        }

        public RaketaTCommand<FacultyVM> OpenWindowAddEducationGroupCommand { get; }
        public RaketaTCommand<EducationGroupVM> OpenWindowChangeEducationGroupCommand { get; }
        public RaketaTCommand<EducationGroupVM> DeleteEducationGroupCommand { get; }
        public RaketaCommand ExitCommand { get; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        IFacultyRepository _facultyRepository;
        Guid _id;
        public DeanRoomViewModel(IServiceView serviceView, ITabControl tabControl, IFacultyRepository facultyRepository, Guid id)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;
            _facultyRepository = facultyRepository;

            GetFaculty(id);

            OpenWindowAddEducationGroupCommand = RaketaTCommand<FacultyVM>.Launch(OpenWindowAddEducationGroup);
            OpenWindowChangeEducationGroupCommand = RaketaTCommand<EducationGroupVM>.Launch(OpenWindowChangeEducationGroup);
            DeleteEducationGroupCommand = RaketaTCommand<EducationGroupVM>.Launch(DeleteEducationGroup);
            ExitCommand = RaketaCommand.Launch(CloseTab);
        }

        void OpenWindowAddEducationGroup(FacultyVM facultyVM) =>
            _serviceView.Window<AddEducationGroupViewModel>(null, facultyVM).Modal();
        void OpenWindowChangeEducationGroup(EducationGroupVM educationGroupVM)
        {
            if (educationGroupVM == null) return;
            _serviceView.Window<ChangeEducationGroupViewModel>(null, educationGroupVM).Modal();
        }

        async void DeleteEducationGroup(EducationGroupVM educationGroupVM)
        {
            if (educationGroupVM == null) return;

            bool isDeleted = await _facultyRepository.DeleteEducationGroup(educationGroupVM.Id);
            if (isDeleted) FacultyVM.EducationGroups.Remove(educationGroupVM);
        }

        void GetFaculty(Guid id)
        {
            var faculty = _facultyRepository.GetFacultyById(id);
            if (faculty == null) return;

            FacultyVM = new FacultyVM
            {
                Id = faculty.Id,
                NameFaculty = faculty.NameFaculty,
                PasswordFaculty = faculty.PasswordFaculty,
                EducationGroups = new()
            };
            foreach(var educationGroup in faculty.EducationGroups)
            {
                var educationGroupVM = new EducationGroupVM
                {
                    Id = educationGroup.Id,
                    CodeEducationGroup = educationGroup.CodeEducationGroup,
                    NameEducationGroup = educationGroup.NameEducationGroup,
                    LevelGroup = educationGroup.LevelGroup,
                    FormGroup = educationGroup.FormGroup,
                    TypeGroup = educationGroup.TypeGroup,
                    Course = educationGroup.Course,
                    MaxNumberStudents = educationGroup.MaxNumberStudents,
                    CodeDirection = educationGroup.CodeDirection,
                    NameDirection = educationGroup.NameDirection,
                    CodeProfile = educationGroup.CodeProfile,
                    NameProfile = educationGroup.NameProfile,
                    NameCuratorGroup = educationGroup.NameCuratorGroup,
                    NameHeadmanGroup = educationGroup.NameHeadmanGroup,
                    Formed = educationGroup.Formed,
                    DateOfFormed = educationGroup.DateOfFormed,
                    Students = new()
                };
                FacultyVM.EducationGroups.Add(educationGroupVM);
            }
        }
        void CloseTab() => _tabControl.RemoveTab();
    }
}
// SEcuHso2
// COnSvjBu