using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Database.Models
{
    public class Client : Notify
    {
        private int _id;
        private string _name;
        private string _address;
        private string _country;
        private string _telephone;
        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public string Address { get => _address; set { _address = value; OnPropertyChanged(); } }
        public string Country { get => _country; set { _country = value; OnPropertyChanged(); } }
        public string Telephone { get => _telephone; set { _telephone = value; OnPropertyChanged(); } }
    }
}

