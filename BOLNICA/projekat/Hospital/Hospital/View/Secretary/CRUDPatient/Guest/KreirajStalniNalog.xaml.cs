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
    /// Interaction logic for KreirajStalniNalog.xaml
    /// </summary>
    public partial class KreirajStalniNalog : Window
    {
        public ObservableCollection<Patient> listPatient;
        public Patient patient;
        public int index;
        public KreirajStalniNalog(ObservableCollection<Patient> list, Patient selectedPatient, int sel)
        {
            InitializeComponent();
            InitializeComponent();
            listPatient = list;

            foreach (Patient p in listPatient)
            {
                if (p.Equals(selectedPatient))
                {
                    patient = p;
                    break;
                }
            }

            listPatient = list;
            index = sel;

            /*imeText.SelectedText = selectedPatient.name;
            prezimeText.SelectedText = selectedPatient.surname;
            jmbgText.SelectedText = selectedPatient.jmbg;
            pol.SelectedIndex = (int)selectedPatient.gender; //ovako se setuje opcija combo box-a
            brText.SelectedText = selectedPatient.telephoneNumber;
            datumText.SelectedText = selectedPatient.birthdate;
            brKnjText.SelectedText = Convert.ToString(selectedPatient.idHealthCard);
            brKarText.SelectedText = Convert.ToString(selectedPatient.patientId);
            zanimanjeText.SelectedText = selectedPatient.occupation;
            zastitaText.SelectedIndex = (int)selectedPatient.healthCareCategory;
            osiguraniktText.SelectedText = selectedPatient.insurence;
            ulicaText.SelectedText = Convert.ToString(selectedPatient.adress.street);
            broj.SelectedText = Convert.ToString(selectedPatient.adress.streetNumber);
            grad.SelectedIndex = (int)selectedPatient.adress.city;
            drzava.SelectedIndex = (int)selectedPatient.adress.country;

            */

        }
        private void odustaniB(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sacuvajButton(object sender, RoutedEventArgs e)
        {
            PatientFileStorage pfs = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");


        }
    }

    
}
