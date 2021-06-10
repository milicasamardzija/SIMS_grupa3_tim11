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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for KartonPage.xaml
    /// </summary>
    public partial class KartonPage : Page
    {
      
        private PocetnaPacijent parent;
        int idP;
        DateTime date;
        MedicalRecordController mrcontroller;
        PatientController patientController;
        public KartonPage(PocetnaPacijent p)

        {
            InitializeComponent();
            parent = p;
            idP = p.id; 
            mrcontroller = new MedicalRecordController();
            patientController = new PatientController();







            foreach (MedicalRecord record in mrcontroller.getAll())
            {
                foreach (PatientDTO patient in patientController.getAll())
                {
                    if (patient.Id == parent.id && patient.Id == record.Id)
                    {
                        
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
            parent.startWindow.Content = new ObavljeniPage(parent);

        }

        private void odustani(object sender, RoutedEventArgs e)
        {

            parent.startWindow.Content = new PacijentPPage(parent);
        }
    }
}

