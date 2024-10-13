using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.AdmissionsCampaign.Exams;
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
        IApplicantRepository _applicantRepository;
        ObservableCollection<ExamVM> _exams;
        Guid _id;
        bool _useDataBase;
        public AddExamViewModel(IServiceView serviceView, IApplicantRepository applicantRepository, 
            ObservableCollection<ExamVM> exams, Guid id = default, bool useDataBase = false)
        {
            _serviceView = serviceView;
            _applicantRepository = applicantRepository;
            _exams = exams;
            _id = id;
            _useDataBase = useDataBase;

            AddExamCommand = RaketaTCommand<ExamVM>.Launch(AddExam);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        void AddExam(ExamVM examVM)
        {
            bool isValidated = examVM.Validation();
            if (isValidated)
            {
                _exams.Add(examVM);
                _exams = null;
                if (_useDataBase)
                {
                    var exam = new Exam
                    {
                        Id = examVM.Id,
                        AcademicSubject = examVM.AcademicSubject,
                        DateExam = examVM.DateExam,
                        TimeExam = examVM.TimeExam,
                        LocationExam = examVM.LocationExam,
                        IsSpecial = examVM.IsSpecial,
                        SubjectScores = examVM.SubjectScores,
                        AdditionalInformation = examVM.AdditionalInformation,
                        ApplicantId = _id
                    };
                    _applicantRepository.Create<Exam>(exam);
                }
                _serviceView.Close<AddExamViewModel>();
            }
        }
        void CloseWindow() => _serviceView.Close<AddExamViewModel>();
    }
}