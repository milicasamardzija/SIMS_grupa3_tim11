using Hospital.Controller;
using Hospital.DTO;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
 
    public partial class OcenjivanjeDoktora : Window
    {

        PatientController patientController;
        CheckupController checkupController;
        public int id { get; set; }
        public ObservableCollection<CheckupDTO> termini
        {
            get;
            set;
        }
        public OcenjivanjeDoktora(int idP)
        {
            InitializeComponent();
            this.DataContext = this;
            id = idP;
            patientController = new PatientController();
            checkupController = new CheckupController();

            termini = new ObservableCollection<CheckupDTO>(checkupController.getCheckupsbyDate(id));
            bolnica.IsEnabled = false;


            foreach (PatientDTO patient in patientController.getAll())
            {
                if (patient.Id == idP)
                {
                    imePacijenta.Text = patient.Name + " " + patient.Surname;
                }
            }
            if (termini.Count > 5)
            {
                bolnica.IsEnabled = true;
            }

        }
        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            PocetnaPacijent pacijent = new PocetnaPacijent(id);
            pacijent.Show();
            this.Close();
        }
        private void oceni_doktora(object sender, RoutedEventArgs e)
        {
           DodajAnketu pp = new DodajAnketu(termini, (CheckupDTO)ListaObavljenihTermina.SelectedItem, ListaObavljenihTermina.SelectedIndex, id);
            pp.Show();

        }
      
        private void ocenite_bolnicu(object sender, RoutedEventArgs e)
        {
            OceniteBolnicu oceni = new OceniteBolnicu(id);
            oceni.Show();
        }

       

     
    }
}
