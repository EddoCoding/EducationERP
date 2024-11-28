using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Common.ToolsDev;
using EducationERP.Models.Modules.DeanRoom.DocumentsStudent;
using EducationERP.Models.Modules.EducationalInstitution;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using EducationERP.ViewModels.Modules.DeanRoom;
using EducationERP.ViewModels.Modules.DeanRoom.DocumentsStudent;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.SettingDeanRoom
{
    public class SettingDeanRoomViewModel : RaketaViewModel
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

        public RaketaCommand ExitCommand { get; }

        #region Блок команд групп
        public RaketaTCommand<FacultyVM> OpenWindowAddEducationGroupCommand { get; }
        public RaketaTCommand<EducationGroupVM> OpenWindowChangeEducationGroupCommand { get; }
        public RaketaTCommand<EducationGroupVM> DeleteEducationGroupCommand { get; }
        public RaketaCommand UpdateGroupsCommand { get; }
        #endregion
        #region Блок команд студентов
        public RaketaTCommand<EducationGroupVM> OpenWindowAddStudentCommand { get; }
        public RaketaTCommand<EducationGroupVM> UpdateStudentsCommand { get; }
        #endregion

        IServiceView _serviceView;
        ITabControl _tabControl;
        IFacultyRepository _facultyRepository;
        IEducationGroupRepository _educationGroupRepository;
        Guid _id;
        public SettingDeanRoomViewModel(IServiceView serviceView, ITabControl tabControl, IFacultyRepository facultyRepository,
            IEducationGroupRepository educationGroupRepository, Guid id)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;
            _facultyRepository = facultyRepository;
            _educationGroupRepository = educationGroupRepository;
            _id = id;

            GetFaculty(id);

            ExitCommand = RaketaCommand.Launch(CloseTab);

            OpenWindowAddEducationGroupCommand = RaketaTCommand<FacultyVM>.Launch(OpenWindowAddEducationGroup);
            OpenWindowChangeEducationGroupCommand = RaketaTCommand<EducationGroupVM>.Launch(OpenWindowChangeEducationGroup);
            DeleteEducationGroupCommand = RaketaTCommand<EducationGroupVM>.Launch(DeleteEducationGroup);
            UpdateGroupsCommand = RaketaCommand.Launch(UpdateGroup);

            OpenWindowAddStudentCommand = RaketaTCommand<EducationGroupVM>.Launch(OpenWindowAddStudent);
            UpdateStudentsCommand = RaketaTCommand<EducationGroupVM>.Launch(UpdateStudents);
        }

        void CloseTab() => _tabControl.RemoveTab();
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
            foreach (var educationGroup in faculty.EducationGroups)
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

        #region Блок методов групп
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
        async void UpdateGroup()
        {
            var groups = await _facultyRepository.GetGroups(_id);
            FacultyVM.EducationGroups.Clear();
            foreach(var educationGroup in groups)
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
        #endregion
        #region Блок методов студентов
        void OpenWindowAddStudent(EducationGroupVM educationGroupVM)
        {
            if (educationGroupVM == null) return;

            _tabControl.CreateTab<AddStudentViewModel>("Добавление студента", null, educationGroupVM);
        }
        async void UpdateStudents(EducationGroupVM educationGroupVM)
        {
            if(educationGroupVM == null) return;

            var students = await _educationGroupRepository.Update(educationGroupVM.Id);
            if (students == null || !students.Any()) return;

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
                foreach (var document in student.Documents)
                {
                    if (document is PassportStudent passport)
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
        #endregion
    }
}