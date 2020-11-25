using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Database.Models
{
    public class Supplier 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Representative { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string TelephoneNumber { get; set; }

       
    }
}
