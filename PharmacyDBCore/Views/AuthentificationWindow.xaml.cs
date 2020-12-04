using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using PharmacyDBCore.Services;

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
                          "logo.png"));
            DbInitializer.Init();
        }

    }
}
