namespace EducationERP.Common.Components
{
    public class UserSystem
    {
        public string FullName { get; set; } = string.Empty;
        public bool? AdmissionsCampaign { get; set; } = false;
        public bool? DeanRoom { get; set; } = false;
        public bool? Administration { get; set; } = false;

        public bool CheckToGuest()
        {
            if (FullName == string.Empty) return true;

            return false;
        }
    }
}