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
using Hospital.FileStorage.Interfaces;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for AddDialog.xaml
    /// </summary>
    public partial class AddDialog : Window
    {
        public List<Checkup> listCheckup;
        public int idD; 

        public AddDialog(List<Checkup> list, int idDoctor)
        {
            InitializeComponent();
            listCheckup = list;
            idD = idDoctor;
            dateP.DisplayDate = new DateTime(2021, 04, 17);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime newdate = (DateTime)(((DatePicker)sender).SelectedDate);
        }

        
        public Patient getPatientFromFile()
        {
            IPatientFileStorage storage = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json"); 
            Patient ret = storage.FindById(2); 

            return ret;
        }

        public Doctor getDoctorFromFile() 
        {
            Doctor ret = new Doctor();
            List<Doctor> doctors = JsonConvert.DeserializeObject<List<Doctor>>(File.ReadAllText(@"./../../../../Hospital/files/storageDoctor.json")); 
           
            foreach (Doctor doctor in doctors)  
            {
                if (doctor.Id == idD)
                {
                    ret = doctor;
                    break; 
                }
            }

            return ret;
        }

        public int generateID()
        {
            int ret = 0;
            ICheckFileStorage storage = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            List<Checkup> allCheckups = storage.GetAll();
            foreach (Checkup ch in allCheckups)
            {
                foreach (Checkup checkup in allCheckups)
                {
                    if (ret == checkup.Id)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ICheckFileStorage st = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            Patient patient = getPatientFromFile();
            Doctor doctor = getDoctorFromFile();

            Checkup newCheckup = new Checkup(generateID(), doctor.Id, patient.Id, dateP.DisplayDate, 1, (CheckupType)comboBox.SelectedIndex);

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
