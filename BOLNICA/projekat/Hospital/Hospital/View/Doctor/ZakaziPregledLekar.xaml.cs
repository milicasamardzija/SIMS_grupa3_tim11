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
using Hospital.Model;
using Newtonsoft.Json;
using System.IO;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for ZakaziPregledLekar.xaml
    /// </summary>
    public partial class ZakaziPregledLekar : Window
    {
        public List<Checkup> listCheckup;
        public int idDoctor;

        public ZakaziPregledLekar(List<Checkup> list, int id)
        {
            InitializeComponent();
            listCheckup = list;
            idDoctor = id;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime newdate = (DateTime)(((DatePicker)sender).SelectedDate);
        }

        public int generateIdCheckup()
        {
            int ret = 0;
            CheckupFileStorage storage = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
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

        public Patient getPatientFromFile()
        {
            PatientFileStorage storage = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            Patient ret = storage.FindById(54);

            return ret;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            CheckupFileStorage st = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            //int idAppointment = 0;
            //Patient patient = getPatientFromFile();

            Checkup newCheckups = new Checkup(generateIdCheckup(), (int)doctorBox.SelectedIndex, Convert.ToInt16(textPacijent.Text), Date.DisplayDate,
                Convert.ToInt16(textTrajanje.Text), (CheckupType)comboBox.SelectedIndex);

            /*public Checkup(int idCh, int idD, int idP, DateTime dateAndTime, int idR, CheckupType type) */

            st.Save(newCheckups);
           // listCheckup.Add(newCheckups);
            this.Close();
        }
    }
}
