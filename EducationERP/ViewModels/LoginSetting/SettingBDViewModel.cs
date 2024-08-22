using EducationERP.Common.Components;
using Raketa;
using System.Windows;

namespace EducationERP.ViewModels.LoginSetting
{
    public class SettingBDViewModel : RaketaViewModel
    {
        string host = string.Empty;
        string port = string.Empty;
        string username = string.Empty;
        string password = string.Empty;
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
        public string Username
        {
            get => username;
            set => SetValue(ref username, value);
        }
        public string Password
        {
            get => password;
            set => SetValue(ref password, value);
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

        public RaketaCommand SaveConfigCommand { get; }
        public RaketaCommand RemoveConfigCommand { get; }
        public RaketaCommand ExitCommand { get; }

        IServiceView _serviceView;
        IConfig _config;
        public SettingBDViewModel(IServiceView serviceView, IConfig config)
        {
            _serviceView = serviceView;
            _config = config;

            GetConfigValues();

            SaveConfigCommand = RaketaCommand.Launch(SaveSettingBD);
            RemoveConfigCommand = RaketaCommand.Launch(RemoveSettingBD);
            ExitCommand = RaketaCommand.Launch(ExitSettingBD);
        }

        void SaveSettingBD()
        {
            //if (string.IsNullOrWhiteSpace(Host) || string.IsNullOrWhiteSpace(Port) || string.IsNullOrWhiteSpace(Database))
            //    MessageBox.Show("Заполните все поля!");
            //else _config.SaveConfig(Host, Port, Database, PathTemporaryData);
        }
        void RemoveSettingBD()
        {
            Host = string.Empty;
            Port = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            Database = string.Empty;
            PathTemporaryData = string.Empty;

            _config.RemoveConfig();
        }
        void GetConfigValues()
        {
            Host = _config.GetValueConnect("Host");
            Port = _config.GetValueConnect("Port");
            Username = _config.GetValueConnect("Username");
            Password = _config.GetValueConnect("Password");
            Database = _config.GetValueConnect("Database");
            PathTemporaryData = _config.GetValueConfig("PathTemporaryData");
        }
        void ExitSettingBD() => _serviceView.Close<SettingBDViewModel>();
    }
}