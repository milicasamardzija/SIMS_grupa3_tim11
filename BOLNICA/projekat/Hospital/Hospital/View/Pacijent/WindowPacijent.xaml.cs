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
  
    public partial class WindowPacijent : Window
    {
        

        PatientController patientController;
        FunctionalityController functionalityController;
        CheckupController checkupController;
        CheckupDTO checkup = new CheckupDTO();
        CheckupDTO Checkup
        {
            get { return checkup; }
            set { checkup = value; }
        }

        public ObservableCollection<CheckupDTO> AppointmentList
        {
            get;
            set;
        }

        public int id { get; set; }

        public int count1 = 0;
        public int count2 = 0;
        public int count3 = 0;
        public WindowPacijent(int idP)
        {
            InitializeComponent();
            this.DataContext = this;
            id = idP;
            patientController = new PatientController();
            functionalityController = new FunctionalityController();
            checkupController = new CheckupController();
            AppointmentList = new ObservableCollection<CheckupDTO>(checkupController.getCheckupsPatient(id)); 





            foreach (PatientDTO patient in patientController.getAll())

            { 
                
                if (patient.Id == idP)

                {
                    imePacijentaa.Text = patient.Name + " " + patient.Surname;

                    foreach (FunctionalityDTO funkcionalnost in functionalityController.getAll())
                    {

                        if (patient.Id == funkcionalnost.idPacijenta)
                        { 
                            if (funkcionalnost.vrstaFunkcionalnosti == "dodavanje")
                            {
                                count1 = count1 + 1;
                            }
                            else if (funkcionalnost.vrstaFunkcionalnosti == "izmena")
                            {
                                count2 = count2 + 1;
                            }
                            else if (funkcionalnost.vrstaFunkcionalnosti == "brisanje")
                            {
                                count3 = count3 + 1;
                            }
                        }
                    }

                    if (count1 > 5 || count2>3 ||  count3>3)
                    {
                        patient.Banovan = true;
                        
                    }

                }
                
            }


          
        }
       

        private void dodavanje(object sender, RoutedEventArgs e)
        {
            DodajTermin dd = new DodajTermin(AppointmentList, id); 

            dd.Show();

        
        }

       

        private void izmeni(object sender, RoutedEventArgs e)
        {
          IzmeniTermin it = new IzmeniTermin(AppointmentList, (CheckupDTO)ListaTermina.SelectedItem, ListaTermina.SelectedIndex,id);

            it.Show();
            Patient ret = new Patient();


        }   

        private void obrisi(object sender, RoutedEventArgs e)
        {

           ObrisiTermin ob = new ObrisiTermin(AppointmentList, (CheckupDTO)ListaTermina.SelectedItem, ListaTermina.SelectedIndex);
            ob.Show();

          
        }

        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            PocetnaPacijent pp = new PocetnaPacijent(id);
            pp.Show();
            this.Close();
        }
    }
}
