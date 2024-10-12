using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Models.Modules.AdmissionsCampaign;
using EducationERP.Models.Modules.AdmissionsCampaign.Directions;
using EducationERP.Models.Modules.AdmissionsCampaign.DistinctiveFeatures;
using EducationERP.Models.Modules.AdmissionsCampaign.Educations;
using EducationERP.Models.Modules.AdmissionsCampaign.Exams;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Directions;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.DistinctiveFeatures;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Education;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Exams;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign
{
    public class ChangeApplicantViewModel : RaketaViewModel
    {
        public VisualAddApplicant Visual { get; set; } = new();

        public RaketaCommand ExitCommand { get; set; }
        public RaketaCommand CitizenshipCommand { get; set; }

        //ДОКУМЕНТЫ
        public RaketaTCommand<ObservableCollection<DocumentBaseViewModel>> OpenWindowAddDocumentCommand { get; set; }
        public RaketaTCommand<DocumentBaseViewModel> DeleteDocumentCommand { get; set; }

        //ОБРАЗОВАНИЕ
        public RaketaTCommand<ObservableCollection<EducationBaseViewModel>> OpenWindowAddEducationCommand { get; set; }
        public RaketaTCommand<EducationBaseViewModel> DeleteEducationCommand { get; set; }

        //ЕГЭ
        public RaketaTCommand<ObservableCollection<EGEVM>> OpenWindowAddEGECommand { get; set; }
        public RaketaTCommand<EGEVM> DeleteEGECommand { get; set; }

        //ОТЛИЧИТЕЛЬНЫЕ ПРИЗНАКИ
        public RaketaTCommand<ObservableCollection<DistinctiveFeatureVM>> OpenWindowAddDistinctiveFeatureCommand { get; set; }
        public RaketaTCommand<DistinctiveFeatureVM> DeleteDistinctiveFeatureCommand { get; set; }

        //НАПРАВЛЕНИЯ ПОДГОТОВКИ
        public RaketaTCommand<ObservableCollection<SelectedDirectionVM>> OpenWindowAddDirectionCommand { get; set; }
        public RaketaTCommand<SelectedDirectionVM> DeleteSelectedDirectionVMCommand { get; set; }

        //ИСПЫТАНИЯ/ЭКЗАМЕНЫ
        public RaketaTCommand<ObservableCollection<ExamVM>> OpenWindowAddExamCommand { get; set; }
        public RaketaTCommand<ExamVM> DeleteExamCommand { get; set; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        IApplicantRepository _applicantRepository;
        public ApplicantVM ApplicantVM { get; set; }
        public ChangeApplicantViewModel(IServiceView serviceView, ITabControl tabControl, IApplicantRepository applicantRepository, ApplicantVM applicantVM)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;
            _applicantRepository = applicantRepository;
            ApplicantVM = applicantVM;

            CitizenshipCommand = RaketaCommand.Launch(Citizenship);

            OpenWindowAddDocumentCommand = RaketaTCommand<ObservableCollection<DocumentBaseViewModel>>.Launch(OpenWindowAddDocument);
            DeleteDocumentCommand = RaketaTCommand<DocumentBaseViewModel>.Launch(DeleteDocument);

            OpenWindowAddEducationCommand = RaketaTCommand<ObservableCollection<EducationBaseViewModel>>.Launch(OpenWindowAddEducation);
            DeleteEducationCommand = RaketaTCommand<EducationBaseViewModel>.Launch(DeleteEducation);

            OpenWindowAddEGECommand = RaketaTCommand<ObservableCollection<EGEVM>>.Launch(OpenWindowAddEGE);
            DeleteEGECommand = RaketaTCommand<EGEVM>.Launch(DeleteEGE);

            OpenWindowAddDistinctiveFeatureCommand = RaketaTCommand<ObservableCollection<DistinctiveFeatureVM>>.Launch(OpenWindowAddDistinctiveFeature);
            DeleteDistinctiveFeatureCommand = RaketaTCommand<DistinctiveFeatureVM>.Launch(DeleteDistinctiveFeature);

            DeleteSelectedDirectionVMCommand = RaketaTCommand<SelectedDirectionVM>.Launch(DeleteSelectedDirection);
            DeleteExamCommand = RaketaTCommand<ExamVM>.Launch(DeleteExam);
        }

        void Citizenship()
        {
            if (ApplicantVM.IsCitizenRus == true)
            {
                ApplicantVM.Citizenship = "Россия";
                Visual.IsEnabledTextBox = false;
            }
            else if (ApplicantVM.NotCitizen == true)
            {
                ApplicantVM.Citizenship = "Без гражданства";
                Visual.IsEnabledTextBox = false;
            }
            else
            {
                ApplicantVM.Citizenship = string.Empty;
                Visual.IsEnabledTextBox = true;
            }
        }

        void OpenWindowAddDocument(ObservableCollection<DocumentBaseViewModel> documents) =>
            _serviceView.Window<DocumentViewModel>(null, documents, ApplicantVM.Id, true).Modal();
        async void DeleteDocument(DocumentBaseViewModel document)
        {
            bool idDeleted = false;

            if (document is PassportViewModel)
                idDeleted = await _applicantRepository.Delete<Passport>(document.Id);
            else if (document is SnilsViewModel)
                idDeleted = await _applicantRepository.Delete<Snils>(document.Id);
            else if (document is InnViewModel)
                idDeleted = await _applicantRepository.Delete<Inn>(document.Id);
            else if (document is ForeignPassportViewModel)
                idDeleted = await _applicantRepository.Delete<ForeignPassport>(document.Id);

            ApplicantVM.Documents.Remove(document);
        }

        void OpenWindowAddEducation(ObservableCollection<EducationBaseViewModel> educations) =>
            _serviceView.Window<EducationDocViewModel>(null, educations, ApplicantVM.Id, true).Modal();
        async void DeleteEducation(EducationBaseViewModel education)
        {
            bool idDeleted = false;

            if (education is EducationNineViewModel)
                idDeleted = await _applicantRepository.Delete<EducationNine>(education.Id);
            else if (education is EducationElevenViewModel)
                idDeleted = await _applicantRepository.Delete<EducationEleven>(education.Id);
            else if (education is EducationSpoViewModel)
                idDeleted = await _applicantRepository.Delete<EducationSPO>(education.Id);
            else if (education is EducationBakViewModel)
                idDeleted = await _applicantRepository.Delete<EducationBak>(education.Id);
            else if (education is EducationMagViewModel)
                idDeleted = await _applicantRepository.Delete<EducationMag>(education.Id);
            else if (education is EducationAspViewModel)
                idDeleted = await _applicantRepository.Delete<EducationAsp>(education.Id);

            ApplicantVM.Educations.Remove(education);
        }

        void OpenWindowAddEGE(ObservableCollection<EGEVM> eges) =>
            _serviceView.Window<EGEViewModel>(null, eges, ApplicantVM.Id, true).Modal();
        async void DeleteEGE(EGEVM ege)
        {
            bool idDeleted = await _applicantRepository.Delete<EGE>(ege.Id);
            ApplicantVM.EGES.Remove(ege);
        }

        void OpenWindowAddDistinctiveFeature(ObservableCollection<DistinctiveFeatureVM> distinctiveFeatures) =>
            _serviceView.Window<DistinctiveFeatureViewModel>(null, distinctiveFeatures, ApplicantVM.Id, true).Modal();
        async void DeleteDistinctiveFeature(DistinctiveFeatureVM distinctiveFeature)
        {
            bool idDeleted = await _applicantRepository.Delete<DistinctiveFeature>(distinctiveFeature.Id);
            ApplicantVM.DistinguishingFeatures.Remove(distinctiveFeature);
        }

        async void DeleteSelectedDirection(SelectedDirectionVM selectedDirection)
        {
            bool idDeleted = await _applicantRepository.Delete<SelectedDirection>(selectedDirection.Id);
            ApplicantVM.DirectionsOfTraining.Remove(selectedDirection);
        }

        async void DeleteExam(ExamVM exam)
        {
            bool idDeleted = await _applicantRepository.Delete<Exam>(exam.Id);
            ApplicantVM.Exams.Remove(exam);
        }

        void CloseTab()
        {
            ApplicantVM = null;
            _tabControl.RemoveTab();
        }
    }
}