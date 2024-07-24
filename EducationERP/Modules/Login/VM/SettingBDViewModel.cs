using EducationERP.Modules.Components.Notification.VM;
using Raketa;
using Raketa.Commands;
using Raketa.IoC;
using System.Configuration;
using System.Windows;

namespace EducationERP.Modules.Login.VM
{
    public class SettingBDViewModel : ViewModel
    {
        string host = string.Empty;
        string port = string.Empty;
        string database = string.Empty;

        public string Host
        {
            get => host;
            set => SetValue(ref host, value);
        }
        public string Port
        {
            get => port;
            set => SetValue(ref port, value);
        }
        public string Database
        {
            get => database;
            set => SetValue(ref database, value);
        }

        public RaketaCommand SaveSettingBDCommand { get; }
        public RaketaCommand DeleteSettingBDCommand { get; }
        public RaketaCommand ExitCommand { get; }

        IServiceView _serviceView;
        public SettingBDViewModel(IServiceView serviceView, Action exitWindow)
        {
            _serviceView = serviceView;

            Host = ConfigurationManager.AppSettings["Host"];
            Port = ConfigurationManager.AppSettings["Port"];
            Database = ConfigurationManager.AppSettings["Database"];

            SaveSettingBDCommand = RaketaCommand.Launch(SaveSettingBD);
            DeleteSettingBDCommand = RaketaCommand.Launch(DeleteSettingBD);
            ExitCommand = RaketaCommand.Launch(exitWindow);
        }

        void SaveSettingBD()
        {
            if (String.IsNullOrWhiteSpace(Host) || String.IsNullOrWhiteSpace(Port) || String.IsNullOrWhiteSpace(Database))
                _serviceView.ShowView<NoteViewModel>("Заполните все поля!");
            else
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["Host"].Value = Host;
                config.AppSettings.Settings["Port"].Value = Port;
                config.AppSettings.Settings["Database"].Value = Database;

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                _serviceView.ShowView<NoteViewModel>("Настройки сохранены!");
            }
        }
        void DeleteSettingBD()
        {
            Host = string.Empty;
            Port = string.Empty;
            Database = string.Empty;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Host"].Value = Host;
            config.AppSettings.Settings["Port"].Value = Port;
            config.AppSettings.Settings["Database"].Value = Database;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            _serviceView.ShowView<NoteViewModel>("Настройки удалены из файла конфигурации!");
        }
    }
}