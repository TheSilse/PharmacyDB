﻿namespace PharmacyDBCore.Database.Models
{
    public class Order
    {

        public int Id { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public string Date { get; set; }

        public decimal DeliveryCost { get; set; }

        public string Recipient { get; set; }

        public string RecipientAddress { get; set; }

        public string RecipientCity { get; set; }

        public string RecipientCountry { get; set; }

        public Order()
        {
            EmployeeId = 1;
            ClientId = 1;
        }
    }
}
