using EducationERP.Common.Components;
using EducationERP.Common.Components.Services;
using EducationERP.Modules.Login.View;
using EducationERP.ViewModels;
using EducationERP.ViewModels.Login;
using EducationERP.ViewModels.LoginSetting;
using EducationERP.Views;
using Raketa;
using System.Windows;

namespace EducationERP
{
    public partial class App : Application
    {
        IContainerDi _container = new Container();
        IServiceView _serviceView;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _serviceView = _container.GetDependency<IServiceView>();

            RegisterView();
            RegisterDependency();

            _serviceView.Window<LoginViewModel>().NonModal();
        }

        void RegisterView()
        {
            _serviceView.RegisterTypeView<LoginViewModel, LoginWindow>();
            _serviceView.RegisterTypeView<SettingBDViewModel, SettingBDWindow>();
            _serviceView.RegisterTypeView<EducationViewModel, EducationWindow>();
            _serviceView.RegisterTypeView<UserControlViewModel, UserControl1>();
        }

        void RegisterDependency()
        {
            _container.RegisterSingleton<DataContext, DataContext>();
            _container.RegisterTransient<Config, IConfig>();
            _container.RegisterSingleton<MainTabControl, ITabControl>();
        }
    }
}