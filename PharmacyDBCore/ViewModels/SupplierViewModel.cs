using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using PharmacyDBCore.Commands;
using PharmacyDBCore.Database.Models;

namespace PharmacyDBCore.ViewModels
{
    public class SupplierViewModel : Notify
    {
        private Supplier _supplier;
        public Supplier GetSupplier() => _supplier;
        public NextCommand NextCommand => new NextCommand(this);
        public PrevCommand PrevCommand => new PrevCommand(this);
        public SaveCommand SaveCommand => new SaveCommand(this);
        public SupplierViewModel()
        {
            _supplier ??= new Supplier();
        }
        public SupplierViewModel(Supplier supplier)
        {
            _supplier = supplier;
        }
        public int Id
        {
            get => _supplier.Id;
            set { _supplier.Id = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => _supplier.Name;
            set { _supplier.Name = value; OnPropertyChanged(); }
        }

        public string Representative
        {
            get => _supplier.Representative;
            set { _supplier.Representative = value; OnPropertyChanged(); }
        }

        public string Address
        {
            get => _supplier.Address;
            set { _supplier.Address = value; OnPropertyChanged(); }
        }

        public string City
        {
            get => _supplier.City;
            set { _supplier.City = value; OnPropertyChanged(); }
        }

        public string Country
        {
            get => _supplier.Country;
            set { _supplier.Country = value; OnPropertyChanged(); }
        }

        public string TelephoneNumber
        {
            get => _supplier.TelephoneNumber;
            set { _supplier.TelephoneNumber = value; OnPropertyChanged(); }
        }
    }
}
