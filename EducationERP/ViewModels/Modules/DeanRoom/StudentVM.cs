using EducationERP.ViewModels.Modules.DeanRoom.DocumentsStudent;
using System.Collections.ObjectModel;
using System.Windows;
using static EducationERP.ViewModels.Modules.DeanRoom.AddEducationGroupViewModel;

namespace EducationERP.ViewModels.Modules.DeanRoom
{
    public class StudentVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        #region Личная информация
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string PlaceOfBirth { get; set; } = string.Empty;
        public string Citizenship { get; set; } = string.Empty;
        public DateOnly CitizenshipValidFrom { get; set; }
        public bool IsNeedHostel { get; set; }
        public bool IsNotNeedHostel { get; set; } = true;
        #endregion
        #region Контактная информация
        public string ResidentialAddress { get; set; } = string.Empty;
        public string AddressOfRegistration { get; set; } = string.Empty;
        public string HomePhone { get; set; } = string.Empty;
        public string MobilePhone { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string AdditionalContactInformation { get; set; } = string.Empty;
        #endregion
        #region Доп. свойства, коллекции
        public string Accepted { get; set; } = string.Empty;
        public ObservableCollection<DocumentStudentBaseVM> Documents { get; set; } = new();
        #endregion
        #region Где учится
        public string NameEducationGroup { get; set; } = string.Empty;
        public string LevelGroup { get; set; } = string.Empty;
        public string FormGroup { get; set; } = string.Empty;
        public GroupTypes TypeGroup { get; set; }
        public int Course { get; set; }
        public string CodeDirection { get; set; } = string.Empty;
        public string NameDirection { get; set; } = string.Empty;
        public string CodeProfile { get; set; } = string.Empty;
        public string NameProfile { get; set; } = string.Empty;
        #endregion

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
                MessageBox.Show("Пол не указан!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(PlaceOfBirth))
            {
                MessageBox.Show("Место рождения не указано!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(Citizenship))
            {
                MessageBox.Show("Гражданство не указано!");
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