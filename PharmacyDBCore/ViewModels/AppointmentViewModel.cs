using PharmacyDBCore.Commands;
using PharmacyDBCore.Database.Models;

namespace PharmacyDBCore.ViewModels
{
    public class AppointmentViewModel : Notify
    {
        private Appointment _appointment;
        public Appointment GetAppointment() => _appointment;
        public PrevCommand PrevCommand => new PrevCommand(this);
        public NextCommand NextCommand => new NextCommand(this);
        public SaveCommand SaveCommand => new SaveCommand(this);

        public AppointmentViewModel()
        {
            _appointment ??= new Appointment();
        }

        public AppointmentViewModel(Appointment appointment) : this()
        {
            _appointment = appointment;
        }
        public int Id
        {
            get => _appointment.Id;
            set
            {
                _appointment.Id = value;
                OnPropertyChanged();
            }
        }

        public string Group
        {
            get => _appointment.Group;
            set { _appointment.Group = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get => _appointment.Description;
            set { _appointment.Description = value; OnPropertyChanged(); }
        }


    }
}
