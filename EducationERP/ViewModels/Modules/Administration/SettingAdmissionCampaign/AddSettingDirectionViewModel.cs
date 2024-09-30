using EducationERP.Common.Components.Repositories;
using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class AddSettingDirectionViewModel : RaketaViewModel
    {
        //public EducationalDirectionTrainingVM Direction { get; set; } = new();

        //public RaketaTCommand<EducationalDirectionTrainingVM> AddDirectionCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ILevelRepository _levelRepository;
        Guid _id;
        public AddSettingDirectionViewModel(IServiceView serviceView, ILevelRepository levelRepository, Guid id)
        {
            _serviceView = serviceView;
            _levelRepository = levelRepository;
            _id = id;

            //AddDirectionCommand = RaketaTCommand<EducationalDirectionTrainingVM>.Launch(AddDirection);
            ExitCommand = RaketaCommand.Launch(ExitLogin);
        }

        //async Task AddDirection(EducationalDirectionTrainingVM direction)
        //{
        //
        //}
        void ExitLogin() => _serviceView.Close<AddSettingDirectionViewModel>();
    }
}