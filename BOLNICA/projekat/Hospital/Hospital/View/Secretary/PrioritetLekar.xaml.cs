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
   
    public partial class PrioritetLekar : Window
    {

        public Patient patient;

       public  ObservableCollection<Patient> listPatient
        {
            get; set;
        }
       public  ObservableCollection<Doctor> listDoctors
        {
            get; set;
        }
        public PrioritetLekar(ObservableCollection<Patient> list, Patient selectedPatient)
        {
            InitializeComponent();
            this.DataContext = this;
            patient=selectedPatient; //imam pacijenta kome zakazujem 
       
            listPatient = list;
            listDoctors = loadJson();// ucitava se lista svih lekara 

        }

        private ObservableCollection<Doctor> loadJson()
        {
            DoctorFileStorage dfs = new DoctorFileStorage();
             ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>(dfs.GetAll());
            return doctors;

        }

        private void getDoctorTerms(object sender, RoutedEventArgs e)
        {
            if ((Doctor)doktori.SelectedItem != null)
            {
                SacuvajLekara terms = new SacuvajLekara(listDoctors, (Doctor)doktori.SelectedItem, patient); //poslala sam informaciju o doktoru, moram i o ranijem pacijentu 
                terms.Show();

            } else
            {
                MessageBoxResult result = MessageBox.Show("Niste odabrali lekara!");
            }
        }

        private void Decline(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
