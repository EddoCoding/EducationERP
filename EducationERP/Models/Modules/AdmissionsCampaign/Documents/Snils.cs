﻿namespace EducationERP.Models.Modules.AdmissionsCampaign
{
    public class Snils : Document
    {
        public string Number { get; set; } = string.Empty;
        public DateOnly RegistrationDate { get; set; }
    }
}