﻿using EducationERP.Common.Components.Repositories;
using EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Directions
{
    public class AddDirectionViewModel : RaketaViewModel
    {

        SettingFacultyVM facultyVM = new();
        SettingLevelVM levelVM = new();

        public SelectedDirectionVM SelectedDirectionVM { get; set; } = new();
        public ObservableCollection<SettingFacultyVM> Faculties { get; set; } = new();
        public SettingFacultyVM FacultyVM
        {
            get => facultyVM;
            set => SetValue(ref facultyVM, value);
        }
        public SettingLevelVM LevelVM
        {
            get => levelVM;
            set => SetValue(ref levelVM, value);
        }
        public SettingDirectionVM DirectionVM { get; set; } = new();

        public RaketaTCommand<SelectedDirectionVM> AddDirectionCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ObservableCollection<SelectedDirectionVM> _directions;
        public AddDirectionViewModel(IServiceView serviceView, ISettingFacultyRepository facultyRepository, ObservableCollection<SelectedDirectionVM> directions)
        {
            _serviceView = serviceView;
            _directions = directions;

            //Получаю факультеты с иерархией данных(уровни и направления)
            foreach (var faculty in facultyRepository.Read())
            {
                var facultyVM = new SettingFacultyVM
                {
                    Id = faculty.Id,
                    NameFaculty = faculty.NameFaculty,
                    Levels = new()
                };
                foreach (var level in faculty.Levels)
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

            AddDirectionCommand = RaketaTCommand<SelectedDirectionVM>.Launch(AddDirection);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        void AddDirection(SelectedDirectionVM selectedDirectionVM)
        {
            if(FacultyVM != null || LevelVM != null || DirectionVM != null)
            {
                selectedDirectionVM.NameFaculty = FacultyVM.NameFaculty;
                selectedDirectionVM.NameLevel = LevelVM.NameLevel;
                selectedDirectionVM.CodeDirection = DirectionVM.CodeDirection;
                selectedDirectionVM.NameDirection = DirectionVM.NameDirection;
                selectedDirectionVM.CodeProfile = DirectionVM.CodeProfile;
                selectedDirectionVM.NameProfile = DirectionVM.NameProfile;
                selectedDirectionVM.NameFormEducation = DirectionVM.NameFormEducation;
                selectedDirectionVM.NameFormPayment = DirectionVM.NameFormPayment;
            }
            
            bool isValidated = selectedDirectionVM.Validation();
            if (isValidated)
            {
                _directions.Add(selectedDirectionVM);
                _directions = null;
                _serviceView.Close<AddDirectionViewModel>();
            }
        }
        void CloseWindow() => _serviceView.Close<AddDirectionViewModel>();
    }
}