using EducationERP.Models.Modules.AdmissionsCampaign.Directions;
using EducationERP.Models.Modules.AdmissionsCampaign.DistinctiveFeatures;
using EducationERP.Models.Modules.AdmissionsCampaign.Educations;
using EducationERP.Models.Modules.AdmissionsCampaign.Exams;

namespace EducationERP.Models.Modules.AdmissionsCampaign
{
    public class Applicant
    {
        public Guid Id { get; set; }
        #region Личная информация
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string FullName { get; set;} = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string PlaceOfBirth { get; set; } = string.Empty;
        public bool? IsCitizenRus { get; set; }
        public bool? NotCitizen { get; set; }
        public bool? IsForeign { get; set; }
        public string Citizenship { get; set; } = string.Empty;
        public DateOnly CitizenshipValidFrom { get; set; }
        public bool IsNeedHostel { get; set; }
        public bool IsNotNeedHostel { get; set; }
        #endregion
        #region Контактная информация
        public string ResidentialAddress { get; set; } = string.Empty;
        public string AddressOfRegistration { get; set; } = string.Empty;
        public string? HomePhone { get; set; } = string.Empty;
        public string MobilePhone { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string AdditionalContactInformation { get; set; } = string.Empty;
        #endregion

        public ICollection<Document> Documents { get; set; }
        public ICollection<EducationBase> Educations { get; set; }
        public ICollection<EGE> EGES { get; set; }
        public int TotalPoints { get; set; }
        public ICollection<DistinctiveFeature> DistinguishingFeatures { get; set; }
        public int PointsDistinctiveFeatures { get; set; }
        public ICollection<SelectedDirection> DirectionsOfTraining { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public int SumPointsExam { get; set; }
        public string AdditionalInformation { get; set; } = string.Empty;
        public string Accepted { get; set; } = string.Empty;
        public DateOnly DateAccepted { get; set; }
        public TimeOnly TimeAccepted { get; set; }
        public bool ForEnrollment { get; set; }
    }
}