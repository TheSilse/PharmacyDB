using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PharmacyDBCore.Database;
using PharmacyDBCore.Database.Models;
using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Services
{
    public class BindingListProvider
    {

        public static dynamic GetBindingList(DataType type, object sender) =>
            type switch
            {
                DataType.Appointments => (BindingList<AppointmentViewModel>)sender,
                DataType.Clients => (BindingList<ClientViewModel>)sender,
                DataType.Drugs => (BindingList<DrugViewModel>)sender,
                DataType.Employees => (BindingList<EmployeeViewModel>)sender,
                DataType.Orders => (BindingList<OrderViewModel>)sender,
                DataType.Suppliers => (BindingList<SupplierViewModel>)sender,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };

        public static dynamic GetDataList(DataType type, DatabaseContext db) =>
            type switch
            {
                DataType.Appointments => db.Appointments.Select(t => new AppointmentViewModel(t)).ToList(),
                DataType.Clients => db.Clients.Select(t=> new ClientViewModel(t)).ToList(),
                DataType.Drugs => db.Drugs.Select(t => new DrugViewModel(t)).ToList(),
                DataType.Employees => db.Employees.Select(t => new EmployeeViewModel(t)).ToList(),
                DataType.Orders => db.Orders.Select(t => new OrderViewModel(t)).ToList(),
                DataType.Suppliers => db.Suppliers.Select(t => new SupplierViewModel(t)).ToList(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
    }
}
