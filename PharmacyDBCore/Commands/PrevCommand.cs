using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmacyDBCore.Database;
using PharmacyDBCore.Database.Models;
using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Commands
{
    public class PrevCommand : BaseCommand
    {
        private AppointmentViewModel _appointment;
        private ClientViewModel _client;
        private DrugViewModel _drug;
        private EmployeeViewModel _employee;
        private OrderViewModel _order;
        private SupplierViewModel _supplier;

        public PrevCommand(AppointmentViewModel viewModel) => _appointment = viewModel;
        public PrevCommand(ClientViewModel viewModel) => _client = viewModel;
        public PrevCommand(DrugViewModel viewModel) => _drug = viewModel;
        public PrevCommand(EmployeeViewModel viewModel) => _employee = viewModel;
        public PrevCommand(OrderViewModel viewModel) => _order = viewModel;
        public PrevCommand(SupplierViewModel viewModel) => _supplier = viewModel;


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
                            int firstId = db.Appointments.ToList().First().Id;
                            return _appointment.Id > firstId;
                        }
                    case DataType.Clients:
                        {
                            if (!db.Clients.Any())
                            {
                                return false;
                            }
                            int firstId = db.Clients.ToList().Last().Id;
                            return _client.Id > firstId;
                        }
                    case DataType.Drugs:
                        {
                            if (!db.Drugs.Any())
                            {
                                return false;
                            }
                            int firstId = db.Drugs.ToList().Last().Id;
                            return _drug.Id > firstId;
                        }
                    case DataType.Employees:
                        {
                            if (!db.Employees.Any())
                            {
                                return false;
                            }
                            int firstId = db.Employees.ToList().Last().Id;
                            return _employee.Id > firstId;
                        }
                    case DataType.Orders:
                        {
                            if (!db.Orders.Any())
                            {
                                return false;
                            }
                            int firstId = db.Orders.ToList().Last().Id;
                            return _order.Id > firstId;
                        }
                    case DataType.Suppliers:
                        {
                            if (!db.Suppliers.Any())
                            {
                                return false;
                            }
                            int firstId = db.Suppliers.ToList().Last().Id;
                            return _supplier.Id > firstId;
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
                            List<Appointment> list = db.Appointments.ToList();
                            Appointment finded = null;
                            list.Reverse();
                            if (list.First().Id < _appointment.Id)
                            {
                                finded = list.First();
                            }
                            else
                            {
                                finded = list.SkipWhile(t => t.Id != _appointment.Id).Skip(1).Take(1).Single();
                            }
                            _appointment.Id = finded.Id;
                            _appointment.Group = finded.Group;
                            _appointment.Description = finded.Description;
                            break;
                        }
                    case DataType.Clients:
                        {
                            List<Client> list = db.Clients.ToList();
                            Client finded = null;
                            list.Reverse();
                            if (list.First().Id <= _client.Id)
                            {
                                finded = list.First();
                            }
                            else
                            {
                                finded = list.SkipWhile(t => t.Id != _client.Id).Skip(1).Take(1).Single();
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
                            List<Drug> list = db.Drugs.ToList();
                            Drug finded = null;
                            list.Reverse();
                            if (list.First().Id <= _drug.Id)
                            {
                                finded = list.First();
                            }
                            else
                            {
                                finded = list.SkipWhile(t => t.Id != _drug.Id).Skip(1).Take(1).Single();
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
                            List<Employee> list = db.Employees.ToList();
                            list.Reverse();
                            Employee finded = null;
                            if (list.First().Id <= _employee.Id)
                            {
                                finded = list.First();
                            }
                            else
                            {
                                finded = list.SkipWhile(t => t.Id != _employee.Id).Skip(1).Take(1).Single();
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
                            List<Order> list = db.Orders.ToList();
                            list.Reverse();
                            Order finded = null;
                            if (list.First().Id <= _order.Id)
                            {
                                finded = list.First();
                            }
                            else
                            {
                                finded = list.SkipWhile(t => t.Id != _order.Id).Skip(1).Take(1).Single();
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
                            List<Supplier> list = db.Suppliers.ToList();
                            list.Reverse();
                            Supplier finded = null;
                            if (list.First().Id <= _supplier.Id)
                            {
                                finded = list.First();
                            }
                            else
                            {
                                finded = list.SkipWhile(t => t.Id != _supplier.Id).Skip(1).Take(1).Single();
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
