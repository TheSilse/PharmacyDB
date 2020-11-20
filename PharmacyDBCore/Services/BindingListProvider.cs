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
                DataType.Appointments => (BindingList<Appointment>)sender,
                DataType.Clients => (BindingList<Client>)sender,
                DataType.Drugs => (BindingList<Drug>)sender,
                DataType.Employees => (BindingList<Employee>)sender,
                DataType.Orders => (BindingList<Order>)sender,
                DataType.Suppliers => (BindingList<Supplier>)sender,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };

        public static dynamic GetDataList(DataType type, DatabaseContext db) =>
            type switch
            {
                DataType.Appointments => db.Appointments.ToList(),
                DataType.Clients => db.Clients.ToList(),
                DataType.Drugs => db.Drugs.ToList(),
                DataType.Employees => db.Employees.ToList(),
                DataType.Orders => db.Orders.ToList(),
                DataType.Suppliers => db.Suppliers.ToList(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
    }
}
