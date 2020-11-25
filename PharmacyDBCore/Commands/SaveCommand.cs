using System;
using System.Collections.Generic;
using System.Text;
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
                                var created = new Appointment();
                                created.Id = _appointment.Id;
                                created.Group = _appointment.Group;
                                created.Description = _appointment.Description;
                                db.Appointments.Add(created);
                            };
                            break;
                        }
                    case DataType.Clients:
                        {
                            var finded = db.Clients.Find(_client.Id);
                            if (finded != null)
                            {
                                finded.Group = _appointment.Group;
                                finded.Description = _appointment.Description;
                                db.Appointments.Update(finded);
                            }
                            else
                            {
                                var created = new Appointment();
                                created.Id = _appointment.Id;
                                created.Group = _appointment.Group;
                                created.Description = _appointment.Description;
                                db.Appointments.Add(created);
                            };
                            break;
                        }
                    case DataType.Drugs:
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
                                var created = new Appointment();
                                created.Id = _appointment.Id;
                                created.Group = _appointment.Group;
                                created.Description = _appointment.Description;
                                db.Appointments.Add(created);
                            };
                            break;
                        }
                    case DataType.Employees:
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
                                var created = new Appointment();
                                created.Id = _appointment.Id;
                                created.Group = _appointment.Group;
                                created.Description = _appointment.Description;
                                db.Appointments.Add(created);
                            };
                            break;
                        }
                    case DataType.Orders:
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
                                var created = new Appointment();
                                created.Id = _appointment.Id;
                                created.Group = _appointment.Group;
                                created.Description = _appointment.Description;
                                db.Appointments.Add(created);
                            };
                            break;
                        }
                    case DataType.Suppliers:
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
                                var created = new Appointment();
                                created.Id = _appointment.Id;
                                created.Group = _appointment.Group;
                                created.Description = _appointment.Description;
                                db.Appointments.Add(created);
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
    }
}

