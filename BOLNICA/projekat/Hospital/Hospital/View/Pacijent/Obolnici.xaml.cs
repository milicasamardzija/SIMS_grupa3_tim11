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
    /// Interaction logic for Obolnici.xaml
    /// </summary>
    public partial class Obolnici : Window
    {
        int id;
        public Obolnici(int idP)
        {
            InitializeComponent();
            id = idP;

            PatientFileStorage storage = new PatientFileStorage();
            ObservableCollection<Patient> patients = storage.GetAll();

            foreach (Patient patient in patients)
            {
                if (patient.PatientId == idP)
                {
                    imePacijenta.Text = patient.name + " " + patient.surname;
                }
            }
        }

        private void odustani(object sender, RoutedEventArgs e)
        {

        }
    }


}