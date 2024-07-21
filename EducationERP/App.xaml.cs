using EducationERP.Modules.Login.View;
using EducationERP.Modules.Login.VM;
using Raketa.IoC;
using System.Windows;

namespace EducationERP
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IContainer container = new Container();
            
            IServiceView serviceView = new ServiceView(container);
            serviceView.RegisterView<LoginWindow, LoginViewModel>();
            
            serviceView.ShowView<LoginViewModel>();

            #region MyRegion

            //var server = "й";
            //var database = "w";
            //var userId = "e";
            //var password = "r";
            //
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //
            //if (config.ConnectionStrings.ConnectionStrings["ssss"] != null)
            //{
            //    config.ConnectionStrings.ConnectionStrings["ssss"].ConnectionString =
            //        $"Data Source={server};Initial Catalog={database};User ID={userId};Password={password}";
            //}
            //else
            //{
            //    config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings
            //    {
            //        Name = "ssss",
            //        ConnectionString = $"Data Source={server};Initial Catalog={database};User ID={userId};Password={password}",
            //        ProviderName = "System.Data.SqlClient"
            //    });
            //}
            //
            //config.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.RefreshSection("connectionStrings");
            //
            //MessageBox.Show("Данные успешно сохранены в конфигурацию.");
            #endregion
        }
    }
}