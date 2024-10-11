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
        string citizenship = "Россия";
        int totalPoints;
        int pointsDistinctiveFeatures;

        #region Личная информация
        public Guid Id { get; set; } = Guid.NewGuid();
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
        #endregion
        #region Контактная информация
        public string ResidentialAddress { get; set; } = string.Empty;
        public string AddressOfRegistration { get; set; } = string.Empty;
        public string HomePhone { get; set; } = string.Empty;
        public string MobilePhone { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string AdditionalInformation { get; set; } = string.Empty;
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

        public void Dispose()
        {
            EGES.CollectionChanged -= ChangeValueTotalPoints;
            DistinguishingFeatures.CollectionChanged -= ChangeValuePointsDistinctiveFeatures;
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
    }
}