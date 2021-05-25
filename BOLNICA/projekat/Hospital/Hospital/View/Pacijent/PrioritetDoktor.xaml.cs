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
using System.Windows.Shapes;

namespace Hospital.View.Pacijent
{

    public partial class PrioritetDoktor : Window
    {
        int id;
        private List<global::Doctor> lekari;
        private List<string> availableTimes;
        public PrioritetDoktor(int idP)
        {
            InitializeComponent();
            id = idP;

            PatientFileStorage storage = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            List<Patient> allPatients = storage.GetAll();
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>(allPatients);
            foreach (Patient patient in patients)
            {
                if (patient.Id == idP)
                {
                    imePacijenta.Text = patient.name + " " + patient.surname;
                }
            }

            DoctorFileStorage df = new DoctorFileStorage();
            lekari = df.GetAll();
            lekar.ItemsSource = lekari;

            potvrdii.IsEnabled = false;
            date.IsEnabled = false;

            timelabel.Visibility = Visibility.Hidden;
            times.Visibility = Visibility.Hidden;
            availableTimes = new List<string>();
        }


        private void potvrdi(object sender, RoutedEventArgs e)
        {

        }

        private void odustani(object sender, RoutedEventArgs e)
        {

            Prioritet prioritet = new Prioritet(id);
            prioritet.Show();
            this.Close();
        }

        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            Prioritet prioritet = new Prioritet(id);
            prioritet.Show();
            this.Close();
        }

        private void ljekari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void times_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}