using EducationERP.ViewModels.Modules.DeanRoom;
using System.Collections.ObjectModel;
using System.Windows;
using static EducationERP.ViewModels.Modules.DeanRoom.AddEducationGroupViewModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingStructEducational
{
    public class EducationGroupVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CodeEducationGroup { get; set; } = string.Empty;
        public string NameEducationGroup { get; set; } = string.Empty;
        public string LevelGroup { get; set; } = string.Empty;
        public string FormGroup { get; set; } = string.Empty;
        public GroupTypes TypeGroup { get; set; }
        public int Course { get; set; } = 1;
        public int MaxNumberStudents { get; set; }
        public string CodeDirection { get; set; } = string.Empty;
        public string NameDirection { get; set; } = string.Empty;
        public string CodeProfile { get; set; } = string.Empty;
        public string NameProfile { get; set; } = string.Empty;
        public ObservableCollection<StudentVM> Students { get; set; } = new();
        public string NameCuratorGroup { get; set; } = string.Empty;
        public string NameHeadmanGroup { get; set; } = string.Empty;
        public string Formed { get; set; } = string.Empty;
        public DateOnly DateOfFormed { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public bool Validation()
        {
            if (String.IsNullOrWhiteSpace(NameEducationGroup))
            {
                MessageBox.Show("Введите название группы!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(LevelGroup))
            {
                MessageBox.Show("Введите уровень подготовки группы!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(FormGroup))
            {
                MessageBox.Show("Введите форму обучения группы!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(TypeGroup.ToString()))
            {
                MessageBox.Show("Выберите тип группы!");
                return false;
            }
            if (Course <= 0)
            {
                MessageBox.Show("Введите курс группы!");
                return false;
            }
            if (MaxNumberStudents <= 0)
            {
                MessageBox.Show("Введите максимальное количество студентов группы!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(CodeDirection))
            {
                MessageBox.Show("Введите код направления!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(NameDirection))
            {
                MessageBox.Show("Введите название направления!");
                return false;
            }

            return true;
        }
    }
}