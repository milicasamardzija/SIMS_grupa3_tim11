using Hospital.Controller;
using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
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

    public partial class KreirajNalog : Window
    {

        private PatientController patientController;
        public PatientDTO patient = new PatientDTO();
        public PatientDTO Patient
        {
            get { return patient; }
            set { patient = value; }
        }


        public KreirajNalog()
        {
         
            InitializeComponent();
            this.DataContext = this;
            patientController = new PatientController();


        }
      
        

     
        private void kreirajNalogB(object sender, RoutedEventArgs e)
        {
            
            Adress adresa = new Adress(ulText.Text, Convert.ToInt16(broj.Text), (City)grad.SelectedIndex, (Country)drzava.SelectedIndex);
            patient.BirthdayDate = (DateTime)datum.SelectedDate;

            patient.Adress = adresa;
            patientController.save(Patient);
          
            this.Close();


        }

        private void odustaniB(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
