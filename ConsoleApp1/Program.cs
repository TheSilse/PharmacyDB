using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ConsoleApp1
{
    public class BindingList<T> : IBindingList
    {

    }
    public class DbContext
    {
        public List<Order> Orders { get; set; }
        public List<Drug> Drugs { get; set; }
    }

    public abstract class DataModel
    {

    }
    public class Order : DataModel
    {

    }
    public class Drug : DataModel
    {

    }

    public enum DataType
    {
        Drug,
        Order
    }

    public class DataManager
    {
        
    }

    public class BindingListProvider
    {
        public static IBindingList GetBindingList(DataType type, object sender)
        {
            switch (type)
            {
                case DataType.Drug:
                    return (BindingList<Drug>) sender;
                case DataType.Order:
                    return (BindingList<Drug>)sender;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }

    public interface IBindingList
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

    }

}
