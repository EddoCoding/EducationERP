using EducationERP.Common.Components;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.DeanRoom
{
    public class AddEducationGroupViewModel : RaketaViewModel
    {
        public EducationGroupVM EducationGroupVM { get; set; } = new();
        public GroupTypes[] EnumGroupTypes { get; set; } = (GroupTypes[])Enum.GetValues(typeof(GroupTypes));

        public RaketaCommand ExitCommand { get; set; }

        IServiceView _serviceView;
        ObservableCollection<EducationGroupVM> _educationGroups;
        public AddEducationGroupViewModel(IServiceView serviceView, UserSystem userSystem, ObservableCollection<EducationGroupVM> educationGroups)
        {
            _serviceView = serviceView;
            EducationGroupVM.Formed = userSystem.FullName;
            _educationGroups = educationGroups;

            ExitCommand = RaketaCommand.Launch(CloseWindow);
        }

        void CloseWindow() => _serviceView.Close<AddEducationGroupViewModel>();

        public enum GroupTypes
        {
            Общая,
            Бюджетная,
            Платная
        }
    }
}