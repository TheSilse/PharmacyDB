using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using PharmacyDBCore.Database.Models;

namespace PharmacyDBCore.ViewModels
{
    public class OrderViewModel : Notify
    {
        private Order _order;
        public Order GetOrder() => _order;
        public OrderViewModel()
        {
            _order ??= new Order();
        }
        public OrderViewModel(Order order)
        {
            _order = order;
        }
        public int Id
        {
            get => _order.Id;
            set { _order.Id = value; OnPropertyChanged(); }
        }

        public int ClientId
        {
            get => _order.ClientId;
            set { _order.ClientId = value; OnPropertyChanged(); }
        }

        public Client Client
        {
            get => _order.Client;
            set { _order.Client = value; OnPropertyChanged(); }
        }

        public int EmployeeId
        {
            get => _order.EmployeeId;
            set { _order.EmployeeId = value; OnPropertyChanged(); }
        }

        public Employee Employee
        {
            get => _order.Employee;
            set { _order.Employee = value; OnPropertyChanged(); }
        }

        public string Date
        {
            get => _order.Date;
            set { _order.Date = value; OnPropertyChanged(); }
        }

        public decimal DeliveryCost
        {
            get => _order.DeliveryCost;
            set { _order.DeliveryCost = value; OnPropertyChanged(); }
        }

        public string Recipient
        {
            get => _order.Recipient;
            set { _order.Recipient = value; OnPropertyChanged(); }
        }

        public string RecipientAddress
        {
            get => _order.RecipientAddress;
            set { _order.RecipientAddress = value; OnPropertyChanged(); }
        }

        public string RecipientCity
        {
            get => _order.RecipientCity;
            set { _order.RecipientCity = value; OnPropertyChanged(); }
        }

        public string RecipientCountry
        {
            get => _order.RecipientCountry;
            set { _order.RecipientCountry = value; OnPropertyChanged(); }
        }
    }
}
