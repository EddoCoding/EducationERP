using System.Windows;

namespace EducationERP.ViewModels.Modules.Administration.SettingStructEducational
{
    public class DepartmentVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameDepartment { get; set; } = string.Empty;

        public bool Validation()
        {
            if (String.IsNullOrWhiteSpace(NameDepartment))
            {
                MessageBox.Show("Введите название кафедры!");
                return false;
            }

            return true;
        }
    }
}