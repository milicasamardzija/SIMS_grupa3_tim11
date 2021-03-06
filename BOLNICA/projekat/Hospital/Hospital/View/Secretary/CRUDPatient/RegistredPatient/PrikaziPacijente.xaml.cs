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
using Hospital.Controller;
using Hospital.DTO;
using Hospital.Sekretar;

namespace Hospital
{
    
    public partial class PrikaziPacijente : Window
    {
        public ObservableCollection<PatientDTO> listPatient
        {
            get;
            set;
        }
       
        public PatientController patientController;

        public PrikaziPacijente()
        {
            InitializeComponent();
            this.DataContext = this;
            patientController = new PatientController();
            listPatient = loadRegistredPatients();
           
        }


        public ObservableCollection<PatientDTO> loadRegistredPatients()
        {
            ObservableCollection<PatientDTO> ret = new ObservableCollection<PatientDTO>(patientController.loadRegistred());
            return ret;
        }

   

        private void izmeniNalogPacijenta(object sender, RoutedEventArgs e)
        {
            if (PrikazPacijenata.SelectedItem != null)
            {
                IzmeniNalogPacijenta izmenaNaloga = new IzmeniNalogPacijenta(listPatient, (PatientDTO)PrikazPacijenata.SelectedItem, PrikazPacijenata.SelectedIndex);
                izmenaNaloga.ShowDialog();
            } else
            {
                MessageBoxResult result = MessageBox.Show("Niste odabrali pacijenta!");
            }
        }

        private void izbrisiNalogPacijenta(object sender, RoutedEventArgs e)
        {
            if (PrikazPacijenata.SelectedItem != null)
            {
                IzbrisiPacijenta ip = new IzbrisiPacijenta(listPatient, (PatientDTO)PrikazPacijenata.SelectedItem, PrikazPacijenata.SelectedIndex);
                ip.Show();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Niste odabrali pacijenta!");
            }
        }

        private void addAlergents(object sender, RoutedEventArgs e)
        {
            if (PrikazPacijenata.SelectedItem != null)
            {
                Alergeni a = new Alergeni(listPatient, (PatientDTO)PrikazPacijenata.SelectedItem, PrikazPacijenata.SelectedIndex);
                a.Show();
            } else
            {
                MessageBoxResult mess = MessageBox.Show("Niste odabrali pacijenta!");
            }
        }

        private void CancelBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      

        private void pretraga_TextChanged(object sender, TextChangedEventArgs e)
        {if(pretraga.Text == "")
            {
                PrikazPacijenata.ItemsSource = patientController.getAll();
            }else {
                ObservableCollection<PatientDTO> filtrirani = new ObservableCollection<PatientDTO>(patientController.patientBySurname(pretraga.Text));
                PrikazPacijenata.ItemsSource =filtrirani; 
            }
            
        }
    }
}
