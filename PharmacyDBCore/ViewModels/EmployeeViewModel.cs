using PharmacyDBCore.Commands;
using PharmacyDBCore.Database.Models;

namespace PharmacyDBCore.ViewModels
{
    public class EmployeeViewModel : Notify
    {
        private Employee _employee;
        public Employee GetEmployee() => _employee;
        public NextCommand NextCommand => new NextCommand(this);
        public PrevCommand PrevCommand => new PrevCommand(this);
        public SaveCommand SaveCommand => new SaveCommand(this);

        public EmployeeViewModel()
        {
            _employee ??= new Employee();
        }
        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
        }
        public int Id
        {
            get => _employee.Id;
            set { _employee.Id = value; OnPropertyChanged(); }
        }

        public string SecondName
        {
            get => _employee.SecondName;
            set { _employee.SecondName = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => _employee.Name;
            set { _employee.Name = value; OnPropertyChanged(); }
        }

        public string MiddleName
        {
            get => _employee.MiddleName;
            set { _employee.MiddleName = value; OnPropertyChanged(); }
        }

        public string Position
        {
            get => _employee.Position;
            set { _employee.Position = value; OnPropertyChanged(); }
        }

        public string Telephone
        {
            get => _employee.Telephone;
            set { _employee.Telephone = value; OnPropertyChanged(); }
        }

        public decimal Salary
        {
            get => _employee.Salary;
            set { _employee.Salary = value; OnPropertyChanged(); }
        }
    }
}
