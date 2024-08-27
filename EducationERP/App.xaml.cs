using EducationERP.Common.Components;
using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Modules.Login.View;
using EducationERP.ViewModels;
using EducationERP.ViewModels.Login;
using EducationERP.ViewModels.Modules.Administration;
using EducationERP.ViewModels.Modules.Administration.ControlUsers;
using EducationERP.Views;
using EducationERP.Views.Modules.Administration;
using EducationERP.Views.Modules.Administration.ControlUsers;
using Raketa;
using System.Windows;

namespace EducationERP
{
    public partial class App : Application
    {
        IContainerDi _container = new Container();
        IServiceView _serviceView;
        IConfig _config;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _serviceView = _container.GetDependency<IServiceView>();
            RegisterView();
            RegisterDependency();

            _config = _container.GetDependency<IConfig>();

            if(_config.GetIsConfigured()) _serviceView.Window<LoginViewModel>().NonModal();
            else _serviceView.Window<EducationViewModel>(default, "", "").NonModal();
        }

        void RegisterView()
        {
            _serviceView.RegisterTypeView<LoginViewModel, LoginWindow>();
            _serviceView.RegisterTypeView<EducationViewModel, EducationWindow>();
            _serviceView.RegisterTypeView<AddUserViewModel, WindowAddUser>();
            _serviceView.RegisterTypeView<AdministrationViewModel, AdministrationView>();
        }

        void RegisterDependency()
        {
            _container.RegisterSingleton<DataContext, DataContext>();
            _container.RegisterTransient<Config, IConfig>();
            _container.RegisterSingleton<MainTabControl, ITabControl>();
            _container.RegisterSingleton<UserRepository, IUserRepository>();
        }
    }
}