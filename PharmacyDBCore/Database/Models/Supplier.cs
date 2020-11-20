using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Database.Models
{
    public class Supplier : Notify
    {
        private int _id;
        private string _name;
        private string _representative;
        private string _telephoneNumber;
        private string _country;
        private string _city;
        private string _address;
        private string _position;
        
        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string Representative
        {
            get => _representative;
            set { _representative = value; OnPropertyChanged(); }
        }

        public string Position
        {
            get => _position;
            set { _position = value; OnPropertyChanged(); }
        }

        public string Address
        {
            get => _address;
            set { _address = value; OnPropertyChanged(); }
        }

        public string City
        {
            get => _city;
            set { _city = value; OnPropertyChanged(); }
        }

        public string Country
        {
            get => _country;
            set { _country = value; OnPropertyChanged(); }
        }

        public string TelephoneNumber
        {
            get => _telephoneNumber;
            set { _telephoneNumber = value; OnPropertyChanged(); }
        }
    }
}
