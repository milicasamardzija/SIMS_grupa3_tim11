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


        public ObservableCollection<Appointment> AppointmentList
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


            Patient ret = new Patient();
            PatientFileStorage storage = new PatientFileStorage();
            ObservableCollection<Patient> patients = storage.GetAll();
            FunkcionalnostiFileStorage funkcije = new FunkcionalnostiFileStorage();
            List<Koristenjefunkcionalnosti> funkcionalnosti = funkcije.GetAll();


            foreach (Patient patient in patients)
            {
                if (patient.PatientId == idP)
                {
                    foreach (Koristenjefunkcionalnosti funkcionalnost in funkcionalnosti)
                    {

                        if (patient.PatientId == funkcionalnost.idPacijenta)
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
                        patient.banovan = true;
                        
                    }

                }   
            }


        }
        public ObservableCollection<Appointment> loadJason()
        {
            AppointmentFileStorage fs = new AppointmentFileStorage();
            ObservableCollection<Appointment> rs = new ObservableCollection<Appointment>(fs.GetAll()); //svi termini
            ObservableCollection<Appointment> ret = new ObservableCollection<Appointment>(); //ovde ce biti ubaceni termini za pacijenta sa prisledjenim id-jem(odnosno id pacijenta koji je ulogovan na sistem)

            foreach (Appointment appointment in rs) //prolazimo kroz sve termine u fajlu
            {

                if (appointment.Patient.PatientId == id) //trazimo termin koji ima pacijenta sa prosledjenim id-jem
                {

                    ret.Add(appointment); //dodajemo taj termin u listu koju vracamo za ispis u tabelu
                }
            }

            return ret;
        }



        

        private void dodavanje(object sender, RoutedEventArgs e)
        {
            DodajTermin dd = new DodajTermin(AppointmentList, id); //salje se i id ulogovang pacijenta



            Patient ret = new Patient();
            PatientFileStorage storage = new PatientFileStorage();
            ObservableCollection<Patient> patients = storage.GetAll();
            FunkcionalnostiFileStorage funkcije = new FunkcionalnostiFileStorage();
            List<Koristenjefunkcionalnosti> funkcionalnosti = funkcije.GetAll();

            

            foreach (Patient patient in patients) //prolaz kroz sve pacijente u fajlu
            {
                if (patient.PatientId == id)
                { 
                    foreach (Koristenjefunkcionalnosti funkcionalnost in funkcionalnosti)
                    {

                        if (patient.PatientId == funkcionalnost.idPacijenta  && funkcionalnost.vrstaFunkcionalnosti == "dodavanje")
                        {
                            count1 = count1 + 1;
                               
                        }
                    }

                    if (count1 > 1)
                    {
                        patient.banovan = true;

                       

                    }

                    if (patient.banovan == false)
                    {
                        dd.Show();
                    }
                    else
                    {
                        patient.datumBanovanja = DateTime.Now;
                        MessageBoxResult result = MessageBox.Show("Zakazivanje je blokirano.", "Upozorenje", MessageBoxButton.OK);
                    }
                  
                 
                    if(patient.datumBanovanja.AddMinutes(2) <= DateTime.Now)
                    {
                        patient.banovan = false;
                        count1 = 0;
                    }
                }

            }

        }

       

        private void izmeni(object sender, RoutedEventArgs e)
        {
           IzmeniTermin it = new IzmeniTermin(AppointmentList, (Appointment)ListaTermina.SelectedItem, ListaTermina.SelectedIndex,id);


            Patient ret = new Patient();
            PatientFileStorage storage = new PatientFileStorage();
            ObservableCollection<Patient> patients = storage.GetAll();
            FunkcionalnostiFileStorage funkcije = new FunkcionalnostiFileStorage();
            List<Koristenjefunkcionalnosti> funkcionalnosti = funkcije.GetAll();



            foreach (Patient patient in patients) //prolaz kroz sve pacijente u fajlu
            {
                if (patient.PatientId == id)
                {

                    foreach (Koristenjefunkcionalnosti funkcionalnost in funkcionalnosti)
                    {

                        if (patient.PatientId == funkcionalnost.idPacijenta && funkcionalnost.vrstaFunkcionalnosti == "izmena")
                        {
                            count1 = count1 + 1;

                        }
                    }

                    if (count2 > 3)
                    {
                        patient.banovan = true;

                    }
                    if (patient.banovan == false)
                    {
                       it.Show();
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Izmena termina je blokirana.", "Upozorenje", MessageBoxButton.OK);
                    }
                }

            }


        }   

        private void obrisi(object sender, RoutedEventArgs e)
        {

            ObrisiTermin ob = new ObrisiTermin(AppointmentList, (Appointment)ListaTermina.SelectedItem, ListaTermina.SelectedIndex);

            Patient ret = new Patient();
            PatientFileStorage storage = new PatientFileStorage();
            ObservableCollection<Patient> patients = storage.GetAll();
            FunkcionalnostiFileStorage funkcije = new FunkcionalnostiFileStorage();
            List<Koristenjefunkcionalnosti> funkcionalnosti = funkcije.GetAll();


            foreach (Patient patient in patients) //prolaz kroz sve pacijente u fajlu
            {
                if (patient.PatientId == id)
                {
                    foreach (Koristenjefunkcionalnosti funkcionalnost in funkcionalnosti)
                    {

                        if (patient.PatientId == funkcionalnost.idPacijenta && funkcionalnost.vrstaFunkcionalnosti == "brisanje")
                        {
                            count3 = count1 + 1;

                        }
                    }

                    if (count3 > 3)
                    {
                        patient.banovan = true;

                    }



                    if (patient.banovan == false)
                    {
                        ob.Show();
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Brisanje termina je blokirano.", "Upozorenje", MessageBoxButton.OK);
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
