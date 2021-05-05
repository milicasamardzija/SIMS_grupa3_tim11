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
        public ObservableCollection<Appointment> termini
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

        }
        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            PocetnaPacijent pacijent = new PocetnaPacijent(id);
            pacijent.Show();
            this.Close();
        }
        private void oceni_doktora(object sender, RoutedEventArgs e)
        {
            DodajAnketu pp = new DodajAnketu(termini, (Appointment)ListaTermina.SelectedItem, ListaTermina.SelectedIndex, id);
            pp.Show();

        }
        public ObservableCollection<Appointment> loadJason()
        {
            AppointmentFileStorage fs = new AppointmentFileStorage();
            ObservableCollection<Appointment> rs = new ObservableCollection<Appointment>(fs.GetAll());
            ObservableCollection<Appointment> ret = new ObservableCollection<Appointment>();

            foreach (Appointment appointment in rs)
            {
                if (appointment.patient.PatientId == id)
                {
                    ret.Add(appointment);
                }
            }

            return ret;
        }

        private void ocenite_bolnicu(object sender, RoutedEventArgs e)
        {
            OceniteBolnicu oceni = new OceniteBolnicu();
            oceni.Show();
        }
    }
}
