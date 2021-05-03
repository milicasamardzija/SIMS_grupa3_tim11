using Hospital.Sekretar;
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

    /// Interaction logic for KreirajNalog.xaml

    public partial class KreirajNalog : Window
    {
      

        public KreirajNalog()
        {

            InitializeComponent();

        }

        public int generisiId()
        {
            int ret = 0;

            PatientFileStorage pfs = new PatientFileStorage();
            ObservableCollection<Patient> allPatients = pfs.GetAll();

            foreach (Patient pId in allPatients)
            {
                foreach (Patient p in allPatients)
                {
                    if (ret == p.PatientId)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }
        private void kreirajNalogB(object sender, RoutedEventArgs e)
        {
            PatientFileStorage pStorage = new PatientFileStorage();

            Patient newPatient = new Patient(imeText.Text, prezimeText.Text, brTelText.Text, jmbgText.Text, (Gender)pol.SelectedIndex, (DateTime)datum.SelectedDate,generisiId(), (HealthCareCategory)zastita.SelectedIndex,Convert.ToInt16(brKnjiziceText.Text), zanimanjeText.Text, imePrzOsText.Text, new Adress(ulText.Text, Convert.ToInt16(broj.Text), (City)grad.SelectedIndex, (Country)drzava.SelectedIndex));
           
            MedicalRecordsFileStorage mStorage = new MedicalRecordsFileStorage();
            MedicalRecord newRecord = new MedicalRecord(imeText.Text, prezimeText.Text, jmbgText.Text, (Gender)pol.SelectedIndex, (DateTime)datum.SelectedDate, generisiId(), (HealthCareCategory)zastita.SelectedIndex, Convert.ToInt16(brKnjiziceText.Text), (BloodType)krvnaGrupa.SelectedIndex);

            pStorage.Save(newPatient);
            mStorage.Save(newRecord);
          
            this.Close();


        }

        private void odustaniB(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dodajAlergene(object sender, RoutedEventArgs e)
        { 
            Alergeni a = new Alergeni(Owner);
            a.Show();

        }
    }
}
