using EducationERP.Common.Components;
using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Models.Modules.DeanRoom.DocumentsStudent;
using EducationERP.Models.Modules.EducationalInstitution;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using EducationERP.ViewModels.Modules.DeanRoom.DocumentsStudent;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.DeanRoom
{
    public class AddStudentViewModel : RaketaViewModel
    {
        public StudentVM StudentVM { get; set; } = new();

        public RaketaTCommand<ObservableCollection<DocumentStudentBaseVM>> AddDocumentCommand { get; }
        public RaketaTCommand<DocumentStudentBaseVM> ChangeDocumentCommand { get; }
        public RaketaTCommand<DocumentStudentBaseVM> DeleteDocumentCommand { get; }

        public RaketaTCommand<StudentVM> AddStudentCommand { get; }
        public RaketaCommand ExitCommand { get; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        public UserSystem UserSystem { get; set; }
        IEducationGroupRepository _educationGroupRepository;
        public EducationGroupVM EducationGroupVM { get; set; }
        public AddStudentViewModel(IServiceView serviceView, ITabControl tabControl, UserSystem userSystem,
            IEducationGroupRepository educationGroupRepository, EducationGroupVM educationGroupVM)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;
            UserSystem = userSystem;
            _educationGroupRepository = educationGroupRepository;
            EducationGroupVM = educationGroupVM;

            AddDocumentCommand = RaketaTCommand<ObservableCollection<DocumentStudentBaseVM>>.Launch(AddDocument);
            ChangeDocumentCommand = RaketaTCommand<DocumentStudentBaseVM>.Launch(ChangeDocument);
            DeleteDocumentCommand = RaketaTCommand<DocumentStudentBaseVM>.Launch(DeleteDocument);

            AddStudentCommand = RaketaTCommand<StudentVM>.Launch(AddStudent);
            ExitCommand = RaketaCommand.Launch(CloseTab);
        }

        void AddDocument(ObservableCollection<DocumentStudentBaseVM> documents) =>
            _serviceView.Window<AddDocumentStudentViewModel>(null, documents).Modal();
        void ChangeDocument(DocumentStudentBaseVM document) =>
            _serviceView.Window<ChangeDocumentStudentViewModel>(null, document).Modal();
        void DeleteDocument(DocumentStudentBaseVM document) => StudentVM.Documents.Remove(document);


        async void AddStudent(StudentVM studentVM)
        {
            bool isValidated = studentVM.Validation();
            if(!isValidated) return;
            
            var student = new Student
            {
                Id = studentVM.Id,
                SurName = studentVM.SurName,
                Name = studentVM.Name,
                MiddleName = studentVM.MiddleName,
                DateOfBirth = studentVM.DateOfBirth,
                Gender = studentVM.Gender,
                PlaceOfBirth = studentVM.PlaceOfBirth,
                Citizenship = studentVM.Citizenship,
                CitizenshipValidFrom = studentVM.CitizenshipValidFrom,
                IsNeedHostel = studentVM.IsNeedHostel,
                IsNotNeedHostel = studentVM.IsNotNeedHostel,

                ResidentialAddress = studentVM.ResidentialAddress,
                AddressOfRegistration = studentVM.AddressOfRegistration,
                HomePhone = studentVM.HomePhone,
                MobilePhone = studentVM.MobilePhone,
                Mail = studentVM.Mail,
                AdditionalContactInformation = studentVM.AdditionalContactInformation,
                Accepted = UserSystem.FullName,

                NameEducationGroup = EducationGroupVM.NameEducationGroup,
                LevelGroup = EducationGroupVM.LevelGroup,
                FormGroup = EducationGroupVM.FormGroup,
                TypeGroup = EducationGroupVM.TypeGroup,
                Course = EducationGroupVM.Course,
                CodeDirection = EducationGroupVM.CodeDirection,
                NameDirection = EducationGroupVM.NameDirection,
                CodeProfile = EducationGroupVM.CodeProfile,
                NameProfile = EducationGroupVM.NameProfile,

                EducationGroupId = EducationGroupVM.Id
            };
            bool isAdded = await _educationGroupRepository.Create<Student>(student);
            if (!isAdded) return;

            // Перебор документов студента и добавление в бд
            foreach (var document in StudentVM.Documents)
            {
                if (document is PassportStudentVM passportVM)
                {
                    var passport = new PassportStudent
                    {
                        Id = passportVM.Id,
                        TypeDocument = passportVM.TypeDocument,
                        SurName = passportVM.SurName,
                        Name = passportVM.Name,
                        MiddleName = passportVM.MiddleName,
                        Gender = passportVM.Gender,
                        DateOfBirth = passportVM.DateOfBirth,
                        PlaceOfBirth = passportVM.PlaceOfBirth,
                        IssuedBy = passportVM.IssuedBy,
                        DateOfIssue = passportVM.DateOfIssue,
                        DepartmentCode = passportVM.DepartmentCode,
                        SeriesNumber = passportVM.SeriesNumber,
                        AdditionalInformation = passportVM.AdditionalInformation,
            
                        StudentId = student.Id
                    };
                    await _educationGroupRepository.Create<PassportStudent>(passport);
                }
                else if (document is SnilsStudentVM snilsVM)
                {
                    var snils = new SnilsStudent
                    {
                        Id = snilsVM.Id,
                        TypeDocument = snilsVM.TypeDocument,
                        SurName = snilsVM.SurName,
                        Name = snilsVM.Name,
                        MiddleName = snilsVM.MiddleName,
                        Gender = snilsVM.Gender,
                        DateOfBirth = snilsVM.DateOfBirth,
                        PlaceOfBirth = snilsVM.PlaceOfBirth,
                        Number = snilsVM.Number,
                        RegistrationDate = snilsVM.RegistrationDate,
                        AdditionalInformation = snilsVM.AdditionalInformation,

                        StudentId = student.Id
                    };
                    await _educationGroupRepository.Create<SnilsStudent>(snils);
                }
                else if (document is InnStudentVM innVM)
                {
                    var inn = new InnStudent
                    {
                        Id = innVM.Id,
                        TypeDocument = innVM.TypeDocument,
                        SurName = innVM.SurName,
                        Name = innVM.Name,
                        MiddleName = innVM.MiddleName,
                        Gender = innVM.Gender,
                        DateOfBirth = innVM.DateOfBirth,
                        PlaceOfBirth = innVM.PlaceOfBirth,
                        NumberINN = innVM.NumberINN,
                        DateAssigned = innVM.DateAssigned,
                        SeriesNumber = innVM.SeriesNumber,
                        AdditionalInformation = innVM.AdditionalInformation,

                        StudentId = student.Id
                    };
                    await _educationGroupRepository.Create<InnStudent>(inn);
                }
                else if (document is ForeignPassportStudentVM foreignPassportVM)
                {
                    var foreignPassport = new ForeignPassportStudent
                    {
                        Id = foreignPassportVM.Id,
                        TypeDocument = foreignPassportVM.TypeDocument,
                        SurName = foreignPassportVM.SurName,
                        Name = foreignPassportVM.Name,
                        MiddleName = foreignPassportVM.MiddleName,
                        Gender = foreignPassportVM.Gender,
                        DateOfBirth = foreignPassportVM.DateOfBirth,
                        PlaceOfBirth = foreignPassportVM.PlaceOfBirth,
                        IssuedBy = foreignPassportVM.IssuedBy,
                        DateOfIssue = foreignPassportVM.DateOfIssue,
                        SeriesNumber = foreignPassportVM.SeriesNumber,
                        AdditionalInformation = foreignPassportVM.AdditionalInformation,

                        StudentId = student.Id
                    };
                    await _educationGroupRepository.Create<ForeignPassportStudent>(foreignPassport);
                }
            }

            EducationGroupVM.Students.Add(studentVM);
            CloseTab();
        }
        void CloseTab() => _tabControl.RemoveTab();
    }
}