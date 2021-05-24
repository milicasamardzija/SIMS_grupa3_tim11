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
using Hospital.Model;
using Newtonsoft.Json;
using System.IO;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for EditDialog.xaml
    /// </summary>
    public partial class EditDialog : Window
    {

        public List<Checkup> listCheckup;
        public Checkup checkup;
        public int index;
        public int idD;

        public EditDialog(List<Checkup> list, Checkup selectedCheckup, int selectedIndex)
        {
            InitializeComponent();
            listCheckup = list;
            checkup = selectedCheckup;
            index = selectedIndex;
            datePick.SelectedDate = Convert.ToDateTime(selectedCheckup.Date);
            //datePick.DisplayDate = new DateTime(2021, 04, 17);
           // timeText.SelectedText = Convert.ToString(selectedCheckup.Time);
            durationText.SelectedText = Convert.ToString(selectedCheckup.Duration);
            comboBox.SelectedIndex = (int)selectedCheckup.Type;
            patientBox.SelectedText = Convert.ToString(selectedCheckup.IdPatient);
            idRoom.SelectedText = Convert.ToString(selectedCheckup.IdRoom);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime newdate = (DateTime)(((DatePicker)sender).SelectedDate);
        }

        public int generisiID()
        {
            int ret = 0;
            CheckupFileStorage storage = new CheckupFileStorage();
            List<Checkup> allCheckups = storage.GetAll();
            foreach (Checkup ch in allCheckups)
            {
                foreach (Checkup checkup in allCheckups)
                {
                    if (ret == checkup.IdCh)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        public int getDoctorFromFile() //fija koja vraca doktora koji je ulogovan na sistem i koji ce biti ubacen u termin
        {
            int ret = 0;
            List<Doctor> doctors = JsonConvert.DeserializeObject<List<Doctor>>(File.ReadAllText(@"./../../../../Hospital/files/storageDoctor.json")); //cita listu doktora iz fajla

            foreach (Doctor doctor in doctors)  //prolaz kroz sve dokore u fajlu
            {
                 if (doctor.DoctorId == idD) //pronalazi doktora sa id-jem ulogovanog doktora
                 {
                ret = idD;
                break; //kada ga nadje izlazi iz petlje
                }
            }

            return ret;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            CheckupFileStorage st = new CheckupFileStorage();
            checkup.Date = datePick.DisplayDate;
            //checkup.Time = Convert.ToString(timeText.Text);
            checkup.Duration = Convert.ToDouble(durationText.Text);
            checkup.Type = (CheckupType)comboBox.SelectedIndex;
            checkup.IdPatient = Convert.ToInt16(patientBox.Text);
            checkup.IdRoom = Convert.ToInt16(idRoom.Text);
            int doctorId = getDoctorFromFile();
           // int ida = 1;

            int idCheckup = generisiID();

            listCheckup[index] = new Checkup(idCheckup, doctorId, Convert.ToInt16(checkup.IdPatient), Convert.ToDateTime(checkup.Date),
                Convert.ToInt16(checkup.IdRoom), (CheckupType)comboBox.SelectedIndex);

            st.DeleteById(Convert.ToInt16(durationText.Text));
            st.Save(checkup);
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
