using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Exams
{
    public class EGEViewModel : RaketaViewModel
    {
        public EGEVM EGE { get; set; } = new();

        ObservableCollection<EGEVM> _eges;

        public RaketaTCommand<EGEVM> AddEGECommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        public EGEViewModel(IServiceView serviceView, ObservableCollection<EGEVM> EGES)
        {
            _serviceView = serviceView;
            _eges = EGES;

            AddEGECommand = RaketaTCommand<EGEVM>.Launch(AddEGE);
            ExitCommand = RaketaCommand.Launch(CloseWindow);

        }

        void AddEGE(EGEVM ege)
        {
            var isValidated = ege.Validation();
            if (isValidated)
            {
                _eges.Add(ege);
                _eges = null;
                _serviceView.Close<EGEViewModel>();
            }
        }
        void CloseWindow() => _serviceView.Close<EGEViewModel>();
    }
}