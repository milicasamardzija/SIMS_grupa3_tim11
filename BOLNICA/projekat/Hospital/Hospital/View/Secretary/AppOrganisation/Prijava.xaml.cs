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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for Prijava.xaml
    /// </summary>
    public partial class Prijava : Page
    {
        public int id { get; set; } //id ulogovanog korisnika
        public Page blog;
        public Prijava(BlogGlavni blogGlavni)
        {
            InitializeComponent();
            id = -1; //inicijalno je na vrednosti koju nece imati nijedan korsinik(id ce nam ici od 1 pa dalje)
            blog = blogGlavni;
        }
        private void login(object sender, RoutedEventArgs e)
        {
            if (uloga.SelectedIndex == 0) //pacijent
            {
                PatientFileStorage pf = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
                ObservableCollection<Patient> patients = new ObservableCollection<Patient>(pf.GetAll()); //svi pacijenti iz fajla

                foreach (Patient patient in patients)
                {
                    if (patient.Username.Equals(ime.Text) && patient.Password.Equals(lozinka.Password)) //ako su sifra i korisnicko ime nadjeni u fajlu
                    {
                        id = patient.Id; //preuzimamo id pacijenta koji dalje prosledjujemo prozoru koji se prvi otvara, pa dalje ostalim prozorima da bismo uvek prikazivali podatke na osnovu ovog id-ja(odnosno bas sa korisnika koji je ulogovan)
                        PocetnaPacijent p = new PocetnaPacijent(id); //otvara se prozor i prosledjuje id
                        p.Show();
                       // this.Close();
                        return; //da ne bi trazio u drugim fajlovima
                    }
                }
            }
            else if (uloga.SelectedIndex == 1) //lekar
            {
                DoctorFileStorage df = new DoctorFileStorage(@"./../../../../Hospital/files/storageDoctor.json");
                List<Doctor> doctors = df.GetAll();

                foreach (Doctor doctor in doctors)
                {
                    if (doctor.Username.Equals(ime.Text) && doctor.Password.Equals(lozinka.Password))
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
                SecretaryFileStorage sf = new SecretaryFileStorage();
                List<Secretary> secretaries = sf.GetAll();

                foreach (Secretary secretary in secretaries)
                {
                    if (secretary.Username.Equals(ime.Text) && secretary.Password.Equals(lozinka.Password))
                    {
                        id = secretary.secretaryId;
                        
                        Nalozi s = new Nalozi();
                        s.Show();
                  
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
                    if (manager.Username.Equals(ime.Text) && manager.Password.Equals(lozinka.Password))
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
            else
            {
                MessageBox.Show("Neuspesno logovanje!");
            }

            MessageBox.Show("Neuspesno logovanje!");
        }
    }
}
