using EducationERP.Common.Components;
using EducationERP.Modules.Login.View;
using EducationERP.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        }

        void RegisterDependency()
        {
            _container.RegisterSingleton<DbContext>(new DataContext());
        }
    }
}