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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int id { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            id = -1;
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            Pregled p = new Pregled();
            p.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Rooms r = new Rooms();
            r.Show();
        }
        private void SekretarButton(object sender, RoutedEventArgs e)
        {
            Nalozi prozor = new Nalozi();
            prozor.ShowDialog();

        }
        private void login(object sender, RoutedEventArgs e)
        {
            if (uloga.SelectedIndex == 0) //pacijent
            {
                PatientFileStorage pf = new PatientFileStorage();
                List<Patient> patients = pf.GetAll();

                foreach (Patient patient in patients)
                {
                    if (patient.username.Equals(ime.Text) && patient.password.Equals(lozinka.Password))
                    {
                        id = patient.patientId;
                        WindowPacijent p = new WindowPacijent(id);
                        p.Show();
                        this.Close();
                        return;
                    }
                }
            }
            else if (uloga.SelectedIndex == 1) //lekar
            {
                DoctorFileStorage df = new DoctorFileStorage();
                List<Doctor> doctors = df.GetAll();

                foreach (Doctor doctor in doctors)
                {
                    if (doctor.username.Equals(ime.Text) && doctor.password.Equals(lozinka.Password))
                    {
                        id = doctor.doctorId;
                        Pregled d = new Pregled(); 
                        d.Show();
                        this.Close();
                        return;
                    }
                }
            }
            else if (uloga.SelectedIndex == 2) //sekretar
            {
                SecretaryFileStorage sf = new SecretaryFileStorage();
                List<Secretary> secretaries = sf.GetAll();

                foreach (Secretary secretary in secretaries)
                {
                    if (secretary.username.Equals(ime.Text) && secretary.password.Equals(lozinka.Password))
                    {
                        id = secretary.secretaryId;
                        Nalozi s = new Nalozi();
                        s.Show();
                        this.Close();
                        return;
                    }
                }
            }
            else if (uloga.SelectedIndex == 3) //upravnik
            {
                ManagerFileStorage mf = new ManagerFileStorage();
                List<Manager> managers = mf.GetAll();

                foreach (Manager manager in managers)
                {
                    if (manager.username.Equals(ime.Text) && manager.password.Equals(lozinka.Password))
                    {
                        id = manager.managerId;
                        Rooms m = new Rooms();
                        m.Show();
                        this.Close();
                        return;
                    }
                }
            }
            else 
            {
                MessageBox.Show("Neuspesno logovanje!");
            }

                MessageBox.Show("Neuspesno logovanje!");
        }
    }
}