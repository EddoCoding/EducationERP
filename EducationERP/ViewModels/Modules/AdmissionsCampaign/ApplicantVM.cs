using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign
{
    public class ApplicantVM : RaketaViewModel
    {
        string citizenship = string.Empty;

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

        // Коллекции/Списки/Массивы - Документы
        public ObservableCollection<string> Documents { get; set; } = new();
        public ObservableCollection<string> EducationDocuments { get; set; } = new();
        public ObservableCollection<string> ExamResult { get; set; } = new();
        public ObservableCollection<string> DistinguishingFeatures { get; set; } = new();
        public ObservableCollection<string> AreasOfTraining { get; set; } = new();
        public string SelectedDirectionOfTraining { get; set; } = string.Empty;
        public ObservableCollection<string> SubmittedDocuments { get; set; } = new();
    }
}