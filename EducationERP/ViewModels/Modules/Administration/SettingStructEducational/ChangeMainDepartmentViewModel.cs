using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.EducationalInstitution;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.SettingStructEducational
{
    public class ChangeMainDepartmentViewModel : RaketaViewModel
    {
        public RaketaTCommand<DepartmentVM> ChangeDepartmentCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        IStructEducationRepository _structEducationRepository;
        public DepartmentVM DepartmentVM { get; set; }
        public ChangeMainDepartmentViewModel(IServiceView serviceView, IStructEducationRepository structEducationRepository, DepartmentVM departmentVM)
        {
            _serviceView = serviceView;
            _structEducationRepository = structEducationRepository;
            DepartmentVM = departmentVM;

            ChangeDepartmentCommand = RaketaTCommand<DepartmentVM>.Launch(AddDepartment);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        async void AddDepartment(DepartmentVM departmentVM)
        {
            bool isValidateed = departmentVM.Validation();
            if (!isValidateed) return;

            bool isUpdated = await _structEducationRepository.UpdateDepartment(departmentVM);
            if (isUpdated) CloseWindow();
        }
        void CloseWindow() => _serviceView.Close<ChangeMainDepartmentViewModel>();
    }
}