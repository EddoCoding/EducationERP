using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using Raketa;

namespace EducationERP.ViewModels.Modules.DeanRoom
{
    public class DeanRoomViewModel : RaketaViewModel
    {
        FacultyVM facultyVM;
        public FacultyVM FacultyVM
        {
            get => facultyVM;
            set => SetValue(ref facultyVM, value);
        }

        public RaketaCommand ExitCommand { get; set; }

        ITabControl _tabControl;
        IStructEducationRepository _structEducationRepository;
        Guid _id;
        public DeanRoomViewModel(ITabControl tabControl, IStructEducationRepository structEducationRepository, Guid id)
        {
            _tabControl = tabControl;
            _structEducationRepository = structEducationRepository;

            GetFaculty(id);

            ExitCommand = RaketaCommand.Launch(CloseTab);
        }

        void CloseTab() => _tabControl.RemoveTab();

        void GetFaculty(Guid id)
        {
            var faculty = _structEducationRepository.GetFacultyById(id);

            FacultyVM = new FacultyVM
            {
                Id = faculty.Id,
                NameFaculty = faculty.NameFaculty,
                PasswordFaculty = faculty.PasswordFaculty
            };
            foreach(var department in faculty.Departments)
            {
                var departmentVM = new DepartmentVM
                {
                    Id= department.Id,
                    NameDepartment = department.NameDepartment
                };
                FacultyVM.Departments.Add(departmentVM);
            }
        }
    }
}
// SEcuHso2
// COnSvjBu