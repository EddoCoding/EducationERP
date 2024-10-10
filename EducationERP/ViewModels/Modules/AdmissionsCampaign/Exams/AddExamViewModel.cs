using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Exams
{
    public class AddExamViewModel : RaketaViewModel
    {
        public ExamVM ExamVM { get; set; } = new();

        public RaketaTCommand<ExamVM> AddExamCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ObservableCollection<ExamVM> _exams;
        public AddExamViewModel(IServiceView serviceView, ObservableCollection<ExamVM> exams)
        {
            _serviceView = serviceView;
            _exams = exams;

            AddExamCommand = RaketaTCommand<ExamVM>.Launch(AddExam);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        void AddExam(ExamVM examVM)
        {
            _exams.Add(examVM);
            _exams = null;
            _serviceView.Close<AddExamViewModel>();

            //var isValidated = distinctiveFeature.Validation();
            //if (isValidated)
            //{
            //    distinctiveFeatures.Add(distinctiveFeature);
            //    distinctiveFeatures = null;
            //    _serviceView.Close<DistinctiveFeatureViewModel>();
            //}
        }
        void CloseWindow() => _serviceView.Close<AddExamViewModel>();
    }
}