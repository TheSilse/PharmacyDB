using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using PharmacyDBCore.Database;
using PharmacyDBCore.Database.Models;
using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Commands
{
    public class SaveCommand : BaseCommand
    {
        private AppointmentViewModel _appointment;
        private ClientViewModel _client;
        private DrugViewModel _drug;
        private EmployeeViewModel _employee;
        private OrderViewModel _order;
        private SupplierViewModel _supplier;

        public SaveCommand(AppointmentViewModel viewModel) => _appointment = viewModel;
        public SaveCommand(ClientViewModel viewModel) => _client = viewModel;
        public SaveCommand(DrugViewModel viewModel) => _drug = viewModel;
        public SaveCommand(EmployeeViewModel viewModel) => _employee = viewModel;
        public SaveCommand(OrderViewModel viewModel) => _order = viewModel;
        public SaveCommand(SupplierViewModel viewModel) => _supplier = viewModel;
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            try
            {
                DataType type = Enum.Parse<DataType>((string)parameter, true);
                using (DatabaseContext db = new DatabaseContext())
                {
                    switch (type)
                    {
                        case DataType.Appointments:
                            {
                                var finded = db.Appointments.Find(_appointment.Id);
                                if (finded != null)
                                {
                                    finded.Group = _appointment.Group;
                                    finded.Description = _appointment.Description;
                                    db.Appointments.Update(finded);
                                }
                                else
                                {
                                    var created = new Appointment
                                    {
                                        Id = _appointment.Id,
                                        Group = _appointment.Group,
                                        Description = _appointment.Description
                                    };
                                    db.Appointments.Add(created);
                                };
                                break;
                            }
                        case DataType.Clients:
                            {
                                var finded = db.Clients.Find(_client.Id);
                                if (finded != null)
                                {
                                    finded.Id = _client.Id;
                                    finded.Name = _client.Name;
                                    finded.Address = _client.Address;
                                    finded.Telephone = _client.Telephone;
                                    finded.Country = _client.Country;
                                    db.Clients.Update(finded);
                                }
                                else
                                {
                                    var created = new Client()
                                    {
                                        Id = _client.Id,
                                        Address = _client.Address,
                                        Country = _client.Country,
                                        Name = _client.Name,
                                        Telephone = _client.Telephone
                                    };
                                    db.Clients.Add(created);
                                };
                                break;
                            }
                        case DataType.Drugs:
                            {
                                var finded = db.Drugs.Find(_drug.Id);
                                if (finded != null)
                                {
                                    finded.Id = _drug.Id;
                                    finded.Name = _drug.Name;
                                    finded.Appointment = _drug.Appointment;
                                    finded.AppointmentId = _drug.AppointmentId;
                                    finded.Count = _drug.Count;
                                    finded.Price = _drug.Price;
                                    finded.Supplier = _drug.Supplier;
                                    finded.SupplierId = _drug.SupplierId;
                                    db.Drugs.Update(finded);
                                }
                                else
                                {
                                    var created = new Drug()
                                    {
                                        Id = _drug.Id,
                                        Appointment = _drug.Appointment,
                                        Name = _drug.Name,
                                        AppointmentId = _drug.AppointmentId,
                                        Count = _drug.Count,
                                        Price = _drug.Price,
                                        Supplier = _drug.Supplier,
                                        SupplierId = _drug.SupplierId
                                    };
                                    db.Drugs.Add(created);
                                };
                                break;
                            }
                        case DataType.Employees:
                            {
                                var finded = db.Employees.Find(_employee.Id);
                                if (finded != null)
                                {
                                    finded.Id = _employee.Id;
                                    finded.Name = _employee.Name;
                                    finded.MiddleName = _employee.MiddleName;
                                    finded.Position = _employee.Position;
                                    finded.Telephone = _employee.Telephone;
                                    finded.SecondName = _employee.SecondName;
                                    finded.Salary = _employee.Salary;
                                    db.Employees.Update(finded);
                                }
                                else
                                {
                                    var created = new Employee()
                                    {
                                        Id = _employee.Id,
                                        Name = _employee.Name,
                                        Telephone = _employee.Telephone,
                                        MiddleName = _employee.MiddleName,
                                        Position = _employee.Position,
                                        Salary = _employee.Salary,
                                        SecondName = _employee.SecondName
                                    };

                                    db.Employees.Add(created);
                                };
                                break;
                            }
                        case DataType.Orders:
                            {
                                var finded = db.Orders.Find(_order.Id);
                                if (finded != null)
                                {
                                    finded.Id = _order.Id;
                                    finded.Client = _order.Client;
                                    finded.ClientId = _order.ClientId;
                                    finded.Employee = _order.Employee;
                                    finded.EmployeeId = _order.EmployeeId;
                                    finded.DeliveryCost = _order.DeliveryCost;
                                    finded.Date = _order.Date;
                                    finded.Recipient = _order.Recipient;
                                    finded.RecipientAddress = _order.RecipientAddress;
                                    finded.RecipientCity = _order.RecipientCity;
                                    finded.RecipientCountry = _order.RecipientCountry;
                                    db.Orders.Update(finded);
                                }
                                else
                                {
                                    var created = new Order()
                                    {
                                        Id = _order.Id,
                                        Recipient = _order.Recipient,
                                        RecipientAddress = _order.RecipientAddress,
                                        Client = _order.Client,
                                        ClientId = _order.ClientId,
                                        Date = _order.Date,
                                        DeliveryCost = _order.DeliveryCost,
                                        Employee = _order.Employee,
                                        EmployeeId = _order.EmployeeId,
                                        RecipientCity = _order.RecipientCity,
                                        RecipientCountry = _order.RecipientCountry
                                    };

                                    db.Orders.Add(created);
                                };
                                break;
                            }
                        case DataType.Suppliers:
                            {
                                var finded = db.Suppliers.Find(_supplier.Id);
                                if (finded != null)
                                {
                                    finded.Id = _supplier.Id;
                                    finded.Name = _supplier.Name;
                                    finded.Address = _supplier.Address;
                                    finded.Country = _supplier.Country;
                                    finded.Representative = _supplier.Representative;
                                    finded.City = _supplier.City;
                                    finded.TelephoneNumber = _supplier.TelephoneNumber;
                                    db.Suppliers.Update(finded);
                                }
                                else
                                {
                                    var created = new Supplier()
                                    {
                                        Id = _supplier.Id,
                                        Address = _supplier.Address,
                                        Country = _supplier.Country,
                                        City = _supplier.City,
                                        Name = _supplier.Name,
                                        Representative = _supplier.Representative,
                                        TelephoneNumber = _supplier.TelephoneNumber
                                    };
                                    db.Suppliers.Add(created);
                                };
                                break;
                            }
                        default:
                            {
                                throw new ArgumentOutOfRangeException();
                            }
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                if (e.InnerException != null)
                {
                    MessageBox.Show(e.InnerException.Message);
                }
            }
        }
    }
}

