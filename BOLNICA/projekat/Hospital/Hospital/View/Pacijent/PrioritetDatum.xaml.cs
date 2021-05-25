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
    /// <summary>
    /// Interaction logic for PrioritetDatum.xaml
    /// </summary>
    /// 
   

    public partial class PrioritetDatum : Window

    {
        int id;
        public PrioritetDatum(int idP)
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
        }

        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            Prioritet prioritet = new Prioritet(id);
            prioritet.Show();
            this.Close();
        }
    }
}
