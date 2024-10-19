using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.EducationalInstitution;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingStructEducational
{
    public class SettingStructEducationalViewModel
    {
        public StructEducationalInstitutionVM StructEducationalInstitutionVM { get; set; } = new();

        public RaketaTCommand<ObservableCollection<FacultyVM>> OpenWindowAddFacultyCommand { get; set; }
        public RaketaTCommand<StructEducationalInstitutionVM> SaveStructEducationCommand { get; set; }

        IServiceView _serviceView;
        IStructEducationRepository _structEducationRepository;
        public SettingStructEducationalViewModel(IServiceView serviceView, IStructEducationRepository structEducationRepository)
        {
            _serviceView = serviceView;
            _structEducationRepository = structEducationRepository;

            Mapp(structEducationRepository.GetStructEducation());

            OpenWindowAddFacultyCommand = RaketaTCommand<ObservableCollection<FacultyVM>>.Launch(OpenWindowAddFaculty);
            SaveStructEducationCommand = RaketaTCommand<StructEducationalInstitutionVM>.Launch(SaveStructEducation);
        }

        void OpenWindowAddFaculty(ObservableCollection<FacultyVM> faculties) =>
            _serviceView.Window<AddMainFacultyViewModel>(null, faculties).Modal();
        void Mapp(StructEducationalInstitution structModel)
        {
            if(structModel != null)
            {
                var structVM = new StructEducationalInstitutionVM
                {
                    Id = structModel.Id,
                    NameVUZ = structModel.NameVUZ,
                    ShortNameVUZ = structModel.ShortNameVUZ
                };
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
    }
}