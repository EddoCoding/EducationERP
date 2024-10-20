using EducationERP.Common.Components.Repositories;
using Raketa;
using System.Text;

namespace EducationERP.ViewModels.Modules.Administration.SettingStructEducational
{
    public class ChangeMainFacultyViewModel : RaketaViewModel
    {
        public RaketaCommand GenerationPasswordCommand { get; set; }
        public RaketaTCommand<FacultyVM> ChangeFacultyCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        IStructEducationRepository _structEducationRepository;
        public FacultyVM FacultyVM { get; set; }
        public ChangeMainFacultyViewModel(IServiceView serviceView, IStructEducationRepository structEducationRepository, FacultyVM facultyVM)
        {
            _serviceView = serviceView;
            _structEducationRepository = structEducationRepository;
            FacultyVM = facultyVM;

            GenerationPasswordCommand = RaketaCommand.Launch(GenerationPassword);
            ChangeFacultyCommand = RaketaTCommand<FacultyVM>.Launch(ChangeFaculty);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        void GenerationPassword()
        {
            string signs = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder sb = new StringBuilder(8);

            for (int i = 0; i < 8; i++)
            {
                int index = new Random().Next(signs.Length);
                sb.Append(signs[index]);
            }

            FacultyVM.PasswordFaculty = sb.ToString();
        }
        async void ChangeFaculty(FacultyVM facultyVM)
        {
            bool isValidated = facultyVM.Validation();
            if (!isValidated) return;

            bool isUpdated = await _structEducationRepository.UpdateFaculty(facultyVM);
            if(isUpdated) CloseWindow();
        }
        void CloseWindow() => _serviceView.Close<ChangeMainFacultyViewModel>();
    }
}