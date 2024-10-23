using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using Raketa;
using System.Collections.ObjectModel;

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


        public RaketaTCommand<ObservableCollection<EducationGroupVM>> OpenWindowAddEducationGroupCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        IFacultyRepository _facultyRepository;
        Guid _id;
        public DeanRoomViewModel(IServiceView serviceView, ITabControl tabControl, IFacultyRepository facultyRepository, Guid id)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;
            _facultyRepository = facultyRepository;

            GetFaculty(id);

            OpenWindowAddEducationGroupCommand = RaketaTCommand<ObservableCollection<EducationGroupVM>>.Launch(OpenWindowAddEducationGroup);
            ExitCommand = RaketaCommand.Launch(CloseTab);
        }

        void OpenWindowAddEducationGroup(ObservableCollection<EducationGroupVM> educationGroups) =>
            _serviceView.Window<AddEducationGroupViewModel>(null, educationGroups).Modal();

        void GetFaculty(Guid id)
        {
            var faculty = _facultyRepository.GetFacultyById(id);
            if (faculty == null) return;

            FacultyVM = new FacultyVM
            {
                Id = faculty.Id,
                NameFaculty = faculty.NameFaculty,
                PasswordFaculty = faculty.PasswordFaculty,
                EducationGroups = new()
            };
            foreach(var educationGroup in faculty.EducationGroups)
            {
                var educationGroupVM = new EducationGroupVM
                {
                    Id = educationGroup.Id,
                    NameEducationGroup = educationGroup.NameEducationGroup
                };
                FacultyVM.EducationGroups.Add(educationGroupVM);
            }
        }
        void CloseTab() => _tabControl.RemoveTab();
    }
}
// SEcuHso2
// COnSvjBu