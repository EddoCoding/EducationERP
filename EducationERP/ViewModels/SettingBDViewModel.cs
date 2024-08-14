using Raketa;
using System.Configuration;
using System.Windows;

namespace EducationERP.ViewModels
{
    public class SettingBDViewModel : RaketaViewModel
    {
        string host = string.Empty;
        string port = string.Empty;
        string database = string.Empty;
        string pathTemporaryData = string.Empty;

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
        public string PathTemporaryData
        {
            get => pathTemporaryData;
            set => SetValue(ref pathTemporaryData, value);
        }

        public RaketaCommand SaveSettingBDCommand { get; }
        public RaketaCommand DeleteSettingBDCommand { get; }
        public RaketaCommand ExitCommand { get; }

        IServiceView _serviceView;
        public SettingBDViewModel(IServiceView serviceView)
        {
            _serviceView = serviceView;

            Host = ConfigurationManager.AppSettings["Host"];
            Port = ConfigurationManager.AppSettings["Port"];
            Database = ConfigurationManager.AppSettings["Database"];
            PathTemporaryData = ConfigurationManager.AppSettings["PathTemporaryData"];

            SaveSettingBDCommand = RaketaCommand.Launch(SaveSettingBD);
            DeleteSettingBDCommand = RaketaCommand.Launch(DeleteSettingBD);
            ExitCommand = RaketaCommand.Launch(() =>
            {
                _serviceView.Close<SettingBDViewModel>();
            });
        }

        void SaveSettingBD()
        {
            if (string.IsNullOrWhiteSpace(Host) || string.IsNullOrWhiteSpace(Port) || string.IsNullOrWhiteSpace(Database))
                MessageBox.Show("Заполните все поля!");
            else
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["Host"].Value = Host;
                config.AppSettings.Settings["Port"].Value = Port;
                config.AppSettings.Settings["Database"].Value = Database;
                config.AppSettings.Settings["PathTemporaryData"].Value = PathTemporaryData;

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                MessageBox.Show("Настройки сохранены!");
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
            config.AppSettings.Settings["PathTemporaryData"].Value = PathTemporaryData;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("Настройки удалены!");
        }
    }
}