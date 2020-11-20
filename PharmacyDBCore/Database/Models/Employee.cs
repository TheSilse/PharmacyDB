using System.ComponentModel;
using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Database.Models
{
    public class Employee : Notify
    {
        private int _id;
        private string _secondName;
        private string _name;
        private string _middleName;
        private string _position;
        private string _telephone;
        private decimal _salary;

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }


        public string SecondName
        {
            get => _secondName;
            set { _secondName = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string MiddleName
        {
            get => _middleName;
            set { _middleName = value; OnPropertyChanged(); }
        }

        public string Position
        {
            get => _position;
            set { _position = value; OnPropertyChanged(); }
        }

        public string Telephone
        {
            get => _telephone;
            set { _telephone = value; OnPropertyChanged(); }
        }

        public decimal Salary
        {
            get => _salary;
            set { _salary = value; OnPropertyChanged(); }
        }
    }
}
