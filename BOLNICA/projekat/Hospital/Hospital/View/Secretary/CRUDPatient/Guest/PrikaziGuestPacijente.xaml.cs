using Hospital.Controller;
using Hospital.DTO;
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
        public PatientController controller = new PatientController();


        public ObservableCollection<PatientDTO> listGPatient
        {
            get;
            set;
        }

        public PrikaziGuestPacijente()
        {
            InitializeComponent();
            this.DataContext = this;
            //  listGPatient = loadJason();
            listGPatient = loadGuests();
        }

        private ObservableCollection<PatientDTO> loadGuests()
        {
          
            ObservableCollection<PatientDTO> ret = new ObservableCollection<PatientDTO>(controller.loadGuests());
            return ret;

        }

        private void kreirajStalniNalogButton(object sender, RoutedEventArgs e)
        {
              var stalniNalog = new KreirajStalniNalog((Patient)PrikaziGPacijente.SelectedItem, PrikaziGPacijente.SelectedIndex);
               stalniNalog.Show();
           
        }
        private void izbrisiGuest(object sender, RoutedEventArgs e)
        {
           IzbrisiPacijenta p = new IzbrisiPacijenta(listGPatient, (PatientDTO)PrikaziGPacijente.SelectedItem, PrikaziGPacijente.SelectedIndex);
            p.Show();
        }
        private void izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pretraga_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if( pretraga.Text != "")
            {
                PrikaziGPacijente.ItemsSource = controller.patientBySurname(pretraga.Text);
            } else
            {
                PrikaziGPacijente.ItemsSource = controller.loadGuests();
            }
        }
    }
}
