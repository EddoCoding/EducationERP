using Raketa;

namespace EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign
{
    public class SettingFormVM : RaketaViewModel
    {
        string nameForm = string.Empty;

        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameForm
        {
            get => nameForm;
            set => SetValue(ref nameForm, value);
        }
    }
}