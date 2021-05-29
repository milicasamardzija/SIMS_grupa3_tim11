using Hospital.DTO;
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

namespace Hospital.View.Secretary.CRUDPatient.RegistredPatient
{
    /// <summary>
    /// Interaction logic for OdblokirajPacijenta.xaml
    /// </summary>
    public partial class OdblokirajPacijenta : Window
    {
        public ObservableCollection<PatientDTO> listPatients = new ObservableCollection<PatientDTO>();
        public PatientDTO pacijent;
        public int indeks;
        public OdblokirajPacijenta(ObservableCollection<PatientDTO> list, int index)
        {
            InitializeComponent();
            this.DataContext = this;
            listPatients = list;
            indeks = index;

        }

        private void izmeniStatus(object sender, RoutedEventArgs e)
        {
            listPatients.RemoveAt(indeks);
            this.Close();

        }
    }
}
