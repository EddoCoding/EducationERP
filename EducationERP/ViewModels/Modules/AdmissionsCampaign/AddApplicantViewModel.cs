﻿using EducationERP.Common.Components.Repositories;
using EducationERP.Common.Components.Services;
using EducationERP.Common.ToolsDev;
using EducationERP.Models;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Education;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign
{
    public  class AddApplicantViewModel : RaketaViewModel
    {
        public Applicant Applicant { get; set; } = new();
        public ApplicantVM ApplicantVM { get; set; } = new();
        public VisualAddApplicant Visual { get; set; } = new();

        public ObservableCollection<DocumentBaseViewModel> Documents { get; set; } = new(); 
        public ObservableCollection<EducationBaseViewModel> Educations { get; set; } = new(); 


        public RaketaCommand ExitCommand { get; set; }
        public RaketaCommand CitizenshipCommand { get; set; }
        public RaketaCommand CreatePersonalFileCommand { get; set; }

        public RaketaCommand AddDocumentCommand { get; set; }
        public RaketaTCommand<DocumentBaseViewModel> ChangeDocumentCommand { get; set; }
        public RaketaTCommand<DocumentBaseViewModel> DeleteDocumentCommand { get; set; }

        public RaketaCommand AddEducationCommand { get; set; }
        public RaketaTCommand<EducationBaseViewModel> ChangeEducationCommand { get; set; }
        public RaketaTCommand<EducationBaseViewModel> DeleteEducationCommand { get; set; }

        IServiceView _serviceView;
        ITabControl _tabControl;
        IApplicantRepository _applicantRepository;
        public AddApplicantViewModel(IServiceView serviceView, ITabControl tabControl, IApplicantRepository applicantRepository)
        {
            _serviceView = serviceView;
            _tabControl = tabControl;
            _applicantRepository = applicantRepository;

            ExitCommand = RaketaCommand.Launch(CloseTab);
            CitizenshipCommand = RaketaCommand.Launch(Citizenship);
            CreatePersonalFileCommand = RaketaCommand.Launch(CreatePersonalFile);

            AddDocumentCommand = RaketaCommand.Launch(AddDocument);
            ChangeDocumentCommand = RaketaTCommand<DocumentBaseViewModel>.Launch(ChangeDocument);
            DeleteDocumentCommand = RaketaTCommand<DocumentBaseViewModel>.Launch(DeleteDocument);

            AddEducationCommand = RaketaCommand.Launch(AddEducation);
            ChangeEducationCommand = RaketaTCommand<EducationBaseViewModel>.Launch(ChangeEducation);
            DeleteEducationCommand = RaketaTCommand<EducationBaseViewModel>.Launch(DeleteEducation);
        }

        void CloseTab() => _tabControl.RemoveTab();
        void Citizenship()
        {
            if(ApplicantVM.IsCitizenRus == true)
            {
                ApplicantVM.Citizenship = string.Empty;
                Visual.IsEnabledTextBox = false;
            }
            if(ApplicantVM.NotCitizen == true)
            {
                ApplicantVM.Citizenship = string.Empty;
                Visual.IsEnabledTextBox = false;
            }
            if(ApplicantVM.IsForeign == true)
            {
                ApplicantVM.Citizenship = string.Empty;
                Visual.IsEnabledTextBox = true;
            }
        }
        void CreatePersonalFile() => Dev.NotReady();

        void AddDocument() => _serviceView.Window<DocumentViewModel>(null, Documents).Modal();
        void ChangeDocument(DocumentBaseViewModel document) => _serviceView.Window<ChangeDocumentViewModel>(null, document).Modal();
        void DeleteDocument(DocumentBaseViewModel document) => Documents.Remove(document);

        void AddEducation() => _serviceView.Window<EducationDocViewModel>(null, Educations).Modal();
        void ChangeEducation(EducationBaseViewModel education) { } //_serviceView.Window<ChangeDocumentViewModel>(null, education).Modal();
        void DeleteEducation(EducationBaseViewModel education) => Educations.Remove(education);
    }
}