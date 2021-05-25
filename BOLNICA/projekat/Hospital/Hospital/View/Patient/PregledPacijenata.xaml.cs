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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.IO;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for PregledPacijenata.xaml
    /// </summary>
    public partial class PregledPacijenata : Window
    {
        
        public ObservableCollection<Patient> ListPatient
        {
            get;
            set;
        }
       /* public ObservableCollection<MedicalRecord> MedicalList
        {
            get;
            set;
        }*/

        public PregledPacijenata()
        {
            InitializeComponent();
            this.DataContext = this;
            ListPatient = loadJ();
        }

        public ObservableCollection<Patient> loadJ()
        {
            PatientFileStorage storage = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            ObservableCollection<Patient> ppp = new ObservableCollection<Patient>(storage.GetAll());
            ObservableCollection<Patient> pat = new ObservableCollection<Patient>();
            foreach(Patient patient in ppp)
            {
                pat.Add(patient);
            }
            return pat;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PrikaziKartonPacijenta pk = new PrikaziKartonPacijenta(ListPatient, (Patient)Pacijenti.SelectedItem, Pacijenti.SelectedIndex);
            pk.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
