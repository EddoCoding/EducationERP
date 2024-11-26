using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Models.Modules.EducationalInstitution;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.SettingStructEducational
{
    public class SettingStructEducationalViewModel : RaketaViewModel
    {
        public StructEducationalInstitutionVM StructEducationalInstitutionVM { get; set; } = new();

        public RaketaCommand ExitCommand { get; }

        public RaketaTCommand<StructEducationalInstitutionVM> OpenWindowAddFacultyCommand { get; set; }
        public RaketaTCommand<FacultyVM> OpenWindowChangeFacultyCommand { get; set; }
        public RaketaTCommand<FacultyVM> DeleteFacultyCommand { get; set; }

        public RaketaTCommand<FacultyVM> OpenWindowAddDepartmentCommand { get; set; }
        public RaketaTCommand<DepartmentVM> OpenWindowChangeDepartmentCommand { get; set; }
        public RaketaTCommand<DepartmentVM> DeleteDepartmentCommand { get; set; }

        public RaketaTCommand<StructEducationalInstitutionVM> SaveStructEducationCommand { get; set; }

        IServiceView _serviceView;
        IStructEducationRepository _structEducationRepository;
        ITabControl _tabControl;
        public SettingStructEducationalViewModel(IServiceView serviceView, IStructEducationRepository structEducationRepository, ITabControl tabControl)
        {
            _serviceView = serviceView;
            _structEducationRepository = structEducationRepository;
            _tabControl = tabControl;

            Mapp(structEducationRepository.GetStructEducation());

            ExitCommand = RaketaCommand.Launch(CloseTab);

            OpenWindowAddFacultyCommand = RaketaTCommand<StructEducationalInstitutionVM>.Launch(OpenWindowAddFaculty);
            OpenWindowChangeFacultyCommand = RaketaTCommand<FacultyVM>.Launch(OpenWindowChangeFaculty);
            DeleteFacultyCommand = RaketaTCommand<FacultyVM>.Launch(DeleteFaculty);

            OpenWindowAddDepartmentCommand = RaketaTCommand<FacultyVM>.Launch(OpenWindowAddDepartment);
            OpenWindowChangeDepartmentCommand = RaketaTCommand<DepartmentVM>.Launch(OpenWindowChangeDepartment);
            DeleteDepartmentCommand = RaketaTCommand<DepartmentVM>.Launch(DeleteDepartment);

            SaveStructEducationCommand = RaketaTCommand<StructEducationalInstitutionVM>.Launch(SaveStructEducation);
        }

        void Mapp(StructEducationalInstitution structModel)
        {
            if(structModel != null)
            {
                var structVM = new StructEducationalInstitutionVM
                {
                    Id = structModel.Id,
                    NameVUZ = structModel.NameVUZ,
                    ShortNameVUZ = structModel.ShortNameVUZ,
                    Faculties = new()
                };
                foreach(var faculty in structModel.Faculties)
                {
                    var facultyVM = new FacultyVM
                    {
                        Id = faculty.Id,
                        NameFaculty = faculty.NameFaculty,
                        PasswordFaculty = faculty.PasswordFaculty,
                        Departments = new()
                    };
                    foreach (var department in faculty.Departments)
                    {
                        var departmentVM = new DepartmentVM
                        {
                            Id = department.Id,
                            NameDepartment = department.NameDepartment
                        };
                        facultyVM.Departments.Add(departmentVM);
                    }
                    structVM.Faculties.Add(facultyVM);
                }
                StructEducationalInstitutionVM = structVM;
            }
        }

        void OpenWindowAddFaculty(StructEducationalInstitutionVM structVM) =>
            _serviceView.Window<AddMainFacultyViewModel>(null, structVM).Modal();
        void OpenWindowChangeFaculty(FacultyVM facultyVM) =>
            _serviceView.Window<ChangeMainFacultyViewModel>(null, facultyVM).Modal();
        async void DeleteFaculty(FacultyVM facultyVM)
        {
            bool isDeleted = await _structEducationRepository.DeleteFaculty(facultyVM.Id);
            if(isDeleted) StructEducationalInstitutionVM.Faculties.Remove(facultyVM);
        }

        void OpenWindowAddDepartment(FacultyVM facultyVM) =>
            _serviceView.Window<AddMainDepartmentViewModel>(null, facultyVM).Modal();
        void OpenWindowChangeDepartment(DepartmentVM departmentVM) =>
            _serviceView.Window<ChangeMainDepartmentViewModel>(null, departmentVM).Modal();
        async void DeleteDepartment(DepartmentVM departmentVM)
        {
            bool isDeleted = await _structEducationRepository.DeleteDepartment(departmentVM.Id);
            if (isDeleted)
            {
                foreach(var faculty in StructEducationalInstitutionVM.Faculties)
                {
                    foreach(var department in faculty.Departments)
                    {
                        if(department.NameDepartment == departmentVM.NameDepartment)
                        {
                            faculty.Departments.Remove(departmentVM);
                            return;
                        }
                    }
                }
            }
        }

        async void SaveStructEducation(StructEducationalInstitutionVM structVM)
        {
            var structModel = new StructEducationalInstitution
            {
                Id = structVM.Id,
                NameVUZ = structVM.NameVUZ,
                ShortNameVUZ = structVM.ShortNameVUZ
            };

            await _structEducationRepository.SaveStructEducation(structModel);
        }

        void CloseTab() => _tabControl.RemoveTab();
    }
}