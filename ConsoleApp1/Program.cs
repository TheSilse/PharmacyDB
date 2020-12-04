using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Windows.Input;


namespace ConsoleApp1
{


    class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            EventHandler canExecuteChangedHandler = CanExecuteChanged;
            if (canExecuteChangedHandler != null)
            {
                canExecuteChangedHandler(this, EventArgs.Empty);
            }
        }
        public bool CanExecute(object parameter)
        {
            Console.WriteLine($"Can Execute {parameter}");
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine($"Execute {parameter}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int height = 0;
            height = int.Parse(Console.ReadLine());
            for (int i = height - 1; i >= 0; i--)
            {
                for (int j = height - 1; j >= 0; j--)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public static void GetStringsCount()
        {
            string path = @"E:\Projects CSharp\Online Content Bot\src";

            IEnumerable<string> xamls = Directory.GetFiles(path, "*.xaml", SearchOption.AllDirectories).Distinct();
            IEnumerable<string> cs = Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories).Distinct();
            int count = 0;
            foreach (var item in cs)
            {
                if (item.Contains(".g."))
                {
                    continue;
                }
                using (TextReader tr = new StreamReader(item, Encoding.Default))
                {
                    while (tr.ReadLine() != null)
                    {
                        count++;
                    }
                }
            }
            foreach (var item in xamls)
            {
                if (item.Contains(".g."))
                {
                    continue;
                }
                using (TextReader tr = new StreamReader(item, Encoding.Default))
                {
                    while (tr.ReadLine() != null)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(cs.Count());
            Console.WriteLine(xamls.Count());
            Console.WriteLine($"Проект имеет {count} строк");
        }
    }
}
