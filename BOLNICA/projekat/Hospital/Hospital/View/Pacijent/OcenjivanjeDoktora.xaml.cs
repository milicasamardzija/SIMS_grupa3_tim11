using Hospital.Model;
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
    /// <summary>
    /// Interaction logic for OcenjivanjeDoktora.xaml
    /// </summary>
    public partial class OcenjivanjeDoktora : Window
    {
        public int id { get; set; }


        public ObservableCollection<Checkup> termini
        {
            get;
            set;
        }
        public OcenjivanjeDoktora(int idP)
        {
            InitializeComponent();
            this.DataContext = this;
            id = idP;
            termini = loadJason();
            bolnica.IsEnabled = false;

            PatientFileStorage storage = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            List<Patient> patients = storage.GetAll();
            ObservableCollection<Patient> allPatients = new ObservableCollection<Patient>(patients);
            foreach (Patient patient in allPatients)
            {
                if (patient.Id == idP)
                {
                    imePacijenta.Text = patient.name + " " + patient.surname;
                }
            }



            if (termini.Count > 5)
            {
                bolnica.IsEnabled = true;
            }

        }
        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            PocetnaPacijent pacijent = new PocetnaPacijent(id);
            pacijent.Show();
            this.Close();
        }
        private void oceni_doktora(object sender, RoutedEventArgs e)
        {
            DodajAnketu pp = new DodajAnketu(termini, (Checkup)ListaObavljenihTermina.SelectedItem, ListaObavljenihTermina.SelectedIndex, id);
            pp.Show();

        }
        public ObservableCollection<Checkup> loadJason()
        {
            CheckupFileStorage fs = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            ObservableCollection<Checkup> rs = new ObservableCollection<Checkup>(fs.GetAll());
            ObservableCollection<Checkup> ret = new ObservableCollection<Checkup>();

            foreach (Checkup appointment in rs)
            {
                if (appointment.Patient.Id == id)
                { if (DateTime.Now > appointment.Date)
                    {
                        ret.Add(appointment);
                    }
                }
            }

            return ret;
        }

        private void ocenite_bolnicu(object sender, RoutedEventArgs e)
        {
            OceniteBolnicu oceni = new OceniteBolnicu(id);
            oceni.Show();
        }

        private void ListaObavljenihTermina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        public void UpdateTable()
        {
            ListaObavljenihTermina.Items.Remove(((Checkup)ListaObavljenihTermina.SelectedItem).Id);
        }
    }
}
