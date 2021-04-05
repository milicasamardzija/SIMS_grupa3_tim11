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

            }
            else if (uloga.SelectedIndex == 2) //sekretar
            {

            }
            else if (uloga.SelectedIndex == 3) //upravnik
            {

            }
            else 
            {
                MessageBox.Show("Neuspesno logovanje!");
            }

                MessageBox.Show("Neuspesno logovanje!");
        }
    }
}