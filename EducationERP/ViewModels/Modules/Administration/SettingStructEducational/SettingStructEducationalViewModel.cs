using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.EducationalInstitution;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.SettingStructEducational
{
    public class SettingStructEducationalViewModel
    {
        public StructEducationalInstitutionVM StructEducationalInstitutionVM { get; set; } = new();

        public RaketaTCommand<StructEducationalInstitutionVM> OpenWindowAddFacultyCommand { get; set; }
        public RaketaTCommand<StructEducationalInstitutionVM> SaveStructEducationCommand { get; set; }
        public RaketaTCommand<FacultyVM> OpenWindowChangeFacultyCommand { get; set; }
        public RaketaTCommand<FacultyVM> DeleteFacultyCommand { get; set; }

        IServiceView _serviceView;
        IStructEducationRepository _structEducationRepository;
        public SettingStructEducationalViewModel(IServiceView serviceView, IStructEducationRepository structEducationRepository)
        {
            _serviceView = serviceView;
            _structEducationRepository = structEducationRepository;

            Mapp(structEducationRepository.GetStructEducation());

            OpenWindowAddFacultyCommand = RaketaTCommand<StructEducationalInstitutionVM>.Launch(OpenWindowAddFaculty);
            SaveStructEducationCommand = RaketaTCommand<StructEducationalInstitutionVM>.Launch(SaveStructEducation);
            OpenWindowChangeFacultyCommand = RaketaTCommand<FacultyVM>.Launch(OpenWindowChangeFaculty);
            DeleteFacultyCommand = RaketaTCommand<FacultyVM>.Launch(DeleteFaculty);
        }

        void OpenWindowAddFaculty(StructEducationalInstitutionVM structVM) =>
            _serviceView.Window<AddMainFacultyViewModel>(null, structVM).Modal();
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
                        PasswordFaculty = faculty.PasswordFaculty
                    };
                    structVM.Faculties.Add(facultyVM);
                }
                StructEducationalInstitutionVM = structVM;
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
        void OpenWindowChangeFaculty(FacultyVM facultyVM) =>
            _serviceView.Window<ChangeMainFacultyViewModel>(null, facultyVM).Modal();
        async void DeleteFaculty(FacultyVM facultyVM)
        {
            bool isDeleted = await _structEducationRepository.DeleteFaculty(facultyVM.Id);
            if(isDeleted) StructEducationalInstitutionVM.Faculties.Remove(facultyVM);
        }
    }
}