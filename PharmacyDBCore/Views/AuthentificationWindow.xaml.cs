using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PharmacyDBCore.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthentificationWindow.xaml
    /// </summary>
    public partial class AuthentificationWindow : Window
    {
        public AuthentificationWindow()
        {
            InitializeComponent();
            Logo.Source = new BitmapImage(new Uri(Environment.CurrentDirectory +
                          Path.DirectorySeparatorChar +
                          "Images" + Path.DirectorySeparatorChar +
                          "icon.png"));
        }
        
    }
}
