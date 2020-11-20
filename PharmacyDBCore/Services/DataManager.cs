using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using PharmacyDBCore.Database;
using PharmacyDBCore.Database.Models;
using System.Linq;
using System.Reflection;
using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Services
{
    public class DataManager
    {
        private DatabaseContext _db;
        public DataManager()
        {
            _db = new DatabaseContext();
        }

        public void RemoveItem(object sender, DataType type, int newIndex)
        {
            
        }

        public void AddItem(object sender, DataType type, int newIndex)
        {
            switch (type)
            {
                case DataType.Appointments:
                {
                    BindingList<Appointment> list = (BindingList<Appointment>)sender;
                    Appointment app = list[newIndex];
                    break;
                }
                case DataType.Clients:
                {
                    break;
                }
                case DataType.Drugs:
                {
                    break;
                }
                case DataType.Employees:
                {
                    break;
                }
                case DataType.Orders:
                {
                    break;
                }
                case DataType.Suppliers:
                {
                    break;
                }
            }
        }
    }
}
