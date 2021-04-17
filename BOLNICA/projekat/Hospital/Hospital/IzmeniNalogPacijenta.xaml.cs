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
            brText.SelectedText = selectedPatient.telephoneNumber;
            datumText.SelectedText = selectedPatient.birthdate;
            brKnjText.SelectedText = Convert.ToString(selectedPatient.IdHealthCard);
            brKarText.SelectedText = Convert.ToString(selectedPatient.PatientId);




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
            promeniP.telephoneNumber = brText.Text;
            promeniP.PatientId = Convert.ToInt16(brKarText.Text);
            promeniP.IdHealthCard = Convert.ToInt16(brKnjText.Text);

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
