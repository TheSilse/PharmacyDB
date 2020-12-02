using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PharmacyDBCore.Database;
using PharmacyDBCore.Database.Models;
using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Commands
{
    public class PrevCommand : BaseCommand
    {
        private AppointmentViewModel _appVM;
        private ClientViewModel _clientVM;
        private DrugViewModel _drugVM;
        private EmployeeViewModel _employeeVM;
        private OrderViewModel _orderVM;
        private SupplierViewModel _supplierVM;
        private DatabaseContext _db;
        public PrevCommand(AppointmentViewModel viewModel)
        {
            _appVM = viewModel;
        }

        public PrevCommand(ClientViewModel viewModel) 
        {
            _clientVM = viewModel;
        }

        public PrevCommand(DrugViewModel viewModel) 
        {
            _drugVM = viewModel;
        }

        public PrevCommand(EmployeeViewModel viewModel) 
        {
            _employeeVM = viewModel;
        }

        public PrevCommand(OrderViewModel viewModel)
        {
            _orderVM = viewModel;
        }

        public PrevCommand(SupplierViewModel viewModel)
        {
            _supplierVM = viewModel;
        }

        public override bool CanExecute(object parameter)
        {
            DataType type = Enum.Parse<DataType>((string)parameter, true);
            _db ??= new DatabaseContext();
            switch (type)
            {
                case DataType.Appointments:
                    {
                        if (!_db.Appointments.Any())
                        {
                            return false;
                        }
                        int dbFirstId = _db.Appointments.ToList().First().Id;
                        return _appVM.Id > dbFirstId && _appVM.Id != dbFirstId;
                    }
                case DataType.Clients:
                    {
                        if (!_db.Clients.Any())
                        {
                            return false;
                        }
                        int dbFirstId = _db.Clients.ToList().First().Id;
                        return _clientVM.Id > dbFirstId && _clientVM.Id != dbFirstId;
                    }
                case DataType.Drugs:
                    {
                        if (!_db.Drugs.Any())
                        {
                            return false;
                        }
                        int dbFirstId = _db.Drugs.ToList().First().Id;
                        return _drugVM.Id > dbFirstId && _drugVM.Id != dbFirstId;
                    }
                case DataType.Employees:
                    {
                        if (!_db.Employees.Any())
                        {
                            return false;
                        }
                        int dbFirstId = _db.Employees.ToList().First().Id;
                        return _employeeVM.Id > dbFirstId && _employeeVM.Id != dbFirstId;
                    }
                case DataType.Orders:
                    {
                        if (!_db.Orders.Any())
                        {
                            return false;
                        }
                        int dbFirstId = _db.Orders.ToList().First().Id;
                        return _orderVM.Id > dbFirstId && _orderVM.Id != dbFirstId;
                    }
                case DataType.Suppliers:
                    {
                        if (!_db.Suppliers.Any())
                        {
                            return false;
                        }
                        int dbFirstId = _db.Suppliers.ToList().First().Id;
                        return _supplierVM.Id > dbFirstId && _supplierVM.Id != dbFirstId;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }
        }

        public override void Execute(object parameter)
        {
            DataType type = Enum.Parse<DataType>((string)parameter, true);
             _db ??= new DatabaseContext();
            switch (type)
            {
                case DataType.Appointments:
                {
                    List<Appointment> list = _db.Appointments.ToList();
                    Appointment finded = null;
                    list.Reverse();
                    if (list.First().Id < _appVM.Id)
                    {
                        finded = list.First();
                    }
                    else
                    {
                        finded = list.SkipWhile(t => t.Id != _appVM.Id).Skip(1).Take(1).Single();
                    }
                    _appVM.Id = finded.Id;
                    _appVM.Group = finded.Group;
                    _appVM.Description = finded.Description;
                    break;
                }
                case DataType.Clients:
                {
                    List<Client> list = _db.Clients.ToList();
                    Client finded = null;
                    list.Reverse();
                    if (list.First().Id < _clientVM.Id)
                    {
                        finded = list.First();
                    }
                    else
                    {
                        finded = list.SkipWhile(t => t.Id != _clientVM.Id).Skip(1).Take(1).Single();
                    }

                    _clientVM.Id = finded.Id;
                    _clientVM.Name = finded.Name;
                    _clientVM.Address = finded.Address;
                    _clientVM.Telephone = finded.Telephone;
                    _clientVM.Country = finded.Country;
                    break;
                }
                case DataType.Drugs:
                {
                    List<Drug> list = _db.Drugs.ToList();
                    Drug finded = null;
                    list.Reverse();
                    if (list.First().Id < _drugVM.Id)
                    {
                        finded = list.First();
                    }
                    else
                    {
                        finded = list.SkipWhile(t => t.Id != _drugVM.Id).Skip(1).Take(1).Single();
                    }
                    _drugVM.Id = finded.Id;
                    _drugVM.Name = finded.Name;
                    _drugVM.Appointment = finded.Appointment;
                    _drugVM.AppointmentId = finded.AppointmentId;
                    _drugVM.Count = finded.Count;
                    _drugVM.Price = finded.Price;
                    _drugVM.Supplier = finded.Supplier;
                    _drugVM.SupplierId = finded.SupplierId;
                    break;
                }
                case DataType.Employees:
                {
                    List<Employee> list = _db.Employees.ToList();
                    list.Reverse();
                    Employee finded = null;
                    if (list.First().Id < _employeeVM.Id)
                    {
                        finded = list.First();
                    }
                    else
                    {
                        finded = list.SkipWhile(t => t.Id != _employeeVM.Id).Skip(1).Take(1).Single();
                    }
                    _employeeVM.Id = finded.Id;
                    _employeeVM.Name = finded.Name;
                    _employeeVM.MiddleName = finded.MiddleName;
                    _employeeVM.Position = finded.Position;
                    _employeeVM.Telephone = finded.Telephone;
                    _employeeVM.SecondName = finded.SecondName;
                    _employeeVM.Salary = finded.Salary;
                    break;
                }
                case DataType.Orders:
                {
                    List<Order> list = _db.Orders.ToList();
                    list.Reverse();
                    Order finded = null;
                    if (list.First().Id < _orderVM.Id)
                    {
                        finded = list.First();
                    }
                    else
                    {
                        finded = list.SkipWhile(t => t.Id != _orderVM.Id).Skip(1).Take(1).Single();
                    }
                    _orderVM.Id = finded.Id;
                    _orderVM.Client = finded.Client;
                    _orderVM.ClientId = finded.ClientId;
                    _orderVM.Employee = finded.Employee;
                    _orderVM.EmployeeId = finded.EmployeeId;
                    _orderVM.DeliveryCost = finded.DeliveryCost;
                    _orderVM.Date = finded.Date;
                    _orderVM.Recipient = finded.Recipient;
                    _orderVM.RecipientAddress = finded.RecipientAddress;
                    _orderVM.RecipientCity = finded.RecipientCity;
                    _orderVM.RecipientCountry = finded.RecipientCountry;
                    break;
                }
                case DataType.Suppliers:
                {
                    List<Supplier> list = _db.Suppliers.ToList();
                    list.Reverse();
                    Supplier finded = null;
                    if (list.First().Id < _supplierVM.Id)
                    {
                        finded = list.First();
                    }
                    else
                    {
                        finded = list.SkipWhile(t => t.Id != _supplierVM.Id).Skip(1).Take(1).Single();
                    }
                    _supplierVM.Id = finded.Id;
                    _supplierVM.Name = finded.Name;
                    _supplierVM.Address = finded.Address;
                    _supplierVM.Country = finded.Country;
                    _supplierVM.Representative = finded.Representative;
                    _supplierVM.City = finded.City;
                    _supplierVM.TelephoneNumber = finded.TelephoneNumber;
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
