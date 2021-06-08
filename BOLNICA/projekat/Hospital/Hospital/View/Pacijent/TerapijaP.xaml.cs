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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for TerapijaP.xaml
    /// </summary>
    public partial class TerapijaP : Page
    {
        private PocetnaPacijent parent;
       
        private PrintDialog _printDialog = new PrintDialog();
        


      
        public TerapijaP(PocetnaPacijent p)
        {
            InitializeComponent();
            parent = p;
            Calendar.Days[0].Notes = "ampril 12:00h";
            Calendar.Days[2].Notes = "analgin 10:00h";
            Calendar.Days[2].Notes = "paracetamol 13:00h";

        }
        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new PacijentPPage(parent);
        }
        private void pdf(object sender, RoutedEventArgs e)
        {
            _printDialog.PrintVisual(new Izvjestaji(), "Izveštaj 1");

        }
    }
}
