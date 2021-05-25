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
    /// Interaction logic for ZdravstveniKarton.xaml
    /// </summary>
    public partial class ZdravstveniKarton : Window
    {

        int id;
        String date;

        public ZdravstveniKarton(int idP)
        {
            InitializeComponent();
            id = idP;

            MedicalRecordsFileStorage storage2 = new MedicalRecordsFileStorage();
            List<MedicalRecord> records = storage2.GetAll();
            PatientFileStorage storage = new PatientFileStorage();
            ObservableCollection<Patient> patients = storage.GetAll();
            foreach (MedicalRecord record in records)
            {
                foreach (Patient patient in patients)
                {
                    if (patient.PatientId == idP && patient.PatientId == record.PatientId)
                    {
                        imePacijenta.Text = patient.name + " " + patient.surname;
                        ime.Text = patient.name;
                        prezime.Text = patient.surname;
                        //  datum.Text = patient.birthdayDate;
                        jmbg.Text = patient.jmbg;

                        broj.Text = record.IdHealthCard.ToString();
                        grupa.Text = record.bloodType.ToString();
                        datum.Text = patient.birthdayDate.ToString();
                        date = "05/10/1998";
                        datum.Text = date;
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
