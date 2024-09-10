namespace EducationERP.Models
{
    public class Applicant
    {
        //  Личная информация
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string PlaceOfBirth { get; set; } = string.Empty;
        public bool? IsCitizenRus { get; set; }
        public bool? NotCitizen { get; set; }
        public bool? IsForeign { get; set; }
        public DateOnly CitizenshipValidFrom { get; set; }

        //  Контактная информация
        public string ResidentialAddress { get; set; } = string.Empty;
        public string AddressOfRegistration { get; set; } = string.Empty;
        public string HomePhone { get; set; } = string.Empty;
        public string MobilePhone { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string AdditionalInformation { get; set; } = string.Empty;

        // Коллекции/Списки/Массивы - Документы
        public string[] Documents { get; set; }
        public string[] EducationDocuments { get; set; }
        public string[] ExamResult { get; set; }
        public string[] DistinguishingFeatures { get; set; }
        public string[] AreasOfTraining { get; set; }
        public string SelectedDirectionOfTraining { get; set; } = string.Empty;
        public string[] SubmittedDocuments { get; set; }
    }
}