﻿namespace EducationERP.ViewModels.Modules.DeanRoom.DocumentsStudent
{
    public abstract class DocumentStudentBaseVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TypeDocument { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string PlaceOfBirth { get; set; } = string.Empty;
        public string AdditionalInformation { get; set; } = string.Empty;

        public abstract bool Validation();
    }
}