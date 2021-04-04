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
using Newtonsoft.Json;
using System.IO;
using Hospital.Model;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for AddDialog.xaml
    /// </summary>
    public partial class AddDialog : Window
    {
        public ObservableCollection<Checkup> listCheckup;

        public AddDialog(ObservableCollection<Checkup> list)
        {
            InitializeComponent();
            listCheckup = list;
        }

        public Patient getPatientFromFile()
        {
            Patient ret = new Patient();

            PatientFileStorage storage = new PatientFileStorage(); //cita pacijente iz fajla
            ret = storage.FindById(54); //uzima onog ciji je zdrastveni karton 54

            return ret;
        }

        public Doctor getDoctorFromFile()
        {
            Doctor ret = new Doctor();

            List<Doctor> doctors = JsonConvert.DeserializeObject<List<Doctor>>(File.ReadAllText(@"./../../../../Hospital/files/storageDoctor.json")); //cita listu doktora iz fajla
            ret = doctors[0]; //uzima prvog u listi(jedinog)

            return ret;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            CheckupFileStorage st = new CheckupFileStorage();
            Patient patient = getPatientFromFile();
            Doctor doctor = getDoctorFromFile();
            int ida = 1;

            Checkup newCheckup = new Checkup(ida,1, Convert.ToDateTime(dateText.Text), Convert.ToDateTime(timeText.Text), Convert.ToDouble(durationText.Text), (CheckupType)comboBox.SelectedIndex,patient,doctor);
            st.Save(newCheckup);
            listCheckup.Add(newCheckup);
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
