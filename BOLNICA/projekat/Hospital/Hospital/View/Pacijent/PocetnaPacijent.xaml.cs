using Hospital.View.Pacijent;
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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for PocetnaPacijent.xaml
    /// </summary>
    public partial class PocetnaPacijent : Window
    {

        public int id { get; set; }
        public PocetnaPacijent(int idP)
        {
            InitializeComponent();
            this.DataContext = this;
            id = idP;
            PatientFileStorage storage = new PatientFileStorage();
            ObservableCollection<Patient> patients = storage.GetAll();
            foreach (Patient patient in patients)
            {
                if (patient.PatientId == idP)
                {
                    imePacijenta.Text = patient.name + " " + patient.surname;
                }
            }
        }

        private void Odjava(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void prikaz_termina(object sender, RoutedEventArgs e)
        {
            WindowPacijent wp = new WindowPacijent(id);
            wp.Show();
            this.Close();
        }

        private void klik_na_obavestenja(object sender, RoutedEventArgs e)
        {
            PrikazObavestenja po = new PrikazObavestenja();
            po.Show();
            this.Close();
        }

        private void klik_na_karton(object sender, RoutedEventArgs e)
        {
            ZdravstveniKarton karton = new ZdravstveniKarton(id);
            karton.Show();
            this.Close();
        }

        private void klik_na_ocenjivanje(object sender, RoutedEventArgs e)
        {
            OcenjivanjeDoktora ocena = new OcenjivanjeDoktora(id);
            ocena.Show();
            this.Close();

        }

        private void o_bolnici(object sender, RoutedEventArgs e)
        {
             Obolnici bolnica = new Obolnici(id);
            bolnica.Show();
            this.Close();
        }
    }
}
