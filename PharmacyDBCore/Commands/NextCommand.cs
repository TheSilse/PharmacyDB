using PharmacyDBCore.Database;
using PharmacyDBCore.Database.Models;
using PharmacyDBCore.ViewModels;
using System;
using System.Linq;

namespace PharmacyDBCore.Commands
{
    public class NextCommand : BaseCommand
    {
        private AppointmentViewModel _appVM;
        private ClientViewModel _clientVM;
        private DrugViewModel _drugVM;
        private EmployeeViewModel _employeeVM;
        private OrderViewModel _orderVM;
        private SupplierViewModel _supplierVM;

        private DatabaseContext _db;


        public NextCommand(AppointmentViewModel viewModel)
        {
            _appVM = viewModel;

        }

        public NextCommand(ClientViewModel viewModel)
        {
            _clientVM = viewModel;
        }

        public NextCommand(DrugViewModel viewModel)
        {
            _drugVM = viewModel;
        }

        public NextCommand(EmployeeViewModel viewModel)
        {
            _employeeVM = viewModel;
        }

        public NextCommand(OrderViewModel viewModel)
        {
            _orderVM = viewModel;
        }

        public NextCommand(SupplierViewModel viewModel)
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
                        int dbLastId = _db.Appointments.ToList().Last().Id;
                        return _appVM.Id < dbLastId && _appVM.Id != dbLastId;
                    }
                case DataType.Clients:
                    {
                        if (!_db.Clients.Any())
                        {
                            return false;
                        }
                        int dbLastId = _db.Clients.ToList().Last().Id;
                        return _clientVM.Id < dbLastId && _clientVM.Id != dbLastId;
                    }
                case DataType.Drugs:
                    {
                        if (!_db.Drugs.Any())
                        {
                            return false;
                        }
                        int dbLastId = _db.Drugs.ToList().Last().Id;
                        return _drugVM.Id < dbLastId && _drugVM.Id != dbLastId;
                    }
                case DataType.Employees:
                    {
                        if (!_db.Employees.Any())
                        {
                            return false;
                        }
                        int dbLastId = _db.Employees.ToList().Last().Id;
                        return _employeeVM.Id < dbLastId && _employeeVM.Id != dbLastId;
                    }
                case DataType.Orders:
                    {
                        if (!_db.Orders.Any())
                        {
                            return false;
                        }
                        int dbLastId = _db.Orders.ToList().Last().Id;
                        return _orderVM.Id < dbLastId && _orderVM.Id != dbLastId;
                    }
                case DataType.Suppliers:
                    {
                        if (!_db.Suppliers.Any())
                        {
                            return false;
                        }
                        int dbLastId = _db.Suppliers.ToList().Last().Id;
                        return _supplierVM.Id < dbLastId && _supplierVM.Id != dbLastId;
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
                        Appointment finded = null;
                        if (_appVM.Id == 0)
                        {
                            finded = _db.Appointments.First();
                        }
                        else
                        {
                            finded = _db.Appointments.ToList().SkipWhile(t => t.Id != _appVM.Id).Skip(1).Take(1).Single();
                        }
                        _appVM.Id = finded.Id;
                        _appVM.Group = finded.Group;
                        _appVM.Description = finded.Description;
                        break;
                    }
                case DataType.Clients:
                    {
                        Client finded = null;
                        if (_clientVM.Id == 0)
                        {
                            finded = _db.Clients.First();
                        }
                        else
                        {

                            finded = _db.Clients.ToList().SkipWhile(t => t.Id != _clientVM.Id).Skip(1).Take(1).Single();
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
                        Drug finded = null;
                        if (_drugVM.Id == 0)
                        {
                            finded = _db.Drugs.First();
                        }
                        else
                        {
                            finded = _db.Drugs.ToList().SkipWhile(t => t.Id != _drugVM.Id).Skip(1).Take(1).Single();
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
                        Employee finded = null;
                        if (_employeeVM.Id == 0)
                        {
                            finded = _db.Employees.First();
                        }
                        else
                        {
                            finded = _db.Employees.ToList().SkipWhile(t => t.Id != _employeeVM.Id).Skip(1).Take(1).Single();
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
                        Order finded = null;
                        if (_orderVM.Id == 0)
                        {
                            finded = _db.Orders.First();
                        }
                        else
                        {
                            finded = _db.Orders.ToList().SkipWhile(t => t.Id != _orderVM.Id).Skip(1).Take(1).Single();

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
                        Supplier finded = null;
                        if (_supplierVM.Id == 0)
                        {
                            finded = _db.Suppliers.First();
                        }
                        else
                        {
                            finded = _db.Suppliers.ToList().SkipWhile(t => t.Id != _supplierVM.Id).Skip(1).Take(1).Single();
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
