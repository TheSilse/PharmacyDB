using System;
using System.Collections.Generic;
using System.Text;
using PharmacyDBCore.Database.Models;

namespace PharmacyDBCore.ViewModels
{
    public class ClientViewModel : Notify
    {
        private Client _client;
        public Client GetClient() => _client;

        public ClientViewModel()
        {
            _client??=new Client();
        }
        public ClientViewModel(Client client)
        {
            _client = client;
        }
        
        public int Id
        {
            get => _client.Id;
            set { _client.Id = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => _client.Name;
            set { _client.Name = value; OnPropertyChanged(); }
        }

        public string Address
        {
            get => _client.Address;
            set { _client.Address = value; OnPropertyChanged(); }
        }

        public string Country
        {
            get => _client.Country;
            set { _client.Country = value; OnPropertyChanged(); }
        }

        public string Telephone
        {
            get => _client.Telephone;
            set { _client.Telephone = value; OnPropertyChanged(); }
        }

    }
}
