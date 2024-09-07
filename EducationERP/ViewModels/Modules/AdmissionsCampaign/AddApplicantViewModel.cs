using EducationERP.Models;
using Raketa;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign
{
    public  class AddApplicantViewModel : RaketaViewModel
    {
        public Applicant Applicant { get; set; } = new();
    }
}