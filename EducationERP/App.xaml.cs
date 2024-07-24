using EducationERP.Modules.Components.Notification.View;
using EducationERP.Modules.Components.Notification.VM;
using EducationERP.Modules.Login.View;
using EducationERP.Modules.Login.VM;
using Raketa.IoC;
using System.Windows;

namespace EducationERP
{
    public partial class App : Application
    {
        IContainer _container;
        IServiceView _serviceView;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _container = new Container();
            _serviceView = new ServiceView(_container);

            RegisterView();
            RegisterDependency();

            _serviceView.ShowView<LoginViewModel>();
        }

        void RegisterView()
        {
            _serviceView.RegisterView<LoginWindow, LoginViewModel>();
            _serviceView.RegisterView<SettingBDWindow, SettingBDViewModel>();
            _serviceView.RegisterView<Note, NoteViewModel>();
        }

        void RegisterDependency()
        {
            _container.SingleRegister<IServiceView>(_serviceView);
        }
    }
}