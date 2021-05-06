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
  
    public partial class WindowPacijent : Window
    {
        public int id { get; set; }
        public ObservableCollection<Appointment> AppointmentList
        {
            get;
            set;
        }
        public WindowPacijent(int idP)
        {
            InitializeComponent();
            this.DataContext = this;
            id = idP;
            AppointmentList = loadJason();

        }
        public ObservableCollection<Appointment> loadJason()
        {
            AppointmentFileStorage fs = new AppointmentFileStorage();
            ObservableCollection<Appointment> rs = new ObservableCollection<Appointment>(fs.GetAll()); //svi termini
            ObservableCollection<Appointment> ret = new ObservableCollection<Appointment>(); //ovde ce biti ubaceni termini za pacijenta sa prisledjenim id-jem(odnosno id pacijenta koji je ulogovan na sistem)

            foreach (Appointment appointment in rs) //prolazimo kroz sve termine u fajlu
            {
                if (appointment.Patient.PatientId == id) //trazimo termin koji ima pacijenta sa prosledjenim id-jem
                {
                    ret.Add(appointment); //dodajemo taj termin u listu koju vracamo za ispis u tabelu
                }
            }

            return ret;
        }
    
        private void dodavanje(object sender, RoutedEventArgs e)
        {
            DodajTermin dd = new DodajTermin(AppointmentList,id); //salje se i id ulogovang pacijenta
            dd.Show();
        }

        private void izmeni(object sender, RoutedEventArgs e)
        {
           IzmeniTermin it = new IzmeniTermin(AppointmentList, (Appointment)ListaTermina.SelectedItem, ListaTermina.SelectedIndex,id);
            it.Show();
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            ObrisiTermin ob = new ObrisiTermin(AppointmentList, (Appointment)ListaTermina.SelectedItem, ListaTermina.SelectedIndex);
            ob.Show();
        }

        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            PocetnaPacijent pp = new PocetnaPacijent(id);
            pp.Show();
            this.Close();
        }
    }
}
