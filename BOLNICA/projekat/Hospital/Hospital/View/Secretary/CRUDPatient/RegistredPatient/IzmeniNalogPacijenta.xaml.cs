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
using System.Collections.ObjectModel;

namespace Hospital
{

    public partial class IzmeniNalogPacijenta : Window { 

       public ObservableCollection<Patient> listPatient;
        public ObservableCollection<MedicalRecord> listRecord;
        public Patient patient;
        public int index;
        public MedicalRecord record;

        public int id;
        public IzmeniNalogPacijenta(ObservableCollection<Patient> list, Patient selectedPatient, int sel)
        {
           InitializeComponent();
            listPatient = list;

            foreach (Patient p in listPatient)
            {
                if (p.Equals(selectedPatient))
                {
                    patient = p;
                    break;
                }
            }

         

            listPatient=list;
            index = sel;

            //da bih nasla odgovarajuci karton pacijenta
            id = selectedPatient.Id;
            MedicalRecordsFileStorage mfs = new MedicalRecordsFileStorage();
            record = mfs.FindById(id);


            //za nalog
            imeText.SelectedText = selectedPatient.Name;
            prezimeText.SelectedText = selectedPatient.Surname;
            jmbgText.SelectedText = selectedPatient.Jmbg;
            pol.SelectedIndex = (int)selectedPatient.Gender; 
            brText.SelectedText = selectedPatient.TelephoneNumber;

            datum.SelectedDate = (DateTime)selectedPatient.BirthdayDate;
            brKnjText.SelectedText = Convert.ToString(selectedPatient.IdHealthCard);
            brKarText.SelectedText = Convert.ToString(selectedPatient.Id);

            datum.SelectedDate = (DateTime)selectedPatient.BirthdayDate;
            brKnjText.SelectedText = Convert.ToString(selectedPatient.IdHealthCard);
            brKarText.SelectedText = Convert.ToString(selectedPatient.Id);
            zanimanjeText.SelectedText = selectedPatient.Occupation;
            zastitaText.SelectedIndex = (int)selectedPatient.HealthCareCategory;
            osiguraniktText.SelectedText = selectedPatient.Insurence;
            ulicaText.SelectedText = Convert.ToString(selectedPatient.adress.street);
            broj.SelectedText = Convert.ToString(selectedPatient.adress.streetNumber);
            grad.SelectedIndex = (int)selectedPatient.adress.city;  
            drzava.SelectedIndex = (int)selectedPatient.adress.country;

            //informacije iz kartona
            krvnaGrupa.SelectedIndex = (int)record.BloodType; 
        }

        private void izmenaPacijentaB(object sender, RoutedEventArgs e)
        {

            PatientFileStorage pfs = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            Patient promeniP = pfs.FindById(Convert.ToInt16(brKarText.Text));
            Patient izbrisiP = pfs.FindById(Convert.ToInt16(brKarText.Text));

            promeniP.Name = imeText.Text;
            promeniP.Surname = prezimeText.Text;
            promeniP.BirthdayDate = (DateTime)datum.SelectedDate;
            promeniP.Jmbg = jmbgText.Text;
            promeniP.Occupation = zanimanjeText.Text;
            promeniP.Insurence = osiguraniktText.Text;
            promeniP.Gender = (Gender)pol.SelectedIndex;    //ovako ide za combo box
            promeniP.TelephoneNumber = brText.Text;

            promeniP.Id = Convert.ToInt16(brKarText.Text);
            
            promeniP.IdHealthCard = Convert.ToInt16(brKnjText.Text);
            promeniP.HealthCareCategory = (HealthCareCategory)zastitaText.SelectedIndex;
            promeniP.adress.city =((City)grad.SelectedIndex);
            promeniP.adress.country =(Country)drzava.SelectedIndex;
            promeniP.adress.street = ulicaText.Text;
            promeniP.adress.streetNumber = Convert.ToInt16(broj.Text);


            MedicalRecordsFileStorage mfs = new MedicalRecordsFileStorage();
            MedicalRecord promeniM = mfs.FindById(Convert.ToInt16(brKarText.Text));
            MedicalRecord izbrisiM = mfs.FindById(Convert.ToInt16(brKarText.Text));

            promeniM.Name = imeText.Text;
            promeniM.Surname = prezimeText.Text;
            promeniM.BirthdayDate = (DateTime)datum.SelectedDate;
            promeniM.Jmbg = jmbgText.Text;
            promeniM.Gender = (Gender)pol.SelectedIndex;
            promeniM.MedicalRecordId= Convert.ToInt16(brKarText.Text);
            promeniM.IdHealthCard = Convert.ToInt16(brKnjText.Text);
            promeniM.HealthCareCategory= (HealthCareCategory)zastitaText.SelectedIndex;
            promeniM.BloodType = (BloodType)krvnaGrupa.SelectedIndex;
           

            mfs.Delete(izbrisiM);
            mfs.Save(promeniM);


            pfs.Delete(izbrisiP);
            pfs.Save(promeniP);



            this.Close();

        }
        private void odustaniB(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
