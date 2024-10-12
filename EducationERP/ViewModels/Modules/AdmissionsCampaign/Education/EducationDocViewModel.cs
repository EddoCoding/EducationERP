using EducationERP.Common.Components.Repositories;
using EducationERP.Models.Modules.AdmissionsCampaign;
using EducationERP.Models.Modules.AdmissionsCampaign.Educations;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Education
{
    public class EducationDocViewModel : RaketaViewModel
    {
        ObservableCollection<EducationBaseViewModel> _educations;

        public EducationBaseViewModel[] Educations { get; set; } =
        {
            new EducationNineViewModel(),
            new EducationElevenViewModel(),
            new EducationSpoViewModel(),
            new EducationBakViewModel(),
            new EducationMagViewModel(),
            new EducationAspViewModel()
        }; // ОБРАЗОВАНИЕ

        EducationBaseViewModel selectedEducation;
        public EducationBaseViewModel SelectedEducation
        {
            get => selectedEducation;
            set => SetValue(ref selectedEducation, value);
        }

        public RaketaTCommand<EducationBaseViewModel> AddEducationCommand { get; set; }
        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView; 
        IApplicantRepository _applicantRepository;
        Guid _id;
        bool _useDataBase;
        public EducationDocViewModel(IServiceView serviceView, IApplicantRepository applicantRepository, 
            ObservableCollection<EducationBaseViewModel> educations, Guid id = default, bool useDataBase = false)
        {
            _serviceView = serviceView;
            _applicantRepository = applicantRepository;
            _educations = educations;
            _id = id;
            _useDataBase = useDataBase;

            AddEducationCommand = RaketaTCommand<EducationBaseViewModel>.Launch(AddEducation);
            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        async void AddEducation(EducationBaseViewModel education)
        {
            var isValidated = education.Validation();
            if (isValidated)
            {
                _educations.Add(education);
                _educations = null;
                if (_useDataBase)
                {
                    if (education is EducationNineViewModel nineVM)
                    {
                        var nine = new EducationNine
                        {
                            Id = nineVM.Id,
                            TypeEducation = nineVM.TypeEducation,
                            IdentificationDocument = nineVM.IdentificationDocument,
                            IssuedBy = nineVM.IssuedBy,
                            DateOfIssue = nineVM.DateOfIssue,
                            Honours = nineVM.Honours,
                            CodeSeriesNumber = nineVM.CodeSeriesNumber,
                            AdditionalInformation = nineVM.AdditionalInformation,
                            ApplicantId = _id
                        };
                        await _applicantRepository.Create<EducationNine>(nine);
                    }
                    else if (education is EducationElevenViewModel elevenVM)
                    {
                        var eleven = new EducationEleven
                        {
                            Id = elevenVM.Id,
                            TypeEducation = elevenVM.TypeEducation,
                            IdentificationDocument = elevenVM.IdentificationDocument,
                            IssuedBy = elevenVM.IssuedBy,
                            DateOfIssue = elevenVM.DateOfIssue,
                            Honours = elevenVM.Honours,
                            CodeSeriesNumber = elevenVM.CodeSeriesNumber,
                            AdditionalInformation = elevenVM.AdditionalInformation,
                            ApplicantId = _id
                        };
                        await _applicantRepository.Create<EducationEleven>(eleven);
                    }
                    else if (education is EducationSpoViewModel spoVM)
                    {
                        var spo = new EducationSPO
                        {
                            Id = spoVM.Id,
                            TypeEducation = spoVM.TypeEducation,
                            IdentificationDocument = spoVM.IdentificationDocument,
                            IssuedBy = spoVM.IssuedBy,
                            DateOfIssue = spoVM.DateOfIssue,
                            Honours = spoVM.Honours,
                            FormOfEducation = spoVM.FormOfEducation,
                            RegistrationNumber = spoVM.RegistrationNumber,
                            DiplomaSeries = spoVM.DiplomaSeries,
                            DiplomaNumber = spoVM.DiplomaNumber,
                            SupplementSeries = spoVM.SupplementSeries,
                            SupplementNumber = spoVM.SupplementNumber,
                            AdditionalInformation = spoVM.AdditionalInformation,
                            ApplicantId = _id
                        };
                        await _applicantRepository.Create<EducationSPO>(spo);
                    }
                    else if (education is EducationBakViewModel bakVM)
                    {
                        var bak = new EducationBak
                        {
                            Id = bakVM.Id,
                            TypeEducation = bakVM.TypeEducation,
                            IdentificationDocument = bakVM.IdentificationDocument,
                            IssuedBy = bakVM.IssuedBy,
                            DateOfIssue = bakVM.DateOfIssue,
                            Honours = bakVM.Honours,
                            FormOfEducation = bakVM.FormOfEducation,
                            RegistrationNumber = bakVM.RegistrationNumber,
                            DiplomaSeries = bakVM.DiplomaSeries,
                            DiplomaNumber = bakVM.DiplomaNumber,
                            SupplementSeries = bakVM.SupplementSeries,
                            SupplementNumber = bakVM.SupplementNumber,
                            AdditionalInformation = bakVM.AdditionalInformation,
                            ApplicantId = _id
                        };
                        await _applicantRepository.Create<EducationBak>(bak);
                    }
                    else if (education is EducationMagViewModel magVM)
                    {
                        var mag = new EducationMag
                        {
                            Id = magVM.Id,
                            TypeEducation = magVM.TypeEducation,
                            IdentificationDocument = magVM.IdentificationDocument,
                            IssuedBy = magVM.IssuedBy,
                            DateOfIssue = magVM.DateOfIssue,
                            Honours = magVM.Honours,
                            FormOfEducation = magVM.FormOfEducation,
                            RegistrationNumber = magVM.RegistrationNumber,
                            DiplomaSeries = magVM.DiplomaSeries,
                            DiplomaNumber = magVM.DiplomaNumber,
                            SupplementSeries = magVM.SupplementSeries,
                            SupplementNumber = magVM.SupplementNumber,
                            AdditionalInformation = magVM.AdditionalInformation,
                            ApplicantId = _id
                        };
                        await _applicantRepository.Create<EducationMag>(mag);
                    }
                    else if (education is EducationAspViewModel aspVM)
                    {
                        var asp = new EducationAsp
                        {
                            Id = aspVM.Id,
                            TypeEducation = aspVM.TypeEducation,
                            IdentificationDocument = aspVM.IdentificationDocument,
                            IssuedBy = aspVM.IssuedBy,
                            DateOfIssue = aspVM.DateOfIssue,
                            Honours = aspVM.Honours,
                            FormOfEducation = aspVM.FormOfEducation,
                            RegistrationNumber = aspVM.RegistrationNumber,
                            DiplomaSeries = aspVM.DiplomaSeries,
                            DiplomaNumber = aspVM.DiplomaNumber,
                            SupplementSeries = aspVM.SupplementSeries,
                            SupplementNumber = aspVM.SupplementNumber,
                            AdditionalInformation = aspVM.AdditionalInformation,
                            ApplicantId = _id
                        };
                        await _applicantRepository.Create<EducationAsp>(asp);
                    }
                }
                _serviceView.Close<EducationDocViewModel>();
            }
        }
        void CloseWindow() => _serviceView.Close<EducationDocViewModel>();
    }
}