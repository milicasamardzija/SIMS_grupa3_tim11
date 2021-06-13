using Hospital.Controller;
using Hospital.DTO;
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

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for ObavljeniPregledi.xaml
    /// </summary>
    public partial class ObavljeniPregledi : Window
    {

        int id;
        PatientController patientController;
        AnamnesisController controller;
        public static Anamnesis selektovanaAnamneza;

        public ObavljeniPregledi(int idP)
           
        {
            InitializeComponent();
            id = idP;
            patientController = new PatientController();
            controller = new AnamnesisController();
            this.DataContext = this;
            dodajbtn.IsEnabled = false;
            FillTable();


            foreach (PatientDTO patient in patientController.getAll())
            {
                if (patient.Id == idP)
                {
                    imePacijenta.Text = patient.Name + " " + patient.Surname;
                }
            }
        }

        private void FillTable()
        {
           
            foreach (Anamnesis a in controller.getbyId(id))
            {
               
                    Anamneza.Items.Add(a);
              
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selektovanaAnamneza = (Anamnesis)Anamneza.SelectedItem;
            DodajBelesku beleska = new DodajBelesku(id,selektovanaAnamneza);
            beleska.Show();
            this.Close();

        }

     
        private void odustani(object sender, RoutedEventArgs e)
        {
            ZdravstveniKarton karton = new ZdravstveniKarton(id);
            karton.Show();
            this.Close();

        }

        private void ShowNotesForAnamnesis(object sender, RoutedEventArgs e)
        {
            PrikazBiljeski beleske = new PrikazBiljeski(id,selektovanaAnamneza);
            beleske.Show();


        }

        private void Anamneza_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selektovanaAnamneza = (Anamnesis)Anamneza.SelectedItem;
            dodajbtn.IsEnabled = true;

        }
    }
}
