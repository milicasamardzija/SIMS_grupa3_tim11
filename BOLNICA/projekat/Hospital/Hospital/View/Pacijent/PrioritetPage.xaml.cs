using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PrioritetPage.xaml
    /// </summary>
    public partial class PrioritetPage : Page

    {
        public ObservableCollection<Checkup> appointmentList;
        private PocetnaPacijent parent;
        private int id;
        public PrioritetPage(PocetnaPacijent p,ObservableCollection<Checkup> applist)
        {
            InitializeComponent();
            parent = p;
            appointmentList = applist;
            id = p.id;
        }
        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new DodajPage(parent, appointmentList);
        }

        private void doktor(object sender, RoutedEventArgs e)
        {
           
            parent.startWindow.Content = new DoktorPage(parent,appointmentList);


        }

        private void datum(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new DatumPage(parent,appointmentList);

        }
    }
}
