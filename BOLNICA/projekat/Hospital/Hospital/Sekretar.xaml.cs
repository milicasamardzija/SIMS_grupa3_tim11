using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for Sekretar.xaml
    /// </summary>
    public partial class Sekretar : Window
    {
        public Sekretar()
        {
            InitializeComponent();
            Nalozi n = new Nalozi();
            frame.Navigate(n);
        }

        private void otvoriPacijenta(object sender, RoutedEventArgs e)
        {
            Nalozi nalog = new Nalozi();
            frame.Navigate(nalog);
        }
        private void blog(object sender, RoutedEventArgs e)
        {
            UredjivanjeBloga blog = new UredjivanjeBloga();
            frame.Navigate(blog);
        }
    }
}
