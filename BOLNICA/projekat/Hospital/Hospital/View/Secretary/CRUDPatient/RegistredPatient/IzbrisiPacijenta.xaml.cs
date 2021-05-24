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

    public partial class IzbrisiPacijenta : Window
    {
        public ObservableCollection<Patient> listPatient;
        public int index;
        public int id;
    
        public IzbrisiPacijenta(ObservableCollection<Patient> list, Patient selectedPatient, int selectedIndex)
        {
            InitializeComponent();
            listPatient = list;
            id = selectedPatient.PatientId;
            index = selectedIndex;
        }

        private void potvrdiB(object sender, RoutedEventArgs e)
        {
            PatientFileStorage storage = new PatientFileStorage();
            storage.DeleteById(id);
            listPatient.RemoveAt(index);
            this.Close();
        }
        private void odustaniB(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
