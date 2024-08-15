using Raketa;

namespace EducationERP.ViewModels
{
    public class EducationViewModel : RaketaViewModel
    {
        public string Text { get; set; } = string.Empty;

        public EducationViewModel()
        {
            Text = "Главное окно";
        }
    }
}