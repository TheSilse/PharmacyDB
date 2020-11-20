using System.ComponentModel;
using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Database.Models
{
    public class Order : Notify
    {
        private int _id;
        private Client _client;
        private Employee _employee;
        private string _date;
        private decimal _deliveryCost;
        private string _recipient;
        private string _recipientAddress;
        private string _recipientCity;
        private string _recipientCountry;
        private bool _arrived;
        private int _clientId;
        private int _employeeId;

        public Order()
        {
            _employeeId = 1;
            _clientId = 1;
        }
        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public int ClientId
        {
            get => _clientId;
            set { _clientId = value; OnPropertyChanged(); }
        }
        public Client Client
        {
            get => _client;
            set { _client = value; OnPropertyChanged(); }
        }

        public int EmployeeId
        {
            get => _employeeId;
            set { _employeeId = value; OnPropertyChanged(); }
        }
        public Employee Employee
        {
            get => _employee;
            set { _employee = value; OnPropertyChanged(); }
        }

        public string Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(); }
        }

        public decimal DeliveryCost
        {
            get => _deliveryCost;
            set { _deliveryCost = value; OnPropertyChanged(); }
        }

        public string Recipient
        {
            get => _recipient;
            set { _recipient = value; OnPropertyChanged(); }
        }

        public string RecipientAddress
        {
            get => _recipientAddress;
            set { _recipientAddress = value; OnPropertyChanged(); }
        }

        public string RecipientCity
        {
            get => _recipientCity;
            set { _recipientCity = value; OnPropertyChanged(); }
        }

        public string RecipientCountry
        {
            get => _recipientCountry;
            set { _recipientCountry = value; OnPropertyChanged(); }
        }

        public bool Arrived
        {
            get => _arrived;
            set { _arrived = value; OnPropertyChanged(); }
        }
    }
}
