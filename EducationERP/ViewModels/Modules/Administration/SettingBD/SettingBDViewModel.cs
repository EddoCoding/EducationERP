﻿using EducationERP.Common.Components;
using EducationERP.Common.Components.Services;
using EducationERP.Models.Modules.Administration.SettingUser;
using Raketa;

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

        public RaketaCommand ExitCommand { get; }
        public RaketaCommand SaveConfigCommand { get; }
        public RaketaCommand RemoveConfigCommand { get; }
        public RaketaCommand CreateISCommand { get; }

        IServiceView _serviceView;
        IConfig _config;
        DataContext _context;
        ITabControl _tabControl;
        public SettingBDViewModel(IServiceView serviceView, IConfig config, DataContext context, ITabControl tabControl)
        {
            _serviceView = serviceView;
            _config = config;
            _context = context;
            _tabControl = tabControl;

            GetConfigValues();

            SaveConfigCommand = RaketaCommand.Launch(SaveConfig);
            RemoveConfigCommand = RaketaCommand.Launch(RemoveConfig);
            CreateISCommand = RaketaCommand.Launch(CreateIS);
            ExitCommand = RaketaCommand.Launch(CloseTab);
        }

        void SaveConfig() => _config.SaveConfig(Host, Port, Username, Password, Database, PathTemporaryData);
        void RemoveConfig()
        {
            Host = string.Empty;
            Port = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            Database = string.Empty;
            PathTemporaryData = string.Empty;

            _config.RemoveConfig();
        }
        void CreateIS()
        {
            if (_context.ApplyMigrate())
            {
                _context.Users.Add(new User()
                {
                    SurName = "Администратор",
                    Identifier = "qwe",
                    Password = "rty",
                    ModuleAdministration = true
                });
                _context.SaveChanges();
            }
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
        void CloseTab() => _tabControl.RemoveTab();
    }
}