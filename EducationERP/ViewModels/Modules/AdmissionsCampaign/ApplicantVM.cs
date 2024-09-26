using EducationERP.ViewModels.Modules.AdmissionsCampaign.DistinctiveFeatures;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Education;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Exams;
using Raketa;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign
{
    public class ApplicantVM : RaketaViewModel, IDisposable
    {
        string citizenship = string.Empty;
        int totalPoints;
        int pointsDistinctiveFeatures;

        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string PlaceOfBirth { get; set; } = string.Empty;
        public bool? IsCitizenRus { get; set; } = true;
        public bool? NotCitizen { get; set; } = false;
        public bool? IsForeign { get; set; } = false;
        public string Citizenship
        {
            get => citizenship;
            set => SetValue(ref citizenship, value);
        }
        public DateOnly CitizenshipValidFrom { get; set; }

        //  Контактная информация
        public string ResidentialAddress { get; set; } = string.Empty;
        public string AddressOfRegistration { get; set; } = string.Empty;
        public string HomePhone { get; set; } = string.Empty;
        public string MobilePhone { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string AdditionalInformation { get; set; } = string.Empty;

        // Документы, Образование, Признаки и т.д.
        public ObservableCollection<DocumentBaseViewModel> Documents { get; set; } = new();
        public ObservableCollection<EducationBaseViewModel> Educations { get; set; } = new();

        public ObservableCollection<EGEVM> EGES { get; set; } = new();
        public int TotalPoints
        {
            get => totalPoints;
            set => SetValue(ref totalPoints, value);
        }

        public ObservableCollection<DistinctiveFeatureVM> DistinguishingFeatures { get; set; } = new();
        public int PointsDistinctiveFeatures
        {
            get => pointsDistinctiveFeatures;
            set => SetValue(ref pointsDistinctiveFeatures, value);
        }

        public ObservableCollection<string> AreasOfTraining { get; set; } = new();
        public string SelectedDirectionOfTraining { get; set; } = string.Empty;
        public ObservableCollection<string> SubmittedDocuments { get; set; } = new();



        public ApplicantVM() => EGES.CollectionChanged += ChangeValueProperty;

        void ChangeValueProperty(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (var newItem in e.NewItems)
                    if (newItem is EGEVM ege) TotalPoints += ege.SubjectScores;


            if (e.OldItems != null)
                foreach (var oldItem in e.OldItems)
                    if (oldItem is EGEVM ege) TotalPoints -= ege.SubjectScores;
        }

        public void Dispose() => EGES.CollectionChanged -= ChangeValueProperty;
    }
}