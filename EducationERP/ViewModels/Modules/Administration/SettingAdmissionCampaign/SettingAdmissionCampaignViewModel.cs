using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class SettingAdmissionCampaignViewModel : RaketaViewModel
    {
        public ObservableCollection<SettingFacultyVM> Faculties { get; set; } = new();

        public RaketaTCommand<ObservableCollection<SettingFacultyVM>> OpenWindowAddFacultyCommand { get; set; }
        public RaketaTCommand<SettingFacultyVM> DeleteFacultyCommand { get; set; }
        public RaketaTCommand<SettingFacultyVM> OpenWindowAddLevelCommand { get; set; }
        public RaketaTCommand<SettingLevelVM> DeleteLevelCommand { get; set; }
        public RaketaTCommand<SettingLevelVM> OpenWindowAddDirectionCommand { get; set; }
        public RaketaTCommand<SettingDirectionVM> DeleteDirectionCommand { get; set; }

        IServiceView _serviceView;
        ISettingFacultyRepository _facultyRepository;
        public SettingAdmissionCampaignViewModel(IServiceView serviceView, ISettingFacultyRepository facultyRepository)
        {
            _serviceView = serviceView;
            _facultyRepository = facultyRepository;

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

            OpenWindowAddFacultyCommand = RaketaTCommand<ObservableCollection<SettingFacultyVM>>.Launch(OpenWindowAddFaculty);
            DeleteFacultyCommand = RaketaTCommand<SettingFacultyVM>.Launch(DeleteFaculty);
            OpenWindowAddLevelCommand = RaketaTCommand<SettingFacultyVM>.Launch(OpenWindowAddLevel);
            DeleteLevelCommand = RaketaTCommand<SettingLevelVM>.Launch(DeleteLevel);
            OpenWindowAddDirectionCommand = RaketaTCommand<SettingLevelVM>.Launch(OpenWindowAddDirection);
            DeleteDirectionCommand = RaketaTCommand<SettingDirectionVM>.Launch(DeleteDirection);
        }

        void OpenWindowAddFaculty(ObservableCollection<SettingFacultyVM> faculties) => 
            _serviceView.Window<AddSettingFacultyViewModel>(null, faculties).Modal();
        void DeleteFaculty(SettingFacultyVM facultyVM)
        {
            bool isDeleted = _facultyRepository.Delete<SettingFaculty>(facultyVM.Id);
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
        void DeleteLevel(SettingLevelVM levelVM)
        {
            bool isDeleted = _facultyRepository.Delete<SettingLevel>(levelVM.Id);
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
        void DeleteDirection(SettingDirectionVM directionVM)
        {
            bool isDeleted = _facultyRepository.Delete<SettingDirection>(directionVM.Id);
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