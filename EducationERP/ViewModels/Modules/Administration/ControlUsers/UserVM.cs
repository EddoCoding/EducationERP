using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.ControlUsers
{
    public class UserVM : RaketaViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        
        public string RolesAndAccesses
        {
            get
            {
                List<string> rolesandaccesses = new();

                if (RoleAdministration && !AccessAdministration) rolesandaccesses.Add($"Администрирование(Ограниченный)");
                else if(RoleAdministration && AccessAdministration) rolesandaccesses.Add($"Администрирование(Полный)");

                return string.Join("|", rolesandaccesses);
            }
        }

        // Роли и доступы
        public bool RoleAdministration { get; set; }
        bool accessAdministration;
        public bool AccessAdministration
        {
            get => accessAdministration;
            set => SetValue(ref accessAdministration, value);
        }
    }
}