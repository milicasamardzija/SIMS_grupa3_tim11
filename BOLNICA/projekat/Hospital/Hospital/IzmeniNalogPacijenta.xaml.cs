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
using System.Collections.ObjectModel;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for IzmeniNalogPacijenta.xaml
    /// </summary>
    public partial class IzmeniNalogPacijenta : Window { 

       public ObservableCollection<Patient> listPatient;

        public IzmeniNalogPacijenta(ObservableCollection<Patient> list, Patient selectedPatient, int sel)
        {
           InitializeComponent();
            listPatient = list;
            imeText.SelectedText = selectedPatient.name;
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
         

        }

        private void izmenaPacijentaB(object sender, RoutedEventArgs e)
        {

            PatientFileStorage pfs = new PatientFileStorage();
            Patient promeniP = pfs.FindById(Convert.ToInt16(brKarText.Text));
            Patient izbrisiP = pfs.FindById(Convert.ToInt16(brKarText.Text));

            promeniP.name = imeText.Text;
            promeniP.surname = prezimeText.Text;
            promeniP.birthdate = datumText.Text;
            promeniP.jmbg = jmbgText.Text;
            promeniP.occupation = zanimanjeText.Text;
            promeniP.insurence = osiguraniktText.Text;
            promeniP.gender = (Gender)pol.SelectedIndex;    //ovako ide za combo box
            promeniP.telephoneNumber = brText.Text;
            promeniP.patientId = Convert.ToInt16(brKarText.Text);
            promeniP.idHealthCard = Convert.ToInt16(brKnjText.Text);
            promeniP.healthCareCategory = (HealthCareCategory)zastitaText.SelectedIndex;
            promeniP.adress.city =((City)grad.SelectedIndex);
            promeniP.adress.country =(Country)drzava.SelectedIndex;
            promeniP.adress.street = ulicaText.Text;
            promeniP.adress.streetNumber = Convert.ToInt16(broj.Text);

            pfs.Delete(izbrisiP);
            pfs.Save(promeniP);

            this.Close();

        }
        private void odustaniB(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
