using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Common.ToolsDev;
using EducationERP.Models.Modules.EducationalInstitution;
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

        #region Блок команд групп
        public RaketaTCommand<FacultyVM> OpenWindowAddEducationGroupCommand { get; }
        public RaketaTCommand<EducationGroupVM> OpenWindowChangeEducationGroupCommand { get; }
        public RaketaTCommand<EducationGroupVM> DeleteEducationGroupCommand { get; }

        public RaketaCommand ShowScheduleCommand { get; }
        public RaketaCommand ShowVisitorLogCommand { get; }
        public RaketaCommand ShowSyllabusCommand { get; }
        #endregion
        #region Блок команд студентов
        public RaketaTCommand<EducationGroupVM> OpenWindowAddStudentCommand { get; }

        #endregion

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
            ShowScheduleCommand = RaketaCommand.Launch(ShowSchedule);
            ShowVisitorLogCommand = RaketaCommand.Launch(ShowVisitorLog);
            ShowSyllabusCommand = RaketaCommand.Launch(ShowSyllabus);

            OpenWindowAddStudentCommand = RaketaTCommand<EducationGroupVM>.Launch(OpenWindowAddStudent);

            ExitCommand = RaketaCommand.Launch(CloseTab);
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
                foreach(var student in educationGroup.Students)
                {
                    var studentVM = new StudentVM
                    {
                        Id = student.Id,
                        SurName = student.SurName,
                        Name = student.Name,
                        MiddleName = student.MiddleName,
                        DateOfBirth = student.DateOfBirth,
                        Gender = student.Gender,
                        PlaceOfBirth = student.PlaceOfBirth,
                        Citizenship = student.Citizenship,
                        CitizenshipValidFrom = student.CitizenshipValidFrom,
                        IsNeedHostel = student.IsNeedHostel,
                        IsNotNeedHostel = student.IsNotNeedHostel,

                        ResidentialAddress = student.ResidentialAddress,
                        AddressOfRegistration = student.AddressOfRegistration,
                        HomePhone = student.HomePhone,
                        MobilePhone = student.MobilePhone,
                        Mail = student.Mail,
                        AdditionalContactInformation = student.AdditionalContactInformation,
                        Accepted = student.Accepted,

                        NameEducationGroup = student.NameEducationGroup,
                        LevelGroup = student.LevelGroup,
                        FormGroup = student.FormGroup,
                        TypeGroup = student.TypeGroup,
                        Course = student.Course,
                        CodeDirection = student.CodeDirection,
                        NameDirection = student.NameDirection,
                        CodeProfile = student.CodeProfile,
                        NameProfile = student.NameProfile,

                        Documents = new()
                    };
                    educationGroupVM.Students.Add(studentVM);
                }
                FacultyVM.EducationGroups.Add(educationGroupVM);
            }
        }

        #region Блок методов для групп
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
        void ShowSchedule() => Dev.NotReady("Расписание");
        void ShowVisitorLog() => Dev.NotReady("Журнал посещаемости");
        void ShowSyllabus() => Dev.NotReady("Учебный план");

        #endregion
        #region Блок методов для студентов
        void OpenWindowAddStudent(EducationGroupVM educationGroupVM)
        {
            if (educationGroupVM == null) return;

            _tabControl.CreateTab<AddStudentViewModel>("Добавление студента", null, educationGroupVM);
        }
        #endregion

        void CloseTab() => _tabControl.RemoveTab();
    }
}
// SEcuHso2
// COnSvjBu