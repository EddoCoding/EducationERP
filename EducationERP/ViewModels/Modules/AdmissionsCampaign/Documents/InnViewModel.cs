﻿using System.Windows;

namespace EducationERP.ViewModels.Modules.AdmissionsCampaign.Documents
{
    public class InnViewModel : DocumentBaseViewModel
    {
        public string NumberINN { get; set; } = string.Empty;
        public DateOnly DateAssigned { get; set; }
        public string SeriesNumber { get; set; } = string.Empty;

        public InnViewModel() { TypeDocument = "Инн"; }

        public override bool Validation()
        {
            if (String.IsNullOrWhiteSpace(SurName) || String.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Неполные данные!");
                return false;
            }
            if (DateOfBirth == default || DateOfBirth > DateOnly.FromDateTime(DateTime.Now))
            {
                MessageBox.Show("Дата рождения не указана или указана неверно!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(Gender))
            {
                MessageBox.Show("Пол не указан!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(PlaceOfBirth))
            {
                MessageBox.Show("Место рождения не указано!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(NumberINN))
            {
                MessageBox.Show("Номер Инн не указан!");
                return false;
            }
            if (DateAssigned == default || DateAssigned > DateOnly.FromDateTime(DateTime.Now))
            {
                MessageBox.Show("Дата назначения не указана или указана неверно!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(SeriesNumber))
            {
                MessageBox.Show("Серия и номер не указаны!");
                return false;
            }

            return true;
        }
    }
}