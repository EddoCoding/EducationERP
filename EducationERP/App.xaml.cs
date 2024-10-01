﻿using EducationERP.Common.Components;
using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Modules.Login.View;
using EducationERP.ViewModels;
using EducationERP.ViewModels.Login;
using EducationERP.ViewModels.Modules.Administration;
using EducationERP.ViewModels.Modules.Administration.ControlUsers;
using EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign;
using EducationERP.ViewModels.Modules.AdmissionsCampaign;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.DistinctiveFeatures;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Education;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Exams;
using EducationERP.Views;
using EducationERP.Views.Modules.Administration;
using EducationERP.Views.Modules.Administration.ControlUsers;
using EducationERP.Views.Modules.Administration.SettingAdmissionCampaign;
using EducationERP.Views.Modules.AdmissionsCampaign;
using EducationERP.Views.Modules.AdmissionsCampaign.DistinctiveFeatures;
using EducationERP.Views.Modules.AdmissionsCampaign.Documents;
using EducationERP.Views.Modules.AdmissionsCampaign.Education;
using EducationERP.Views.Modules.AdmissionsCampaign.Exams;
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
            _serviceView.RegisterTypeView<ChangeUserViewModel, WindowChangeUser>();
            _serviceView.RegisterTypeView<AdministrationViewModel, AdministrationView>();
            _serviceView.RegisterTypeView<AdmissionsCampaignViewModel, AdmissionsCampaignView>();
            _serviceView.RegisterTypeView<AddApplicantViewModel, AddApplicantView>();
            _serviceView.RegisterTypeView<DocumentViewModel, DocumentWindow>();
            _serviceView.RegisterTypeView<ChangeDocumentViewModel, ChangeDocumentWindow>();
            _serviceView.RegisterTypeView<EducationDocViewModel, EducationDocWindow>();
            _serviceView.RegisterTypeView<ChangeEducationDocViewModel, ChangeEducationDocWindow>();
            _serviceView.RegisterTypeView<EGEViewModel, EGEWindow>();
            _serviceView.RegisterTypeView<DistinctiveFeatureViewModel, DistinctiveFeaturesWindow>();
            _serviceView.RegisterTypeView<AddSettingLevelViewModel, AddSettingLevelWindow>();
            _serviceView.RegisterTypeView<AddSettingDirectionViewModel, AddSettingDirectionWindow>();
            _serviceView.RegisterTypeView<AddSettingProfileViewModel, AddSettingProfileWindow>();
            _serviceView.RegisterTypeView<AddSettingFormViewModel, AddSettingFormWindow>();
        }

        void RegisterDependency()
        {
            _container.RegisterSingleton<DataContext, DataContext>();
            _container.RegisterTransient<Config, IConfig>();
            _container.RegisterSingleton<UserSystem, UserSystem>();
            _container.RegisterSingleton<MainTabControl, ITabControl>();
            _container.RegisterSingleton<UserRepository, IUserRepository>();
            _container.RegisterTransient<ApplicantRepository, IApplicantRepository>();
            _container.RegisterTransient<LevelRepositor, ILevelRepository>();
        }
    }
}