using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.DeanRoom
{
    public class AddEducationGroupViewModel : RaketaViewModel
    {
        ObservableCollection<EducationGroupVM> _educationGroups;
        public AddEducationGroupViewModel(ObservableCollection<EducationGroupVM> educationGroups)
        {
            _educationGroups = educationGroups;
        }
    }
}