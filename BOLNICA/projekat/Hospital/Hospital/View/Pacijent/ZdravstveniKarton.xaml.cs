using Hospital.Controller;
using Hospital.DTO;
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
        MedicalRecordController mrcontroller;
        PatientController patientController;

        public ZdravstveniKarton(int idP)
        {
            InitializeComponent();
            id = idP;
            mrcontroller = new MedicalRecordController();
            patientController = new PatientController();




         
           
            
            foreach (MedicalRecord record in mrcontroller.getAll())
            {
                foreach (PatientDTO patient in patientController.getAll())
                {
                    if (patient.Id == idP && patient.Id == record.Id)
                    {
                        imePacijenta.Text = patient.Name + " " + patient.Surname;
                        ime.Text = patient.Name;
                        prezime.Text = patient.Surname;

                        jmbg.Text = patient.Jmbg;

                        broj.Text = record.IdHealthCard.ToString();
                        grupa.Text = record.BloodType.ToString();
                        date = record.birthdayDate.Date;

                        datum.Text = date.ToString();
                        nzo.Text = record.HealthCareCategory.ToString();




                    }
                }
            }



        }

        private void obavljeni_pregledi(object sender, RoutedEventArgs e)
        {
            ObavljeniPregledi pregledi = new ObavljeniPregledi(id);
            pregledi.Show();
            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {

            PocetnaPacijent pocetna = new PocetnaPacijent(id);
            pocetna.Show();
            this.Close();
        }
    }
}
