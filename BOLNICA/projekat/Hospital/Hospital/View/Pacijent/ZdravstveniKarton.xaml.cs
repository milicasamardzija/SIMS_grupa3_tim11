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

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for ZdravstveniKarton.xaml
    /// </summary>
    public partial class ZdravstveniKarton : Window
    {

        int id;
        DateTime date;

        public ZdravstveniKarton(int idP)
        {
            InitializeComponent();
            id = idP;

            MedicalRecordsFileStorage storage2 = new MedicalRecordsFileStorage(@"./../../../../Hospital/files/storageMRecords.json");
            List<MedicalRecord> records = storage2.GetAll();
            PatientFileStorage storage = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            List<Patient> patients = storage.GetAll();
            foreach (MedicalRecord record in records)
            {
                foreach (Patient patient in patients)
                {
                    if (patient.Id == idP && patient.Id == record.Id)
                    {
                        imePacijenta.Text = patient.name + " " + patient.surname;
                        ime.Text = patient.name;
                        prezime.Text = patient.surname;
                    
                        jmbg.Text = patient.jmbg;

                        broj.Text = record.IdHealthCard.ToString();
                        grupa.Text = record.bloodType.ToString();
                        date = record.birthdayDate.Date;

                        datum.Text = date.ToString();
                        nzo.Text = record.HealthCareCategory.ToString();




                    }
                }
            }



        }

        private void obavljeni_pregledi(object sender, RoutedEventArgs e)
        {

        }

        private void odustani(object sender, RoutedEventArgs e)
        {

            PocetnaPacijent pocetna = new PocetnaPacijent(id);
            pocetna.Show();
            this.Close();
        }
    }
}