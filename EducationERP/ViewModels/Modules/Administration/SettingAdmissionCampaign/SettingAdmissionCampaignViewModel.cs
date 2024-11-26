using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class SettingAdmissionCampaignViewModel : RaketaViewModel
    {
        public ObservableCollection<SettingFacultyVM> Faculties { get; set; } = new();

        public RaketaCommand ExitCommand { get; set; }

        public RaketaTCommand<ObservableCollection<SettingFacultyVM>> OpenWindowAddFacultyCommand { get; }
        public RaketaTCommand<SettingFacultyVM> DeleteFacultyCommand { get; }
        public RaketaTCommand<SettingFacultyVM> OpenWindowAddLevelCommand { get; }
        public RaketaTCommand<SettingLevelVM> DeleteLevelCommand { get; set; }
        public RaketaTCommand<SettingLevelVM> OpenWindowAddDirectionCommand { get; }
        public RaketaTCommand<SettingDirectionVM> DeleteDirectionCommand { get; }

        IServiceView _serviceView;
        ISettingFacultyRepository _facultyRepository;
        ITabControl _tabControl;
        public SettingAdmissionCampaignViewModel(IServiceView serviceView, ISettingFacultyRepository facultyRepository, ITabControl tabControl)
        {
            _serviceView = serviceView;
            _facultyRepository = facultyRepository;
            _tabControl = tabControl;

            foreach (var faculty in facultyRepository.Read())
            {
                var facultyVM = new SettingFacultyVM
                {
                    Id = faculty.Id,
                    NameFaculty = faculty.NameFaculty,
                    Levels = new()
                };
                foreach(var level in faculty.Levels)
                {
                    var levelVM = new SettingLevelVM
                    {
                        Id = level.Id,
                        NameLevel = level.NameLevel,
                        Directions = new()
                    };
                    foreach(var direction in level.Directions)
                    {
                        var directionVM = new SettingDirectionVM
                        {
                            Id= direction.Id,
                            CodeDirection = direction.CodeDirection,
                            NameDirection = direction.NameDirection,
                            CodeProfile = direction.CodeProfile,
                            NameProfile = direction.NameProfile,
                            NameFormEducation = direction.NameFormEducation,
                            NameFormPayment = direction.NameFormPayment
                        };
                        levelVM.Directions.Add(directionVM);
                    }
                    facultyVM.Levels.Add(levelVM);
                }
                Faculties.Add(facultyVM);
            }

            ExitCommand = RaketaCommand.Launch(CloseTab);

            OpenWindowAddFacultyCommand = RaketaTCommand<ObservableCollection<SettingFacultyVM>>.Launch(OpenWindowAddFaculty);
            DeleteFacultyCommand = RaketaTCommand<SettingFacultyVM>.Launch(DeleteFaculty);
            OpenWindowAddLevelCommand = RaketaTCommand<SettingFacultyVM>.Launch(OpenWindowAddLevel);
            DeleteLevelCommand = RaketaTCommand<SettingLevelVM>.Launch(DeleteLevel);
            OpenWindowAddDirectionCommand = RaketaTCommand<SettingLevelVM>.Launch(OpenWindowAddDirection);
            DeleteDirectionCommand = RaketaTCommand<SettingDirectionVM>.Launch(DeleteDirection);
        }

        void CloseTab() => _tabControl.RemoveTab();

        void OpenWindowAddFaculty(ObservableCollection<SettingFacultyVM> faculties) => 
            _serviceView.Window<AddSettingFacultyViewModel>(null, faculties).Modal();
        async void DeleteFaculty(SettingFacultyVM facultyVM)
        {
            bool isDeleted = await _facultyRepository.Delete<SettingFaculty>(facultyVM.Id);
            if (isDeleted)
            {
                foreach(var faculty in Faculties)
                    if(faculty.Id == facultyVM.Id)
                    {
                        Faculties.Remove(faculty);
                        return;
                    }
            }
        }
        void OpenWindowAddLevel(SettingFacultyVM facultyVM) => 
            _serviceView.Window<AddSettingLevelViewModel>(null, facultyVM).Modal();
        async void DeleteLevel(SettingLevelVM levelVM)
        {
            bool isDeleted = await _facultyRepository.Delete<SettingLevel>(levelVM.Id);
            if (isDeleted)
            {
                foreach (var faculty in Faculties)
                    foreach(var level in faculty.Levels)
                        if (level.Id == levelVM.Id)
                        {
                            faculty.Levels.Remove(level);
                            return;
                        }

            }
        }
        void OpenWindowAddDirection(SettingLevelVM levelVM) => 
            _serviceView.Window<AddSettingDirectionViewModel>(null, levelVM).Modal();
        async void DeleteDirection(SettingDirectionVM directionVM)
        {
            bool isDeleted = await _facultyRepository.Delete<SettingDirection>(directionVM.Id);
            if (isDeleted)
            {
                foreach (var faculty in Faculties)
                    foreach (var level in faculty.Levels)
                        foreach(var direction in level.Directions)
                            if (direction.Id == directionVM.Id)
                            {
                                level.Directions.Remove(direction);
                                return;
                            }
            }
        }
    }
}