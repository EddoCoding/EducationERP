using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.EducationalInstitution;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.SettingStructEducational
{
    public class AddMainDepartmentViewModel : RaketaViewModel
    {
        public DepartmentVM DepartmentVM { get; set; } = new();

        public RaketaTCommand<DepartmentVM> AddDepartmentCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        IStructEducationRepository _structEducationRepository;
        FacultyVM _facultyVM;
        public AddMainDepartmentViewModel(IServiceView serviceView, IStructEducationRepository structEducationRepository, FacultyVM facultyVM)
        {
            _serviceView = serviceView;
            _structEducationRepository = structEducationRepository;
            _facultyVM = facultyVM;

            AddDepartmentCommand = RaketaTCommand<DepartmentVM>.Launch(AddDepartment);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        async void AddDepartment(DepartmentVM departmentVM)
        {
            bool isValidateed = departmentVM.Validation();
            if (!isValidateed) return;

            var department = new Department
            {
                Id = departmentVM.Id,
                NameDepartment = departmentVM.NameDepartment,
                FacultyId = _facultyVM.Id
            };
            bool isAdded = await _structEducationRepository.CreateDepartment(department);
            if (isAdded) 
            {
                _facultyVM.Departments.Add(departmentVM);
                CloseWindow();
            }

        }
        void CloseWindow() => _serviceView.Close<AddMainDepartmentViewModel>();
    }
}