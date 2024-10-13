using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.AdmissionsCampaign.Exams;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Exams
{
    public class EGEViewModel : RaketaViewModel
    {
        public EGEVM EGE { get; set; } = new();

        public ObservableCollection<EGEVM> _eges { get; set; }

        public RaketaTCommand<EGEVM> AddEGECommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        IApplicantRepository _applicantRepository;
        Guid _id;
        bool _useDataBase;
        public EGEViewModel(IServiceView serviceView, IApplicantRepository applicantRepository, 
            ObservableCollection<EGEVM> eges, Guid id = default, bool useDataBase = false)
        {
            _serviceView = serviceView;
            _applicantRepository = applicantRepository;
            _eges = eges;
            _id = id;
            _useDataBase = useDataBase;

            AddEGECommand = RaketaTCommand<EGEVM>.Launch(AddEGE);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        void AddEGE(EGEVM Ege)
        {
            var isValidated = Ege.Validation();
            if (isValidated)
            {
                _eges.Add(Ege);
                _eges = null;
                if (_useDataBase)
                {
                    var ege = new EGE
                    {
                        Id = Ege.Id,
                        AcademicSubject = Ege.AcademicSubject,
                        SubjectScores = Ege.SubjectScores,
                        ApplicantId = _id
                    };
                    _applicantRepository.Create<EGE>(ege);
                }
                _serviceView.Close<EGEViewModel>();
            }
        }
        void CloseWindow() => _serviceView.Close<EGEViewModel>();
    }
}