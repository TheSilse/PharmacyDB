using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmacyDBCore.Database;
using PharmacyDBCore.Database.Models;
using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Commands
{
    public class NextCommand : BaseCommand
    {
        private AppointmentViewModel _appointment;
        private ClientViewModel _client;
        private DrugViewModel _drug;
        private EmployeeViewModel _employee;
        private OrderViewModel _order;
        private SupplierViewModel _supplier;

        public NextCommand(AppointmentViewModel viewModel) => _appointment = viewModel;
        public NextCommand(ClientViewModel viewModel) => _client = viewModel;
        public NextCommand(DrugViewModel viewModel) => _drug = viewModel;
        public NextCommand(EmployeeViewModel viewModel) => _employee = viewModel;
        public NextCommand(OrderViewModel viewModel) => _order = viewModel;
        public NextCommand(SupplierViewModel viewModel) => _supplier = viewModel;

        public override bool CanExecute(object parameter)
        {
            DataType type = Enum.Parse<DataType>((string)parameter, true);
            using (DatabaseContext db = new DatabaseContext())
            {
                switch (type)
                {
                    case DataType.Appointments:
                        {
                            if (!db.Appointments.Any())
                            {
                                return false;
                            }
                            int lastId = db.Appointments.ToList().Last().Id;
                            return _appointment.Id < lastId;
                        }
                    case DataType.Clients:
                        {
                            if (!db.Clients.Any())
                            {
                                return false;
                            }
                            int lastId = db.Clients.ToList().Last().Id;
                            return _client.Id < lastId;
                        }
                    case DataType.Drugs:
                        {
                            if (!db.Drugs.Any())
                            {
                                return false;
                            }
                            int lastId = db.Drugs.ToList().Last().Id;
                            return _drug.Id < lastId;
                        }
                    case DataType.Employees:
                        {
                            if (!db.Employees.Any())
                            {
                                return false;
                            }
                            int lastId = db.Employees.ToList().Last().Id;
                            return _employee.Id < lastId;
                        }
                    case DataType.Orders:
                        {
                            if (!db.Orders.Any())
                            {
                                return false;
                            }
                            int lastId = db.Orders.ToList().Last().Id;
                            return _order.Id < lastId;
                        }
                    case DataType.Suppliers:
                        {
                            if (!db.Suppliers.Any())
                            {
                                return false;
                            }
                            int lastId = db.Suppliers.ToList().Last().Id;
                            return _supplier.Id < lastId;
                        }
                    default:
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                }
            }

        }

        public override void Execute(object parameter)
        {
            DataType type = Enum.Parse<DataType>((string)parameter, true);
            using (DatabaseContext db = new DatabaseContext())
            {
                switch (type)
                {
                    case DataType.Appointments:
                        {
                            Appointment finded = null;
                            if (_appointment.Id == 0)
                            {
                                finded = db.Appointments.First();
                            }
                            else
                            {
                                finded = db.Appointments.ToList().SkipWhile(t => t.Id != _appointment.Id).Skip(1).Take(1).Single();
                            }
                            _appointment.Id = finded.Id;
                            _appointment.Group = finded.Group;
                            _appointment.Description = finded.Description;
                            break;
                        }
                    case DataType.Clients:
                        {
                            Client finded = null;
                            if (_client.Id == 0)
                            {
                                finded = db.Clients.First();
                            }
                            else
                            {

                                finded = db.Clients.ToList().SkipWhile(t => t.Id != _client.Id).Skip(1).Take(1).Single();
                            }
                            _client.Id = finded.Id;
                            _client.Name = finded.Name;
                            _client.Address = finded.Address;
                            _client.Telephone = finded.Telephone;
                            _client.Country = finded.Country;
                            break;
                        }
                    case DataType.Drugs:
                        {
                            Drug finded = null;
                            if (_drug.Id == 0)
                            {
                                finded = db.Drugs.First();
                            }
                            else
                            {
                                finded = db.Drugs.ToList().SkipWhile(t => t.Id != _drug.Id).Skip(1).Take(1).Single();
                            }
                            _drug.Id = finded.Id;
                            _drug.Name = finded.Name;
                            _drug.Appointment = finded.Appointment;
                            _drug.AppointmentId = finded.AppointmentId;
                            _drug.Count = finded.Count;
                            _drug.Price = finded.Price;
                            _drug.Supplier = finded.Supplier;
                            _drug.SupplierId = finded.SupplierId;
                            break;
                        }
                    case DataType.Employees:
                        {
                            Employee finded = null;
                            if (_employee.Id == 0)
                            {
                                finded = db.Employees.First();
                            }
                            else
                            {
                                finded = db.Employees.ToList().SkipWhile(t => t.Id != _employee.Id).Skip(1).Take(1).Single();
                            }
                            _employee.Id = finded.Id;
                            _employee.Name = finded.Name;
                            _employee.MiddleName = finded.MiddleName;
                            _employee.Position = finded.Position;
                            _employee.Telephone = finded.Telephone;
                            _employee.SecondName = finded.SecondName;
                            _employee.Salary = finded.Salary;
                            break;
                        }
                    case DataType.Orders:
                        {
                            Order finded = null;
                            if (_order.Id == 0)
                            {
                                finded = db.Orders.First();
                            }
                            else
                            {
                                 finded = db.Orders.ToList().SkipWhile(t => t.Id != _order.Id).Skip(1).Take(1).Single();

                            }
                            _order.Id = finded.Id;
                            _order.Client = finded.Client;
                            _order.ClientId = finded.ClientId;
                            _order.Employee = finded.Employee;
                            _order.EmployeeId = finded.EmployeeId;
                            _order.DeliveryCost = finded.DeliveryCost;
                            _order.Date = finded.Date;
                            _order.Recipient = finded.Recipient;
                            _order.RecipientAddress = finded.RecipientAddress;
                            _order.RecipientCity = finded.RecipientCity;
                            _order.RecipientCountry = finded.RecipientCountry;
                            break;
                        }
                    case DataType.Suppliers:
                        {
                            Supplier finded = null;
                            if (_supplier.Id == 0)
                            {
                                finded = db.Suppliers.First();
                            }
                            else
                            {
                                 finded = db.Suppliers.ToList().SkipWhile(t => t.Id != _supplier.Id).Skip(1).Take(1).Single();
                            }
                            _supplier.Id = finded.Id;
                            _supplier.Name = finded.Name;
                            _supplier.Address = finded.Address;
                            _supplier.Country = finded.Country;
                            _supplier.Representative = finded.Representative;
                            _supplier.City = finded.City;
                            _supplier.TelephoneNumber = finded.TelephoneNumber;
                            break;
                        }
                    default:
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                }
            }
        }
    }
}
