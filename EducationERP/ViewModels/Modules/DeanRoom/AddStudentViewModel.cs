using EducationERP.Common.Components;
using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Models.Modules.EducationalInstitution;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using Raketa;

namespace EducationERP.ViewModels.Modules.DeanRoom
{
    public class AddStudentViewModel : RaketaViewModel
    {
        public StudentVM StudentVM { get; set; } = new();

        public RaketaTCommand<StudentVM> AddStudentCommand { get; }
        public RaketaCommand ExitCommand { get; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        public UserSystem UserSystem { get; set; }
        IEducationGroupRepository _educationGroupRepository;
        public EducationGroupVM EducationGroupVM { get; set; }
        public AddStudentViewModel(IServiceView serviceView, ITabControl tabControl, UserSystem userSystem,
            IEducationGroupRepository educationGroupRepository, 
            EducationGroupVM educationGroupVM)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;
            UserSystem = userSystem;
            _educationGroupRepository = educationGroupRepository;
            EducationGroupVM = educationGroupVM;

            AddStudentCommand = RaketaTCommand<StudentVM>.Launch(AddStudent);
            ExitCommand = RaketaCommand.Launch(CloseTab);
        }

        async void AddStudent(StudentVM studentVM)
        {
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

                EducationGroupId = EducationGroupVM.Id
            };
            bool isAdded = await _educationGroupRepository.CreateStudent(student);
            if (!isAdded) return;

            EducationGroupVM.Students.Add(studentVM);
            CloseTab();
        }
        void CloseTab() => _tabControl.RemoveTab();
    }
}