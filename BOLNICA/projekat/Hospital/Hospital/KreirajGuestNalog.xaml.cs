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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for KreirajGuestNalog.xaml
    /// </summary>
    public partial class KreirajGuestNalog : Window
    {
      //  public ObservableCollection<Patient> listPatient;
        public KreirajGuestNalog()
        {
            InitializeComponent();
        }

        public int generisiIdG()
        {
            int ret = 100;

            PatientFileStorage pfs = new PatientFileStorage();
            ObservableCollection<Patient> allPatients = pfs.GetAll();

            foreach (Patient pId in allPatients)
            {
                foreach (Patient p in allPatients)
                {
                    if (ret == p.patientId)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }
        private void kreirajGuest(object sender, RoutedEventArgs e)
        {
            PatientFileStorage pStorage = new PatientFileStorage();
            Patient newPatient = new Patient(imeText.Text, prezimeText.Text, brojTelText.Text, jmbgText.Text, (Gender)pol.SelectedIndex,
                (DateTime)datum.SelectedDate,
              generisiIdG());

            pStorage.Save(newPatient);
           // listPatient.Add(newPatient);

            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
