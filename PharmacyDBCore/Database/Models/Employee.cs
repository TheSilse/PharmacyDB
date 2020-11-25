using System.ComponentModel;
using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Database.Models
{
    public class Employee 
    {
        public int Id { get; set; }

        public string SecondName { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string Position { get; set; }

        public string Telephone { get; set; }

        public decimal Salary { get; set; }

        
    }
}
