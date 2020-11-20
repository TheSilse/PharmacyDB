using System.ComponentModel;
using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Database.Models
{
    public class Drug : Notify
    {
        private int _id;
        private string _name;
        private Appointment _appointment;
        private Supplier _supplier;
        private int _count;
        private int _price;
        private int _appointmentId;
        private int _supplierId;

        public Drug()
        {
            _appointmentId = 1;
            _supplierId = 1;
        }
        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public int AppointmentId { get => _appointmentId; set { _appointmentId = value; OnPropertyChanged(); } }
        public Appointment Appointment { get => _appointment; set { _appointment = value; OnPropertyChanged(); } }
        public int SupplierId { get => _supplierId; set { _supplierId = value; OnPropertyChanged(); } }
        public Supplier Supplier { get => _supplier; set { _supplier = value; OnPropertyChanged(); } }
        public int Count { get => _count; set { _count = value; OnPropertyChanged(); } }
        public int Price { get => _price; set { _price = value; OnPropertyChanged(); } }
    }
}
