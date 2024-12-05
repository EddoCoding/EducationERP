using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Common.ToolsDev;
using EducationERP.Models.Modules.DeanRoom.DocumentsStudent;
using EducationERP.Models.Modules.EducationalInstitution;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using EducationERP.ViewModels.Modules.DeanRoom.DocumentsStudent;
using Raketa;

namespace EducationERP.ViewModels.Modules.DeanRoom
{
    public class DeanRoomViewModel : RaketaViewModel
    {
        FacultyVM _facultyVM;
        EducationGroupVM _selectedEducationGroup;
        StudentVM _selectedStudent;

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
        public StudentVM SelectedStudent
        {
            get => _selectedStudent;
            set => SetValue(ref _selectedStudent, value);
        }

        #region Блок команд групп
        public RaketaCommand UpdateGroupsCommand { get; }

        public RaketaCommand ShowScheduleCommand { get; }
        public RaketaCommand ShowVisitorLogCommand { get; }
        public RaketaCommand ShowSyllabusCommand { get; }

        public RaketaTCommand<FacultyVM> OpenWindowAddEducationGroupCommand { get; }
        public RaketaTCommand<EducationGroupVM> OpenWindowChangeEducationGroupCommand { get; }
        public RaketaTCommand<EducationGroupVM> DeleteEducationGroupCommand { get; }

        #endregion
        #region Блок команд студентов
        public RaketaTCommand<EducationGroupVM> UpdateStudentsCommand { get; }
        public RaketaTCommand<StudentVM> ShowProfileStudentCommand { get; }

        public RaketaTCommand<EducationGroupVM> OpenWindowAddStudentCommand { get; }
        public RaketaTCommand<StudentVM> ChangeStudentCommand { get; }
        public RaketaTCommand<StudentVM> DeleteStudentCommand { get; }
        #endregion

        public RaketaCommand ExitCommand { get; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        IFacultyRepository _facultyRepository;
        IEducationGroupRepository _educationGroupRepository;
        Guid _id;
        public DeanRoomViewModel(IServiceView serviceView, ITabControl tabControl, IFacultyRepository facultyRepository, 
            IEducationGroupRepository educationGroupRepository, Guid id)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;
            _facultyRepository = facultyRepository;
            _educationGroupRepository = educationGroupRepository;
            _id = id;

            GetFaculty(id);

            ExitCommand = RaketaCommand.Launch(CloseTab);

            #region Блок инициализации команд групп
            UpdateGroupsCommand = RaketaCommand.Launch(UpdateGroup);
            ShowScheduleCommand = RaketaCommand.Launch(ShowSchedule);
            ShowVisitorLogCommand = RaketaCommand.Launch(ShowVisitorLog);
            ShowSyllabusCommand = RaketaCommand.Launch(ShowSyllabus);

            OpenWindowAddEducationGroupCommand = RaketaTCommand<FacultyVM>.Launch(OpenWindowAddEducationGroup);
            OpenWindowChangeEducationGroupCommand = RaketaTCommand<EducationGroupVM>.Launch(OpenWindowChangeEducationGroup);
            DeleteEducationGroupCommand = RaketaTCommand<EducationGroupVM>.Launch(DeleteEducationGroup);
            #endregion
            #region Блок инициализации команд студентов
            UpdateStudentsCommand = RaketaTCommand<EducationGroupVM>.Launch(UpdateStudents);
            ShowProfileStudentCommand = RaketaTCommand<StudentVM>.Launch(ShowProfileStudent);

            OpenWindowAddStudentCommand = RaketaTCommand<EducationGroupVM>.Launch(OpenWindowAddStudent);
            ChangeStudentCommand = RaketaTCommand<StudentVM>.Launch(ChangeStudent);
            DeleteStudentCommand = RaketaTCommand<StudentVM>.Launch(DeleteStudent);
            #endregion
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
                    foreach(var document in student.Documents)
                    {
                        if(document is PassportStudent passportStudent)
                        {
                            var passportStudentVM = new PassportStudentVM
                            {
                                Id = passportStudent.Id,
                                TypeDocument = passportStudent.TypeDocument,
                                SurName = passportStudent.SurName,
                                Name = passportStudent.Name,
                                MiddleName = passportStudent.MiddleName,
                                DateOfBirth = passportStudent.DateOfBirth,
                                Gender = passportStudent.Gender,
                                PlaceOfBirth = passportStudent.PlaceOfBirth,
                                IssuedBy = passportStudent.IssuedBy,
                                DateOfIssue = passportStudent.DateOfIssue,
                                DepartmentCode = passportStudent.DepartmentCode,
                                SeriesNumber = passportStudent.SeriesNumber,
                                AdditionalInformation = passportStudent.AdditionalInformation
                            };
                            studentVM.Documents.Add(passportStudentVM);
                        }
                        else if (document is SnilsStudent snilsStudent)
                        {
                            var snilsStudentVM = new SnilsStudentVM
                            {
                                Id = snilsStudent.Id,
                                TypeDocument = snilsStudent.TypeDocument,
                                SurName = snilsStudent.SurName,
                                Name = snilsStudent.Name,
                                MiddleName = snilsStudent.MiddleName,
                                DateOfBirth = snilsStudent.DateOfBirth,
                                Gender = snilsStudent.Gender,
                                PlaceOfBirth = snilsStudent.PlaceOfBirth,
                                Number = snilsStudent.Number,
                                RegistrationDate = snilsStudent.RegistrationDate,
                                AdditionalInformation = snilsStudent.AdditionalInformation
                            };
                            studentVM.Documents.Add(snilsStudentVM);
                        }
                        else if (document is InnStudent innStudent)
                        {
                            var innStudentVM = new InnStudentVM
                            {
                                Id = innStudent.Id,
                                TypeDocument = innStudent.TypeDocument,
                                SurName = innStudent.SurName,
                                Name = innStudent.Name,
                                MiddleName = innStudent.MiddleName,
                                DateOfBirth = innStudent.DateOfBirth,
                                Gender = innStudent.Gender,
                                PlaceOfBirth = innStudent.PlaceOfBirth,
                                NumberINN = innStudent.NumberINN,
                                SeriesNumber = innStudent.SeriesNumber,
                                DateAssigned = innStudent.DateAssigned,
                                AdditionalInformation = innStudent.AdditionalInformation
                            };
                            studentVM.Documents.Add(innStudentVM);
                        }
                        else if (document is ForeignPassportStudent fpStudent)
                        {
                            var fpStudentVM = new ForeignPassportStudentVM
                            {
                                Id = fpStudent.Id,
                                TypeDocument = fpStudent.TypeDocument,
                                SurName = fpStudent.SurName,
                                Name = fpStudent.Name,
                                MiddleName = fpStudent.MiddleName,
                                DateOfBirth = fpStudent.DateOfBirth,
                                Gender = fpStudent.Gender,
                                PlaceOfBirth = fpStudent.PlaceOfBirth,
                                IssuedBy = fpStudent.IssuedBy,
                                DateOfIssue = fpStudent.DateOfIssue,
                                SeriesNumber = fpStudent.SeriesNumber,
                                AdditionalInformation = fpStudent.AdditionalInformation
                            };
                            studentVM.Documents.Add(fpStudentVM);
                        }
                    }
                    educationGroupVM.Students.Add(studentVM);
                }
                FacultyVM.EducationGroups.Add(educationGroupVM);
            }
        }

        #region Блок методов для групп
        async void UpdateGroup()
        {
            var groups = await _facultyRepository.GetGroups(_id);
            FacultyVM.EducationGroups.Clear();
            foreach (var educationGroup in groups)
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
                foreach (var student in educationGroup.Students)
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
        void ShowSchedule() => Dev.NotReady("Расписание");
        void ShowVisitorLog() => Dev.NotReady("Журнал посещаемости");
        void ShowSyllabus() => Dev.NotReady("Учебный план");

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

        #endregion
        #region Блок методов для студентов
        async void UpdateStudents(EducationGroupVM educationGroupVM) 
        {
            if (educationGroupVM == null) return;

            var students = await _educationGroupRepository.Update(educationGroupVM.Id);
            if(students == null || !students.Any()) return;

            educationGroupVM.Students.Clear();
            foreach (var student in students) 
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
                foreach(var document in student.Documents)
                {
                    if(document is PassportStudent passport)
                    {
                        var passportVM = new PassportStudentVM
                        {
                            Id = passport.Id,
                            TypeDocument = passport.TypeDocument,
                            SurName = passport.SurName,
                            Name = passport.Name,
                            MiddleName = passport.MiddleName,
                            DateOfBirth = passport.DateOfBirth,
                            Gender = passport.Gender,
                            PlaceOfBirth = passport.PlaceOfBirth,
                            IssuedBy = passport.IssuedBy,
                            DateOfIssue = passport.DateOfIssue,
                            DepartmentCode = passport.DepartmentCode,
                            SeriesNumber = passport.SeriesNumber,
                            AdditionalInformation = passport.AdditionalInformation
                        };
                        studentVM.Documents.Add(passportVM);
                    }
                    else if (document is SnilsStudent snils)
                    {
                        var snilsVM = new SnilsStudentVM
                        {
                            Id = snils.Id,
                            TypeDocument = snils.TypeDocument,
                            SurName = snils.SurName,
                            Name = snils.Name,
                            MiddleName = snils.MiddleName,
                            DateOfBirth = snils.DateOfBirth,
                            Gender = snils.Gender,
                            PlaceOfBirth = snils.PlaceOfBirth,
                            Number = snils.Number,
                            RegistrationDate = snils.RegistrationDate,
                            AdditionalInformation = snils.AdditionalInformation
                        };
                        studentVM.Documents.Add(snilsVM);
                    }
                    else if (document is InnStudent inn)
                    {
                        var innVM = new InnStudentVM
                        {
                            Id = inn.Id,
                            TypeDocument = inn.TypeDocument,
                            SurName = inn.SurName,
                            Name = inn.Name,
                            MiddleName = inn.MiddleName,
                            DateOfBirth = inn.DateOfBirth,
                            Gender = inn.Gender,
                            PlaceOfBirth = inn.PlaceOfBirth,
                            NumberINN = inn.NumberINN,
                            DateAssigned = inn.DateAssigned,
                            SeriesNumber = inn.SeriesNumber,
                            AdditionalInformation = inn.AdditionalInformation
                        };
                        studentVM.Documents.Add(innVM);
                    }
                    else if (document is ForeignPassportStudent foreignPassport)
                    {
                        var foreignPassportVM = new ForeignPassportStudentVM
                        {
                            Id = foreignPassport.Id,
                            TypeDocument = foreignPassport.TypeDocument,
                            SurName = foreignPassport.SurName,
                            Name = foreignPassport.Name,
                            MiddleName = foreignPassport.MiddleName,
                            DateOfBirth = foreignPassport.DateOfBirth,
                            Gender = foreignPassport.Gender,
                            PlaceOfBirth = foreignPassport.PlaceOfBirth,
                            IssuedBy = foreignPassport.IssuedBy,
                            DateOfIssue = foreignPassport.DateOfIssue,
                            SeriesNumber = foreignPassport.SeriesNumber,
                            AdditionalInformation = foreignPassport.AdditionalInformation
                        };
                        studentVM.Documents.Add(foreignPassportVM);
                    }
                }

                educationGroupVM.Students.Add(studentVM);
            }
        }
        void ShowProfileStudent(StudentVM studentVM)
        {
            if (studentVM == null) return;

            _tabControl.CreateTab<ProfileStudentViewModel>("Профиль студента", null, studentVM);
        }

        void OpenWindowAddStudent(EducationGroupVM educationGroupVM)
        {
            if (educationGroupVM == null) return;

            _tabControl.CreateTab<AddStudentViewModel>("Добавление студента", null, educationGroupVM);
        }
        void ChangeStudent(StudentVM studentVM)
        {
            if (studentVM == null) return;
            // Создать юзерконтрол и отправить туда студента
        }
        async void DeleteStudent(StudentVM studentVM)
        {
            if (studentVM == null) return;

            if (await _educationGroupRepository.Delete<Student>(studentVM.Id)) SelectedEducationGroup.Students.Remove(studentVM);
        }
        #endregion

        void CloseTab() => _tabControl.RemoveTab();
    }
}