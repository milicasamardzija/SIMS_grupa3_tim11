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
    /// Interaction logic for KreirajNalog.xaml
    /// </summary>
    public partial class KreirajNalog : Window
    {
        public KreirajNalog()
        {
            
            InitializeComponent();
         
        }
        private void kreirajNalogB(object sender, RoutedEventArgs e) {
            PatientFileStorage pStorage = new PatientFileStorage();
        /*    Patient newPatient = new Patient(imeText.Text, prezimeText.Text, jmbgText.Text, datrText.Text,
                adresText.Text, brTelText.Text, Convert.ToInt16(brKnjiziceText.Text), (HealthCareCategory)zastita.SelectedIndex, 
                Convert.ToInt16(brKartonaText.Text));*/


          //  pStorage.Save(newPatient);
           // listPatient.Add(newPatient);

            this.Close();


                }

        private void odustaniB(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
