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
        public Room rooms;
        public int idD;

        public Patient patient;
        public Doctor doctor;
        public Room room;

        public AddDialog(List<Checkup> list, int idDoctor)
        {
            InitializeComponent();
            listCheckup = list;
            idD = idDoctor;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime newdate = (DateTime)(((DatePicker)sender).SelectedDate);
        }
        
        public Patient getPatientFromFile()
        {
            IPatientFileStorage storagePatient = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json"); 
            Patient returnPatient = storagePatient.FindById(patient.Id); 

            return returnPatient;
        }

        public Room getRoomFromFile()
        {
            RoomIFileStorage storageRoom = new RoomFileStorage("./../../../../Hospital/files/storageRooms.json");
            Room returnRoom = storageRoom.FindById(rooms.Id);

            return returnRoom;
        }

        public Doctor getDoctorFromFile() 
        {
            Doctor returnDoctor = new Doctor();
            List<Doctor> doctors = JsonConvert.DeserializeObject<List<Doctor>>(File.ReadAllText("./../../../../Hospital/files/storageDoctor.json")); 
           
            foreach (Doctor doctor in doctors)  
            {
                if (doctor.Id == idD)
                {
                    returnDoctor = doctor;
                    break; 
                }
            }

            return returnDoctor;
        }

        public int generateID()
        {
            int ret = 0;
            ICheckFileStorage storageCheckup = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            List<Checkup> allCheckups = storageCheckup.GetAll();
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

        public void components(Patient p, Doctor d, Room r)
        {
            p = getPatientFromFile();
            d = getDoctorFromFile();
            r = getRoomFromFile();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ICheckFileStorage storageCheckups = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            components(patient, doctor, room);

            Checkup newCheckup = new Checkup(generateID(), doctor.Id, patient.Id, dateP.DisplayDate, room.Id, (CheckupType)comboBox.SelectedIndex);

            storageCheckups.Save(newCheckup);
            listCheckup.Add(newCheckup);
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
