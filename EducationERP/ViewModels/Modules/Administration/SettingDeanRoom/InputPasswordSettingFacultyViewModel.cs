using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using Raketa;
using System.Windows;

namespace EducationERP.ViewModels.Modules.Administration.SettingDeanRoom
{
    public class InputPasswordSettingFacultyViewModel : RaketaViewModel
    {
        string passwordFaculty = string.Empty;

        public string PasswordFaculty
        {
            get => passwordFaculty;
            set => SetValue(ref passwordFaculty, value);
        }

        public RaketaTCommand<string> GetAccessFacultyCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        IStructEducationRepository _structEducationRepository;
        public InputPasswordSettingFacultyViewModel(IServiceView serviceView, ITabControl tabControl, IStructEducationRepository structEducationRepository)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;
            _structEducationRepository = structEducationRepository;

            GetAccessFacultyCommand = RaketaTCommand<string>.Launch(GetAccessFaculty);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        async void GetAccessFaculty(string passwordFaculty)
        {
            if (String.IsNullOrWhiteSpace(passwordFaculty))
            {
                MessageBox.Show("Введите пароль!");
                return;
            }

            Guid id = await _structEducationRepository.GetAccessFaculty(passwordFaculty);
            if (id != Guid.Empty)
            {
                _tabControl.CreateTab<SettingDeanRoomViewModel>("Настройка деканата", null, id);
                CloseWindow();
            }
        }
        void CloseWindow() => _serviceView.Close<InputPasswordSettingFacultyViewModel>();
    }
}