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
using Hospital.FileStorage.Interfaces;

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
            int returnCheckupId = 0;
            ICheckFileStorage storageCheckup = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            List<Checkup> allCheckups = storageCheckup.GetAll();
            foreach (Checkup checkups in allCheckups)
            {
                foreach (Checkup checkup in allCheckups)
                {
                    if (returnCheckupId == checkup.Id)
                    {
                        ++returnCheckupId;
                        break;
                    }
                }
            }
            return returnCheckupId;
        }

        public Patient getPatientFromFile()
        {
            IPatientFileStorage storagePatient = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            Patient returnPatient = storagePatient.FindById(2);

            return returnPatient;
        }
        
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            CheckupFileStorage st = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");

            Checkup newCheckups = new Checkup(generateIdCheckup(), (int)doctorBox.SelectedIndex, Convert.ToInt16(textPacijent.Text), Date.DisplayDate,
                Convert.ToInt16(textTrajanje.Text), (CheckupType)comboBox.SelectedIndex);

            st.Save(newCheckups);
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
