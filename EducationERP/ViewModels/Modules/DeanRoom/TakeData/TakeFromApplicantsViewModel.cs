using EducationERP.Common.Components;
using EducationERP.Common.Components.Services;
using EducationERP.ViewModels.Modules.Administration.SettingStructEducational;
using EducationERP.ViewModels.Modules.AdmissionsCampaign;
using Raketa;
using System.Collections.ObjectModel;

namespace EducationERP.ViewModels.Modules.DeanRoom.TakeData
{
    public class TakeFromApplicantsViewModel : RaketaViewModel
    {
        public ObservableCollection<ApplicantVM> Applicants = new();

        public RaketaCommand ExitCommand { get; }

        ITabControl _tabControl;
        StudentVM _studentVM;
        public EducationGroupVM EducationGroupVM { get; set; }
        public TakeFromApplicantsViewModel(ITabControl tabControl, StudentVM studentVM, EducationGroupVM educationGroupVM)
        {
            _tabControl = tabControl;
            _studentVM = studentVM;
            EducationGroupVM = educationGroupVM;

            using (var db = new DataContext())
            {
                var applicants = db.Applicants
                    .Select(x => x.DirectionsOfTraining
                    .Where(z => z.NameDirection == EducationGroupVM.NameDirection));
                if(applicants != null)
                {
                    foreach(var applicant in applicants)
                    {
                        var applicantVM = new ApplicantVM
                        {
                            

                        };

                        Applicants.Add(applicantVM);
                    }
                }
            }

            ExitCommand = RaketaCommand.Launch(CloseTab);
        }

        void CloseTab() => _tabControl.RemoveTab();
    }
}