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
    /// Interaction logic for KreirajGuestNalog.xaml
    /// </summary>
    public partial class KreirajGuestNalog : Window
    {
        public ObservableCollection<Patient> listPatient;
        public KreirajGuestNalog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientFileStorage pStorage = new PatientFileStorage();
            Patient newPatient = new Patient(imeText.Text, prezimeText.Text, brojTelText.Text, jmbgText.Text, (Gender)pol.SelectedIndex,
                datRodjText.Text,
              Convert.ToInt16(brKarText.Text));

            pStorage.Save(newPatient);
            listPatient.Add(newPatient);

            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
