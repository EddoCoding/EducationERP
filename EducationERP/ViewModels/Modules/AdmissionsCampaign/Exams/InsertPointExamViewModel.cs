using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.AdmissionsCampaign.Exams;
using Raketa;
using System.Windows;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Exams
{
    public class InsertPointExamViewModel : RaketaViewModel
    {
        public string AcademicSubject { get; set; } = string.Empty;
        public int SubjectScores { get; set; }

        public RaketaCommand InsertPointExamCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        IApplicantRepository _applicantRepository;
        ExamVM _examVM;
        public InsertPointExamViewModel(IServiceView serviceView, IApplicantRepository applicantRepository, ExamVM examVM)
        {
            _serviceView = serviceView;
            _applicantRepository = applicantRepository;
            _examVM = examVM;

            AcademicSubject = examVM.AcademicSubject;
            SubjectScores = examVM.SubjectScores;

            InsertPointExamCommand = RaketaCommand.Launch(InsertPointExam);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        async void InsertPointExam()
        {
            if (SubjectScores < 0)
            {
                MessageBox.Show("Балл не может быть отрицательным!");
                return;
            }

            var exam = new Exam
            {
                Id = _examVM.Id,
                AcademicSubject = AcademicSubject,
                DateExam = _examVM.DateExam,
                TimeExam = _examVM.TimeExam,
                LocationExam = _examVM.LocationExam,
                IsSpecial = _examVM.IsSpecial,
                SubjectScores = SubjectScores,
                AdditionalInformation = _examVM.AdditionalInformation
            };
            bool isUpdated = await _applicantRepository.Update(exam);
            if (isUpdated) _examVM.SubjectScores = SubjectScores;
            CloseWindow();
        }
        void CloseWindow() => _serviceView.Close<InsertPointExamViewModel>();
    }
}