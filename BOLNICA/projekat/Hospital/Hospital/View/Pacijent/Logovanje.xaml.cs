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

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for Logovanje.xaml
    /// </summary>
    public partial class Logovanje : Window
    {
        public int id { get; set; }
        public Logovanje()
        {
            InitializeComponent();
        }
        private void prijavi_se(object sender, RoutedEventArgs e)
        {

            {
                if (uloga.SelectedIndex == 3) //upravnik
                {
                    ManagerFileStorage mf = new ManagerFileStorage();
                    List<Manager> managers = mf.GetAll();

                    foreach (Manager manager in managers)
                    {
                        if (manager.username.Equals(ime.Text) && manager.password.Equals(lozinka.Password))
                        {
                            id = manager.managerId;
                            // Rooms m = new Rooms();
                            ManagerView m = new ManagerView();
                            m.Show();
                            // this.Close();
                            return;
                        }
                    }
                }
                else if (uloga.SelectedIndex == 1) //lekar
                {
                    DoctorFileStorage df = new DoctorFileStorage(@"./../../../../Hospital/files/storageDoctor.json");
                    List<Doctor> doctors = df.GetAll();

                    foreach (Doctor doctor in doctors)
                    {
                        if (doctor.username.Equals(ime.Text) && doctor.password.Equals(lozinka.Password))
                        {
                            id = doctor.Id;
                            Pregled d = new Pregled(id);
                            d.Show();
                            // this.Close();
                            return;
                        }
                    }
                }
                else if (uloga.SelectedIndex == 2) //sekretar
                {
                   /* SecretaryFileStorage sf = new SecretaryFileStorage();
                    List<Secretary> secretaries = sf.GetAll();

                    foreach (Secretary secretary in secretaries)
                    {
                        if (secretary.username.Equals(ime.Text) && secretary.password.Equals(lozinka.Password))
                        {
                            id = secretary.secretaryId;

                            Nalozi s = new Nalozi();
                            s.Show();

                            return;
                        }
                    }*/

                }
                else if (uloga.SelectedIndex == 0) //pacijent
                {

                    PatientFileStorage pf = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
                    ObservableCollection<Patient> patients = new ObservableCollection<Patient>(pf.GetAll());

                    foreach (Patient patient in patients)
                    {
                        if (patient.username.Equals(ime.Text) && patient.password.Equals(lozinka.Password))
                        {
                            id = patient.Id;
                            PocetnaPacijent p = new PocetnaPacijent(id);
                            p.Show();
                             this.Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Neuspesno logovanje");
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

        private void zdravo_bolnica(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            MainWindow glavna = new MainWindow();
            glavna.Show();
            this.Close();
        }
    }
}
