using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class AddSettingFormViewModel : RaketaViewModel
    {
        public SettingFormVM FormVM { get; set; } = new();

        public RaketaTCommand<string> SelectFormCommand { get; set; }
        public RaketaTCommand<SettingFormVM> AddFormCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ILevelRepository _levelRepository;
        SettingProfileVM _profileVM;
        public AddSettingFormViewModel(IServiceView serviceView, ILevelRepository levelRepository, SettingProfileVM profileVM)
        {
            _serviceView = serviceView;
            _levelRepository = levelRepository;
            _profileVM = profileVM;

            SelectFormCommand = RaketaTCommand<string>.Launch(SelectForm);
            AddFormCommand = RaketaTCommand<SettingFormVM>.Launch(AddForm);
            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        void SelectForm(string form) => FormVM.NameForm = form;
        void AddForm(SettingFormVM formVM)
        {
            var form = new SettingForm 
            {
                Id = formVM.Id,
                NameForm = formVM.NameForm,
                SettingProfileId = _profileVM.Id
            };
            bool isAdded = _levelRepository.CreateForm(form);
            if (isAdded)
            {
                _profileVM.Forms.Add(formVM);
                _serviceView.Close<AddSettingFormViewModel>();
            }
        }
        void ExitLogin() => _serviceView.Close<AddSettingFormViewModel>();
    }
}