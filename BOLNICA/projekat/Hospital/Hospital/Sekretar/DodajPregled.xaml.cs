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

namespace Hospital.Sekretar
{
    /// <summary>
    /// Interaction logic for DodajPregled.xaml
    /// </summary>
    public partial class DodajPregled : Window
    {
        public ObservableCollection<Patient> listPatients
        {
            get;
            set;
        }
        public DodajPregled()
        {
            InitializeComponent();
            this.DataContext = this;
            listPatients = loadJson();
        }


        private ObservableCollection<Patient> loadJson()
        {
            PatientFileStorage pfs = new PatientFileStorage();
            ObservableCollection<Patient> patient = new ObservableCollection<Patient>(pfs.GetAll());
            return patient;

        }
        private void SaveDoctorBtn(object sender, RoutedEventArgs e)
        {
            PrioritetLekar doctorPriority = new PrioritetLekar(listPatients);
            doctorPriority.Show();

        }
        private void SaveDateBtn(object sender, RoutedEventArgs e)
        {
            PrioritetDatum datePriority = new PrioritetDatum(listPatients);
            datePriority.Show();

        }

      
    }
}
