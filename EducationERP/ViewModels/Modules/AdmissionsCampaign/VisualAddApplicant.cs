using Raketa;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign
{
    public class VisualAddApplicant : RaketaViewModel
    {
        bool isEnabledTextBox = false;
        public bool IsEnabledTextBox
        {
            get => isEnabledTextBox;
            set => SetValue(ref isEnabledTextBox, value);
        }
    }
}