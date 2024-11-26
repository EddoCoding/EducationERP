using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class AddSettingFacultyViewModel : RaketaViewModel
    {
        public SettingFacultyVM FacultyVM { get; set; } = new();

        public RaketaCommand ExitCommand { get; set; }
        public RaketaTCommand<SettingFacultyVM> AddFacultyCommand { get; set; }

        IServiceView _serviceView;
        ISettingFacultyRepository _facultyRepository;
        ObservableCollection<SettingFacultyVM> _faculties;
        public AddSettingFacultyViewModel(IServiceView serviceView, ISettingFacultyRepository facultyRepository, 
            ObservableCollection<SettingFacultyVM> faculties)
        {
            _serviceView = serviceView;
            _facultyRepository = facultyRepository;
            _faculties = faculties;

            AddFacultyCommand = RaketaTCommand<SettingFacultyVM>.Launch(AddFaculty);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        async void AddFaculty(SettingFacultyVM facultyVM)
        {
            var isValidated = facultyVM.Validation();
            if (isValidated)
            {
                bool isAdded = await _facultyRepository.Create<SettingFaculty>(new SettingFaculty
                {
                    Id = facultyVM.Id,
                    NameFaculty = facultyVM.NameFaculty,
                    StructEducationalInstitutionId = await _facultyRepository.GetIdVuz()
                });
                if (isAdded)
                {
                    _faculties.Add(facultyVM);
                    _faculties = null;
                    _serviceView.Close<AddSettingFacultyViewModel>();
                }
            }
        }
        void CloseWindow() => _serviceView.Close<AddSettingFacultyViewModel>();
    }
}