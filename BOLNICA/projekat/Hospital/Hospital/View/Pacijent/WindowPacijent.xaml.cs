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
        public int id { get; set; }

        public int count1 = 0;
        public int count2 = 0;
        public int count3 = 0;

        PatientController patientController;
        FunctionalityController functionalityController;

        public ObservableCollection<Checkup> AppointmentList
        {
            get;
            set;
        }
        public WindowPacijent(int idP)
        {
            InitializeComponent();
            this.DataContext = this;
            id = idP;
            AppointmentList = loadJason();
            patientController = new PatientController();
            functionalityController = new FunctionalityController();


          

          

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
        public ObservableCollection<Checkup> loadJason()
        {
            CheckupFileStorage fs = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            ObservableCollection<Checkup> rs = new ObservableCollection<Checkup>(fs.GetAll()); //svi termini
            ObservableCollection<Checkup> ret = new ObservableCollection<Checkup>(); 

            foreach (Checkup appointment in rs) 
            {

                if (appointment.IdPatient == id) 
                {

                    ret.Add(appointment);
                }
            }

            return ret;
        }


       

        private void dodavanje(object sender, RoutedEventArgs e)
        {
            DodajTermin dd = new DodajTermin(AppointmentList, id); //salje se i id ulogovang pacijenta

            dd.Show();

         
        
            

            

            foreach (PatientDTO patient in patientController.getAll()) //prolaz kroz sve pacijente u fajlu
            {
                if (patient.Id == id)
                { 
                    foreach (FunctionalityDTO funkcionalnost in functionalityController.getAll())
                    {

                        if (patient.Id == funkcionalnost.idPacijenta  && funkcionalnost.vrstaFunkcionalnosti == "dodavanje")
                        {
                            count1 = count1 + 1;
                               
                        }
                    }

                    if (count1 > 1)
                    {
                        patient.Banovan = true;

                       

                    }

                    if (patient.Banovan == false)
                    {
                        dd.Show();
                    }
                    else
                    {
                        patient.DatumBanovanja = DateTime.Now;
                       // MessageBoxResult result = MessageBox.Show("Zakazivanje je blokirano.", "Upozorenje", MessageBoxButton.OK);
                    }
                  
                 
                    if(patient.DatumBanovanja.AddMinutes(2) <= DateTime.Now)
                    {
                        patient.Banovan = false;
                        count1 = 0;
                    }
                }

            }

        }

       

        private void izmeni(object sender, RoutedEventArgs e)
        {
           IzmeniTermin it = new IzmeniTermin(AppointmentList, (Checkup)ListaTermina.SelectedItem, ListaTermina.SelectedIndex,id);

            it.Show();
            Patient ret = new Patient();
           


            foreach (PatientDTO patient in patientController.getAll()) //prolaz kroz sve pacijente u fajlu
            {
                if (patient.Id == id)
                {

                    foreach (FunctionalityDTO funkcionalnost in functionalityController.getAll())
                    {

                        if (patient.Id == funkcionalnost.idPacijenta && funkcionalnost.vrstaFunkcionalnosti == "izmena")
                        {
                            count1 = count1 + 1;

                        }
                    }

                    if (count2 > 3)
                    {
                        patient.Banovan = true;

                    }
                    if (patient.Banovan == false)
                    {
                       it.Show();
                    }
                    else
                    {
                      //  MessageBoxResult result = MessageBox.Show("Izmena termina je blokirana.", "Upozorenje", MessageBoxButton.OK);
                    }
                }

            }


        }   

        private void obrisi(object sender, RoutedEventArgs e)
        {

            ObrisiTermin ob = new ObrisiTermin(AppointmentList, (Checkup)ListaTermina.SelectedItem, ListaTermina.SelectedIndex);

            Patient ret = new Patient();
           


            foreach (PatientDTO patient in patientController.getAll()) //prolaz kroz sve pacijente u fajlu
            {
                if (patient.Id == id)
                {
                    foreach (FunctionalityDTO funkcionalnost in functionalityController.getAll())
                    {

                        if (patient.Id == funkcionalnost.idPacijenta && funkcionalnost.vrstaFunkcionalnosti == "brisanje")
                        {
                            count3 = count1 + 1;

                        }
                    }

                    if (count3 > 3)
                    {
                        patient.Banovan = true;

                    }



                    if (patient.Banovan == false)
                    {
                        ob.Show();
                    }
                    else
                    {
                      //  MessageBoxResult result = MessageBox.Show("Brisanje termina je blokirano.", "Upozorenje", MessageBoxButton.OK);
                    }
                }

            }

        }

        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            PocetnaPacijent pp = new PocetnaPacijent(id);
            pp.Show();
            this.Close();
        }
    }
}
