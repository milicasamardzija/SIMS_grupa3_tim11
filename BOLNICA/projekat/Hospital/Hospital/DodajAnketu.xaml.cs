using Hospital.Model;
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
    /// Interaction logic for DodajAnketu.xaml
    /// </summary>
    public partial class DodajAnketu : Window
    {

        public OcenjivanjeDoktora parent;
        public ObservableCollection<Appointment> appointmentList;
        public Appointment termin;
        public int index;
        public int idPatient; //id pacijenta koji je ulogovan
        public string ime;
        public int id;
        

        
       private string lekar;

        public DodajAnketu(ObservableCollection<Appointment> list, Appointment selectedApp, int selectedIndex, int idP)
        {
            InitializeComponent();
            appointmentList = list;
            termin = selectedApp;
            index = selectedIndex;
            idPatient = idP;
            id = selectedApp.idA;
           

            ime = termin.Doctor.name + " " + termin.Doctor.surname;
            doktor.SelectedText = ime;


        }

   

        private void odustani(object sender, RoutedEventArgs e)
        {
            OcenjivanjeDoktora ocjeni = new OcenjivanjeDoktora(idPatient);

            this.Close();

        }

        private void posalji(object sender, RoutedEventArgs e)
        {
            SacuvanaAnketa poslato = new SacuvanaAnketa();
            poslato.Show();

            SurveyFileStorage sveAnkete = new SurveyFileStorage();

            lekar = doktor.SelectedText;
            int ocenjeno = ocena.SelectedIndex;
            string komentarisano = komentar.Text;
            int id = sveAnkete.GetAll().Count() + 1;

            Survey novaAnketa = new Survey(id, komentarisano, ocenjeno, lekar,termin.idA);

            sveAnkete.Save(novaAnketa);

           AppointmentFileStorage storage = new AppointmentFileStorage();
            storage.DeleteById(id);
            appointmentList.RemoveAt(index);

            this.Close();
          //parent.UpdateTable();

        }
    }



}