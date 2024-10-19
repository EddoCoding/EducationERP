using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.Administration.SettingStructEducational
{
    public class AddMainFacultyViewModel : RaketaViewModel
    {
        ObservableCollection<FacultyVM> _faculties;
        public AddMainFacultyViewModel(ObservableCollection<FacultyVM> faculties)
        {
            _faculties = faculties;
        }
    }
}