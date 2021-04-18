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
        public int idD; //id ulogovanog doktora

        public AddDialog(ObservableCollection<Checkup> list, int idDoctor)
        {
            InitializeComponent();
            listCheckup = list;
            idD = idDoctor; 
        }

        //trenutno uvek dodaje istog pacijenta
        //kada se doda da se u tabeli prikazuje pacijent treba promeniti metodu da bi se od svih pacijenata nasao bas onaj za koji je zakazan termin
        public Patient getPatientFromFile()
        {
            Patient ret = new Patient();

            PatientFileStorage storage = new PatientFileStorage(); //cita pacijente iz fajla
            ret = storage.FindById(54); //uzima onog ciji je zdrastveni karton 54

            return ret;
        }

        public Doctor getDoctorFromFile() //fija koja vraca doktora koji je ulogovan na sistem i koji ce biti ubacen u termin
        {
            Doctor ret = new Doctor();
            List<Doctor> doctors = JsonConvert.DeserializeObject<List<Doctor>>(File.ReadAllText(@"./../../../../Hospital/files/storageDoctor.json")); //cita listu doktora iz fajla
           
            foreach (Doctor doctor in doctors)  //prolaz kroz sve dokore u fajlu
            {
                if (doctor.doctorId == idD) //pronalazi doktora sa id-jem ulogovanog doktora
                {
                    ret = doctor;
                    break; //kada ga nadje izlazi iz petlje
                }
            }

            return ret;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            CheckupFileStorage st = new CheckupFileStorage();
            Patient patient = getPatientFromFile();
            Doctor doctor = getDoctorFromFile();
            int ida = 1;  //ovo sam lupila id appointemnta, tu treba ispraviti da bude bas idAppointment-a koji treba
            int idch = 5; //ovo sam lupila id checkup-a tu treba napraviti neku funkciju koja ce za svaki novi pregled da generise novi id koji vec ne postoji

            Checkup newCheckup = new Checkup(ida,idch, Convert.ToDateTime(dateText.Text), Convert.ToDateTime(timeText.Text), Convert.ToDouble(durationText.Text), (CheckupType)comboBox.SelectedIndex,patient,doctor);
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
