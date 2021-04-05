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
    /// Interaction logic for WindowPacijent.xaml
    /// </summary>
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
            ObservableCollection<Appointment> ret = new ObservableCollection<Appointment>();

            foreach (Appointment appointment in rs)
            {
                if (appointment.patient.patientId == id)
                {
                    ret.Add(appointment);
                }
            }

            return ret;
        }
      
    

        

       

        private void dodavanje(object sender, RoutedEventArgs e)
        {
            DodajTermin dd = new DodajTermin(AppointmentList);
            dd.Show();
        }

        private void izmeni(object sender, RoutedEventArgs e)
        {
           IzmeniTermin it = new IzmeniTermin(AppointmentList, (Appointment)ListaTermina.SelectedItem, ListaTermina.SelectedIndex);
            it.Show();
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            ObrisiTermin ob = new ObrisiTermin(AppointmentList, (Appointment)ListaTermina.SelectedItem, ListaTermina.SelectedIndex);
            ob.Show();
        }
    }
}
