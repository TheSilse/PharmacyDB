using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Database.Models
{
    public class Drug
    {
        public Drug()
        {
            AppointmentId = 1;
            SupplierId = 1;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public int Count { get; set; }

        public int Price { get; set; }
    }
}
