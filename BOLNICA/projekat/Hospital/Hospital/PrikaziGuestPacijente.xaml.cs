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
    /// Interaction logic for PrikaziGuestPacijente.xaml
    /// </summary>
    public partial class PrikaziGuestPacijente : Window
    {
        public PrikaziGuestPacijente()
        {
            InitializeComponent();
        }

        private void kreirajStalniNalogButton(object sender, RoutedEventArgs e)
        {
            var stalniNalog = new KreirajNalog();
            stalniNalog.Show();
        }
        private void izbrisiGuest(object sender, RoutedEventArgs e)
        {
            
        }
       
    }
}
