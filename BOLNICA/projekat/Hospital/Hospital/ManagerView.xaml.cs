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
    /// Interaction logic for ManagerView.xaml
    /// </summary>
    public partial class ManagerView : Window
    {
        public ManagerView()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(new Magacin());
        }

        private void magacin(object sender, RoutedEventArgs e)
        {

            frame.NavigationService.Navigate(new Magacin());
        }

        private void sobe(object sender, RoutedEventArgs e)
        {
            //   frame.NavigationService.Navigate(new Sobe());
            Rooms r = new Rooms();
            r.Show();
        }
    }
}
