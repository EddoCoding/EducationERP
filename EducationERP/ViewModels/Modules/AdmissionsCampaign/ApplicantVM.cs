using EducationERP.ViewModels.Modules.AdmissionsCampaign.Directions;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.DistinctiveFeatures;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Education;
using EducationERP.ViewModels.Modules.AdmissionsCampaign.Exams;
using Raketa;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign
{
    public class ApplicantVM : RaketaViewModel, IDisposable
    {
        string surName;
        string name;
        string middlename;
        DateOnly dateOfBirth;
        string gender;
        string placeOfBirth;
        bool? isCitizenRus = true;
        bool? notCitizen;
        bool? isForeign;
        string citizenship = "Россия";
        DateOnly citizenshipValidFrom;

        string residentialAddress;
        string addressOfRegistration;
        string homePhone;
        string mobilePhone;
        string mail;
        string additionalInformation;

        int totalPoints;
        int pointsDistinctiveFeatures;
        int sumPointsExam;

        #region Личная информация
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SurName
        {
            get => surName;
            set => SetValue(ref surName, value);
        }
        public string Name
        {
            get => name;
            set => SetValue(ref name, value);
        }
        public string MiddleName
        {
            get => middlename;
            set => SetValue(ref middlename, value);
        }
        public DateOnly DateOfBirth
        {
            get => dateOfBirth;
            set => SetValue(ref dateOfBirth, value);
        }
        public string Gender
        {
            get => gender;
            set => SetValue(ref gender, value);
        }
        public string PlaceOfBirth 
        {
            get => placeOfBirth;
            set => SetValue(ref placeOfBirth, value);
        }
        public bool? IsCitizenRus 
        {
            get => isCitizenRus;
            set => SetValue(ref isCitizenRus, value);
        }
        public bool? NotCitizen 
        {
            get => notCitizen;
            set => SetValue(ref notCitizen, value);
        }
        public bool? IsForeign
        {
            get => isForeign;
            set => SetValue(ref isForeign, value);
        }
        public string Citizenship
        {
            get => citizenship;
            set => SetValue(ref citizenship, value);
        }
        public DateOnly CitizenshipValidFrom
        {
            get => citizenshipValidFrom;
            set => SetValue(ref citizenshipValidFrom, value);
        }
        #endregion
        #region Контактная информация
        public string ResidentialAddress
        {
            get => residentialAddress;
            set => SetValue(ref residentialAddress, value);
        }
        public string AddressOfRegistration
        {
            get => addressOfRegistration;
            set => SetValue(ref addressOfRegistration, value);
        }
        public string HomePhone
        {
            get => homePhone;
            set => SetValue(ref homePhone, value);
        }
        public string MobilePhone
        {
            get => mobilePhone; 
            set => SetValue(ref mobilePhone, value);
        }
        public string Mail
        {
            get => mail;
            set => SetValue(ref mail, value);
        }
        public string AdditionalInformation
        {
            get => additionalInformation; 
            set => SetValue(ref additionalInformation, value);
        }
        #endregion
        #region Коллекции и доп. свойства
        //Документы
        public ObservableCollection<DocumentBaseViewModel> Documents { get; set; } = new();
        //Образования
        public ObservableCollection<EducationBaseViewModel> Educations { get; set; } = new();
        //ЕГЭ
        public ObservableCollection<EGEVM> EGES { get; set; } = new();
        //Сумма баллов ЕГЭ со всех добавленных предметов ЕГЭ
        public int TotalPoints
        {
            get => totalPoints;
            set => SetValue(ref totalPoints, value);
        }
        //Отличительные признаки
        public ObservableCollection<DistinctiveFeatureVM> DistinguishingFeatures { get; set; } = new();
        //Сумма баллов ОП со всех добавленных объектов ОП
        public int PointsDistinctiveFeatures
        {
            get => pointsDistinctiveFeatures;
            set => SetValue(ref pointsDistinctiveFeatures, value);
        }
        //Выбранные направления подготовки
        public ObservableCollection<SelectedDirectionVM> DirectionsOfTraining { get; set; } = new();
        //Добавленные испытания/экзамены
        public ObservableCollection<ExamVM> Exams { get; set; } = new();
        public int SumPointsExam
        {
            get => sumPointsExam;
            set => SetValue(ref sumPointsExam, value);
        }
        #endregion

        public ApplicantVM()
        {
            EGES.CollectionChanged += ChangeValueTotalPoints;
            DistinguishingFeatures.CollectionChanged += ChangeValuePointsDistinctiveFeatures;
        }

        void ChangeValueTotalPoints(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (var newItem in e.NewItems)
                    if (newItem is EGEVM ege) TotalPoints += ege.SubjectScores;
            if (e.OldItems != null)
                foreach (var oldItem in e.OldItems)
                    if (oldItem is EGEVM ege) TotalPoints -= ege.SubjectScores;
        }
        void ChangeValuePointsDistinctiveFeatures(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (var newItem in e.NewItems)
                    if (newItem is DistinctiveFeatureVM distinctiveFeature) PointsDistinctiveFeatures += distinctiveFeature.FeatureScore;
            if (e.OldItems != null)
                foreach (var oldItem in e.OldItems)
                    if (oldItem is DistinctiveFeatureVM distinctiveFeature) PointsDistinctiveFeatures -= distinctiveFeature.FeatureScore;
        }
        public bool Validation()
        {
            //Валидация личных данных
            if (String.IsNullOrWhiteSpace(SurName))
            {
                MessageBox.Show("Введите фамилию!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Введите имя!");
                return false;
            }
            if (DateOfBirth == default || DateOfBirth > DateOnly.FromDateTime(DateTime.Now))
            {
                MessageBox.Show("Дата рождения не указана или указана неверно!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(Gender))
            {
                MessageBox.Show("Введите пол!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(PlaceOfBirth))
            {
                MessageBox.Show("Введите место рождения!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(Citizenship))
            {
                MessageBox.Show("Введите гражданство!");
                return false;
            }
            if (CitizenshipValidFrom == default || CitizenshipValidFrom > DateOnly.FromDateTime(DateTime.Now))
            {
                MessageBox.Show("С какой даты действует гражданство не указано или указано неверно!");
                return false;
            }
            //Валидация контактных данных
            if (String.IsNullOrWhiteSpace(ResidentialAddress))
            {
                MessageBox.Show("Введите адрес проживания!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(AddressOfRegistration))
            {
                MessageBox.Show("Введите адрес по прописке!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(MobilePhone))
            {
                MessageBox.Show("Введите номер мобильного телефона!");
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            EGES.CollectionChanged -= ChangeValueTotalPoints;
            DistinguishingFeatures.CollectionChanged -= ChangeValuePointsDistinctiveFeatures;
        }
    }
}