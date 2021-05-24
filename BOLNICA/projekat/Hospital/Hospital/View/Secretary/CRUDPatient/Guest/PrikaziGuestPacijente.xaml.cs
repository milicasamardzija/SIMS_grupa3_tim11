using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
   
    /// Interaction logic for PrikaziGuestPacijente.xaml
    
    public partial class PrikaziGuestPacijente : Window
    {


        public ObservableCollection<Patient> listGPatient
        {
            get;
            set;
        }

        public PrikaziGuestPacijente()
        {
            InitializeComponent();
            this.DataContext = this;
            listGPatient = loadJason();

        }

        private ObservableCollection<Patient> loadJason()
        {
            PatientFileStorage pfs = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            ObservableCollection<Patient> rs = new ObservableCollection<Patient>(pfs.GetAll());
            ObservableCollection<Patient> ret = new ObservableCollection<Patient>();

            foreach (Patient p in rs)
           {
               if(p.guest==true)
               {
                   ret.Add(p);
                }
           }

            return ret;
        }

        private void kreirajStalniNalogButton(object sender, RoutedEventArgs e)
        {
              var stalniNalog = new KreirajStalniNalog(listGPatient, (Patient)PrikaziGPacijente.SelectedItem, PrikaziGPacijente.SelectedIndex);
               stalniNalog.Show();
           
        }
        private void izbrisiGuest(object sender, RoutedEventArgs e)
        {
            IzbrisiPacijenta p = new IzbrisiPacijenta(listGPatient, (Patient)PrikaziGPacijente.SelectedItem, PrikaziGPacijente.SelectedIndex);
            p.Show();
        }
       
    }
}
