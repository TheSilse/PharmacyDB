using System;
using System.Collections.Generic;
using System.Text;
using PharmacyDBCore.Commands;
using PharmacyDBCore.Database.Models;

namespace PharmacyDBCore.ViewModels
{
    public class DrugViewModel : Notify
    {
        private Drug _drug;
        public Drug GetDrug() => _drug;
        public NextCommand NextCommand => new NextCommand(this);
        public PrevCommand PrevCommand => new PrevCommand(this);
        public SaveCommand SaveCommand => new SaveCommand(this);
        public DrugViewModel()
        {
            _drug ??= new Drug();
        }
        public DrugViewModel(Drug drug)
        {
            _drug = drug;
        }
        public int Id
        {
            get => _drug.Id;
            set { _drug.Id = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => _drug.Name;
            set { _drug.Name = value; OnPropertyChanged(); }
        }

        public int AppointmentId
        {
            get => _drug.AppointmentId;
            set { _drug.AppointmentId = value; OnPropertyChanged(); }
        }

        public Appointment Appointment
        {
            get => _drug.Appointment;
            set { _drug.Appointment = value; OnPropertyChanged(); }
        }

        public int SupplierId
        {
            get => _drug.SupplierId;
            set { _drug.SupplierId = value; OnPropertyChanged(); }
        }

        public Supplier Supplier
        {
            get => _drug.Supplier;
            set { _drug.Supplier = value; OnPropertyChanged(); }
        }

        public int Count
        {
            get => _drug.Count;
            set { _drug.Count = value; OnPropertyChanged(); }
        }

        public int Price
        {
            get => _drug.Price;
            set { _drug.Price = value; OnPropertyChanged(); }
        }
    }
}
