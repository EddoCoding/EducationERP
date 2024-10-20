using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.EducationalInstitution;
using Raketa;
using System.Text;

namespace EducationERP.ViewModels.Modules.Administration.SettingStructEducational
{
    public class AddMainFacultyViewModel : RaketaViewModel
    {
        public FacultyVM FacultyVM { get; set; } = new();

        public RaketaCommand GenerationPasswordCommand { get; set; }
        public RaketaTCommand<FacultyVM> AddFacultyCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        IStructEducationRepository _structEducationRepository;
        StructEducationalInstitutionVM _structVM;
        public AddMainFacultyViewModel(IServiceView serviceView, IStructEducationRepository structEducationRepository, 
            StructEducationalInstitutionVM structVM)
        {
            _serviceView = serviceView;
            _structEducationRepository = structEducationRepository;
            _structVM = structVM;

            GenerationPasswordCommand = RaketaCommand.Launch(GenerationPassword);
            AddFacultyCommand = RaketaTCommand<FacultyVM>.Launch(AddFaculty);
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
        async void AddFaculty(FacultyVM facultyVM)
        {
            var faculty = new Faculty
            {
                Id = facultyVM.Id,
                NameFaculty = facultyVM.NameFaculty,
                PasswordFaculty = facultyVM.PasswordFaculty,
                StructEducationalInstitutionId = _structVM.Id
            };
            bool isAdded = await _structEducationRepository.CreateFaculty(faculty);
            if (isAdded)
            {
                _structVM.Faculties.Add(facultyVM);
                CloseWindow();
            }

        }
        void CloseWindow() => _serviceView.Close<AddMainFacultyViewModel>();
    }
}