using System.ComponentModel;
using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Database.Models
{
    public class Appointment : Notify
    {
        private int _id;
        private string _group;
        private string _description;
        public int Id 
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Group
        {
            get => _group;
            set
            {
                _group = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
    }
}
